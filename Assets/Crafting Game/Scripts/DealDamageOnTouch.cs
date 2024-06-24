using System;
using UnityEngine;

namespace CraftingGame
{
    public class DealDamageOnTouch : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private string tag = "Player";
        [SerializeField] private bool useTrigger;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Component component = other.rigidbody ? other.rigidbody : other.collider;
            DealDamage(component);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            DealDamage(component);
        }

        private void DealDamage(Component component)
        {
            if (!string.IsNullOrWhiteSpace(tag) && !component.CompareTag(tag))
            {
                return;
            }

            IDamageable damageable = component.GetComponent<IDamageable>();

            if (damageable == null)
                return;

            damageable.DealDamage(gameObject, damage);
        }
    }
}