using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace CraftingGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 400f;
        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
        [SerializeField] private bool airControl = false;
        [SerializeField] private LayerMask groudLayerMask;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;

        private const float GroundedRadius = .2f;
        private bool isGrounded;
        private new Rigidbody2D rigidbody2D;
        private bool facingRight = true;
        private Vector3 velocity = Vector3.zero;
        private float limitFallSpeed = 25f;

        public bool canDoubleJump = true;
        [SerializeField] private float m_DashForce = 25f;
        private bool canDash = true;
        private bool isDashing = false;
        private bool isWall = false;
        private bool isWallSliding = false;
        private bool wasWallSlidding = false;
        private float prevVelocityX = 0f;
        private bool canSlide = false;

        private bool canMove = true;

        private float jumpWallStartX = 0;
        private float jumpWallDistX = 0;
        private bool limitVelocityOnWallJump = false;

        [Header("Events")] [Space] public UnityEvent OnFallEvent;
        public UnityEvent OnLandEvent;

        private Collider2D[] checkColliders = new Collider2D[10];

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }

        public bool CanMove
        {
            get => canMove;
            set => canMove = value;
        }

        public bool CanDoubleJump
        {
            get => canDoubleJump;
            set => canDoubleJump = value;
        }

        public bool CanDash
        {
            get => canDash;
            set => canDash = value;
        }

        public bool CanSlide
        {
            get => canSlide;
            set => canSlide = value;
        }

        public bool IsGrounded => isGrounded;

        public Vector2 Velocity => rigidbody2D.velocity;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UpdateGroundedStatus();

            isWall = false;

            if (!isGrounded)
            {
                OnFallEvent.Invoke();
                var size1 = Physics2D.OverlapCircleNonAlloc(wallCheck.position, GroundedRadius, checkColliders,
                    groudLayerMask);
                for (int i = 0; i < size1; i++)
                {
                    if (checkColliders[i].gameObject != null)
                    {
                        isDashing = false;
                        isWall = true;
                    }
                }

                prevVelocityX = rigidbody2D.velocity.x;
            }

            if (limitVelocityOnWallJump)
            {
                if (rigidbody2D.velocity.y < -0.5f)
                    limitVelocityOnWallJump = false;
                jumpWallDistX = (jumpWallStartX - transform.position.x) * transform.localScale.x;
                if (jumpWallDistX < -0.5f && jumpWallDistX > -1f)
                {
                    canMove = true;
                }
                else if (jumpWallDistX < -1f && jumpWallDistX >= -2f)
                {
                    canMove = true;
                    rigidbody2D.velocity = new Vector2(10f * transform.localScale.x, rigidbody2D.velocity.y);
                }
                else if (jumpWallDistX < -2f)
                {
                    limitVelocityOnWallJump = false;
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                }
                else if (jumpWallDistX > 0)
                {
                    limitVelocityOnWallJump = false;
                    rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                }
            }
        }

        private void UpdateGroundedStatus()
        {
            bool wasGrounded = isGrounded;
            isGrounded = false;

            var size = Physics2D.OverlapCircleNonAlloc(groundCheck.position, GroundedRadius, checkColliders,
                groudLayerMask);
            for (int i = 0; i < size; i++)
            {
                if (checkColliders[i].transform.IsChildOf(transform))
                    continue;

                isGrounded = true;
                if (!wasGrounded)
                {
                    OnLandEvent.Invoke();
                    canDoubleJump = true;
                    if (rigidbody2D.velocity.y < 0f)
                        limitVelocityOnWallJump = false;
                }
            }
        }

        public void Move(float move, bool jump, bool dash)
        {
            if (!canMove) return;

            if (dash && canDash && !isWallSliding)
            {
                StartCoroutine(DashCooldown());
            }

            // If crouching, check to see if the character can stand up
            if (isDashing)
            {
                rigidbody2D.velocity = new Vector2(transform.localScale.x * m_DashForce, 0);
            }

            //only control the player if grounded or airControl is turned on
            else if (isGrounded || airControl)
            {
                if (rigidbody2D.velocity.y < -limitFallSpeed)
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -limitFallSpeed);
                // Move the character by finding the target velocity
                Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
                // And then smoothing it out and applying it to the character
                rigidbody2D.velocity = Vector3.SmoothDamp(
                    rigidbody2D.velocity,
                    targetVelocity,
                    ref velocity,
                    movementSmoothing);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !facingRight && !isWallSliding)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && facingRight && !isWallSliding)
                {
                    // ... flip the player.
                    Flip();
                }
            }

            // If the player should jump...
            if (isGrounded && jump)
            {
                // Add a vertical force to the player.
                isGrounded = false;
                rigidbody2D.AddForce(new Vector2(0f, jumpForce));
                canDoubleJump = true;
            }
            else if (!isGrounded && jump && canDoubleJump && !isWallSliding)
            {
                canDoubleJump = false;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                rigidbody2D.AddForce(new Vector2(0f, jumpForce / 1.2f));
            }

            else if (isWall && !isGrounded)
            {
                if (!wasWallSlidding && rigidbody2D.velocity.y < 0 || isDashing)
                {
                    isWallSliding = true;
                    wallCheck.localPosition =
                        new Vector3(-wallCheck.localPosition.x, wallCheck.localPosition.y, 0);
                    Flip();
                    StartCoroutine(WaitForDashCooldown(0.1f));
                    canDoubleJump = true;
                }

                isDashing = false;

                if (isWallSliding)
                {
                    if (move * transform.localScale.x > 0.1f)
                    {
                        StartCoroutine(WaitToEndSliding());
                    }
                    else
                    {
                        wasWallSlidding = true;
                        rigidbody2D.velocity = new Vector2(-transform.localScale.x * 2, -5);
                    }
                }

                if (jump && isWallSliding)
                {
                    rigidbody2D.velocity = new Vector2(0f, 0f);
                    rigidbody2D.AddForce(new Vector2(transform.localScale.x * jumpForce * 1.2f, jumpForce));
                    jumpWallStartX = transform.position.x;
                    limitVelocityOnWallJump = true;
                    canDoubleJump = true;
                    isWallSliding = false;
                    wasWallSlidding = false;
                    wallCheck.localPosition = new Vector3(Mathf.Abs(wallCheck.localPosition.x),
                        wallCheck.localPosition.y, 0);
                    canMove = false;
                }
                else if (dash && canDash)
                {
                    isWallSliding = false;
                    wasWallSlidding = false;
                    wallCheck.localPosition = new Vector3(Mathf.Abs(wallCheck.localPosition.x),
                        wallCheck.localPosition.y, 0);
                    canDoubleJump = true;
                    StartCoroutine(DashCooldown());
                }
            }
            else if (isWallSliding && !isWall && canSlide)
            {
                isWallSliding = false;
                wasWallSlidding = false;
                wallCheck.localPosition = new Vector3(Mathf.Abs(wallCheck.localPosition.x),
                    wallCheck.localPosition.y, 0);
                canDoubleJump = true;
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private IEnumerator DashCooldown()
        {
            isDashing = true;
            canDash = false;
            yield return new WaitForSeconds(0.1f);
            isDashing = false;
            yield return new WaitForSeconds(0.5f);
            canDash = true;
        }

        private IEnumerator Stun(float time)
        {
            canMove = false;
            yield return new WaitForSeconds(time);
            canMove = true;
        }

        private IEnumerator WaitForDashCooldown(float time)
        {
            canSlide = false;
            yield return new WaitForSeconds(time);
            canSlide = true;
        }

        private IEnumerator WaitToEndSliding()
        {
            yield return new WaitForSeconds(0.1f);
            canDoubleJump = true;
            isWallSliding = false;
            wasWallSlidding = false;
            wallCheck.localPosition =
                new Vector3(Mathf.Abs(wallCheck.localPosition.x), wallCheck.localPosition.y, 0);
        }
    }
}