﻿using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    public class Weapon : Item, IEquipment
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private int durability = 3;

        [Header("Physics")] [SerializeField] private Collider2D[] attackColliders;
        [SerializeField] private Collider2D[] physicsColliders;
        [SerializeField] private new Rigidbody2D rb2D;

        [Header("Equipping")] [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int orderWhenEquipped = 1;
        private int orderWhenUnequipped;
        [SerializeField] private AnimationClip attackAnimationClip;

        [Header("Animation Event String")] [SerializeField]
        private string onAttackAnimationEventString = "OnAttack";

        [SerializeField] private string onAttackFinishedAnimationEventString = "OnAttackFinished";

        private int durabilityLeft = 0;

        public AnimationClip AttackAnimationClip => attackAnimationClip;
        public event Action<IEquipment> OnBroke;
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
            Owner.AnimatorOverrideController["Sword_Attack"] = attackAnimationClip;

            foreach (Collider2D physicsCollider in physicsColliders)
            {
                physicsCollider.enabled = false;
            }
        }

        private void OnEnable()
        {
            durabilityLeft = durability;

            if (!Owner.IsUnityNull())
            {
                Owner.AnimationEventTrigger.OnEventTrigger += OnAnimationTriggered;
            }
        }

        private void OnDisable()
        {
            Owner.AnimationEventTrigger.OnEventTrigger -= OnAnimationTriggered;
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

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            if (component.gameObject == Owner.gameObject) return;
            if (!component.TryGetComponent(out IDamageable damagable)) return;
            damagable.DealDamage(gameObject, damage);
            durabilityLeft--;

            if (durabilityLeft <= 0)
            {
                OnBroke?.Invoke(this);
                Destroy(gameObject);
            }
        }
    }
}