using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    public class Weapon : Item, IEquipment
    {
        [SerializeField] private int damage = 1;

        [Header("Physics")] [SerializeField] private Collider2D[] attackColliders;
        [SerializeField] private Collider2D[] physicsColliders;
        [SerializeField] private new Rigidbody2D rb2D;

        [Header("Equipping")] [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int orderWhenEquipped = 1;
        private int orderWhenUnequipped;

        [Header("Animation Event String")] [SerializeField]
        private string onAttackAnimationEventString = "OnAttack";

        [SerializeField] private string onAttackFinishedAnimationEventString = "OnAttackFinished";

        public IEquipOwner Owner { get; protected set; }

        private void Awake()
        {
            orderWhenUnequipped = spriteRenderer.sortingOrder;
            OnAttackFinished();
        }

        public void Equip(IEquipOwner owner)
        {
            if (Owner != null)
            {
                Owner.AnimationEventTrigger.OnEventTrigger -= OnAnimationTriggered;
            }

            Owner = owner;
            IsPickedUp = true;
            transform.SetParent(Owner.EquipHolderTransform, false);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            spriteRenderer.sortingOrder = orderWhenEquipped;
            rb2D.isKinematic = true;
            Owner.AnimationEventTrigger.OnEventTrigger += OnAnimationTriggered;
            foreach (Collider2D physicsCollider in physicsColliders)
            {
                physicsCollider.enabled = false;
            }
        }

        private void OnAnimationTriggered(string eventName)
        {
            if (onAttackAnimationEventString.Equals(eventName))
            {
                OnAttack();
            }
            else if (onAttackFinishedAnimationEventString.Equals(eventName))
            {
                OnAttackFinished();
            }
        }

        private void OnAttack()
        {
            foreach (var collider in attackColliders)
            {
                collider.enabled = true;
            }
        }

        private void OnAttackFinished()
        {
            foreach (var collider in attackColliders)
            {
                collider.enabled = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            if (component.gameObject == Owner.gameObject) return;
            if (!component.TryGetComponent(out IDamageable damagable)) return;
            damagable.DealDamage(gameObject, damage);
        }
    }
}