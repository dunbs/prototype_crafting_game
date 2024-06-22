using System;
using UnityEngine;

namespace CraftingGame
{
    public class DealDamageOnTouch : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnCollisionEnter2D(Collision2D other)
        {
            IDamageable damageable = other.rigidbody
                ? other.rigidbody.GetComponent<IDamageable>()
                : other.collider.GetComponent<IDamageable>();

            if (damageable == null)
                return;

            damageable.DealDamage(gameObject, damage);
        }
    }
}