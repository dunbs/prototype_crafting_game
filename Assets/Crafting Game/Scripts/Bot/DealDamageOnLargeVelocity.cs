using System;
using System.Collections;
using UnityEngine;

namespace CraftingGame
{
    public class DealDamageOnLargeVelocity : MonoBehaviour
    {
        [SerializeField] private float damage = 5;
        [SerializeField] private float minimumForce = 35;
        [SerializeField] private Rigidbody2D rigidbody2D;

        private Vector2 lastKnownVelocity;

        private void Reset()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(RecordVelocityCoroutine());
        }

        private IEnumerator RecordVelocityCoroutine()
        {
            var untilFixedUpdate = new WaitForFixedUpdate();
            while (true)
            {
                yield return untilFixedUpdate;
                lastKnownVelocity = rigidbody2D.velocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (!collision2D.rigidbody) return;

            var damageable = collision2D.rigidbody.GetComponent<IDamageable>();
            if (damageable == null) return;

            float sqrMagnitude = lastKnownVelocity.SqrMagnitude() *
                                 rigidbody2D.mass * rigidbody2D.mass;

            var dir = collision2D.collider.transform.position - transform.position;
            var dots = Vector2.Dot(dir, lastKnownVelocity);
            var isThisObjectHitting = dots > 0.1f;

            // Debug.DrawRay(rigidbody2D.position, -collision2D.relativeVelocity.normalized * 10, Color.green);
            // Debug.DrawRay(rigidbody2D.position, lastKnownVelocity.normalized * 10, Color.magenta);
            // Debug.DrawRay(rigidbody2D.position, rigidbody2D.velocity.normalized * 10, Color.red);
            // Debug.DrawRay(rigidbody2D.position, dir * 10, Color.white);

            if (sqrMagnitude > minimumForce * minimumForce && isThisObjectHitting)
            {
                damageable.DealDamage(collision2D.gameObject,
                    damage * (sqrMagnitude / (minimumForce * minimumForce)));
            }
        }
    }
}