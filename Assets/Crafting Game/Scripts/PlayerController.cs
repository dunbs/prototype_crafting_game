using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CraftingGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController2D characterController2D;
        [SerializeField] private Animator animator;
        [SerializeField] private float runSpeed;

        private SimpleControls simpleControls;

        private SimpleControls.GameplayActions gameplayActions;

        private float horizontalMovement;
        private bool jump;
        private bool dash;
        private static readonly int IsGroundedHashed = Animator.StringToHash("IsGrounded");
        private static readonly int SpeedHashed = Animator.StringToHash("Speed");
        private static readonly int VSpeedHashed = Animator.StringToHash("vSpeed");

        private void Awake()
        {
            simpleControls = new SimpleControls();
            gameplayActions = simpleControls.gameplay;
            gameplayActions.Jump.performed += _ => jump = true;
            gameplayActions.dash.performed += _ => dash = true;
        }

        private void OnEnable()
        {
            simpleControls.Enable();
        }

        private void OnDisable()
        {
            simpleControls.Disable();
        }

        private void Update()
        {
            horizontalMovement += gameplayActions.move.ReadValue<Vector2>().x * runSpeed * Time.deltaTime;
            animator.SetBool(IsGroundedHashed, characterController2D.IsGrounded);
            animator.SetFloat(SpeedHashed, Mathf.Abs(characterController2D.Velocity.x));
            animator.SetFloat(VSpeedHashed, characterController2D.Velocity.y);
        }

        private void FixedUpdate()
        {
            characterController2D.Move(horizontalMovement, jump, dash);
            horizontalMovement = 0;
            jump = dash = false;
        }
    }
}