using System;
using UnityEngine;

namespace CraftingGame
{
    public class DealDamageOnLargeVelocity : MonoBehaviour
    {
        [SerializeField] private float damage = 5;
        [SerializeField] private float minimumForce = 35;
        [SerializeField] private Rigidbody2D rigidbody2D;

        private void Reset()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (!collision2D.rigidbody) return;

            var damageable = collision2D.rigidbody.GetComponent<IDamageable>();
            if (damageable == null) return;

            float sqrMagnitude = rigidbody2D.velocity.SqrMagnitude() *
                                 rigidbody2D.mass * rigidbody2D.mass;
            if (sqrMagnitude > minimumForce * minimumForce)
            {
                damageable.DealDamage(collision2D.gameObject,
                    damage * (sqrMagnitude / (minimumForce * minimumForce)));
            }
        }
    }
}