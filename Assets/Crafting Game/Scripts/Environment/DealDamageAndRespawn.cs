using DG.Tweening;
using UnityAtoms;
using UnityAtoms.CraftingGame;
using UnityEngine;

namespace CraftingGame
{
    public class DealDamageAndRespawn : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private string tag = "Player";
        [SerializeField] private bool useTrigger;
        [SerializeField] private MapManagerVariable mapManagerVariable;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Component component = other.rigidbody ? other.rigidbody : other.collider;
            if (component.gameObject != other.gameObject) return;
            DealDamage(component);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            if (component.gameObject != other.gameObject) return;
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

            damageable.DealDamage(gameObject, damage, true);

            if (damageable.Health > 0)
                DOVirtual.DelayedCall(0.7f, mapManagerVariable.Value.RespawnCharacter);
        }
    }
}