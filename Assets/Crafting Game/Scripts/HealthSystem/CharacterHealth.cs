using System;
using System.Collections;
using UnityEngine;

namespace CraftingGame
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthChangedEffectorBase healthChangedEffectorBase;
        [SerializeField] private float invincibleCooldownTime = 0f;
        [field: SerializeField] public float MaxHealth { get; set; } = 1;

        public event Action<IDamageable.HealthChangedArgs> OnHealthChanged;
        public event Action<IDamageable.DieArgs> OnDead;
        public bool IsInvincible { get; set; }
        public float Health { get; set; }

        private void Awake()
        {
            OnHealthChanged?.Invoke(new IDamageable.HealthChangedArgs(before: 0, after: Health, Health));
        }

        private void OnEnable()
        {
            IsInvincible = false;

            if (Health > 0) return;
            Health = MaxHealth;
        }

        public virtual void DealDamage(GameObject attacker, float damage, bool useDieEffect = false)
        {
            if (IsInvincible)
                return;

            float healthBefore = Health;

            if (Health <= damage)
            {
                Health = 0;
                Kill();
            }
            else
            {
                Health -= damage;
            }

            Vector2 damageDir = Vector3.Normalize(transform.position - attacker.transform.position).normalized;
            if (!useDieEffect)
            {
                healthChangedEffectorBase.DoHitEffect(damageDir);
            }
            else
            {
                healthChangedEffectorBase.DoDieEffect();
            }

            StartCoroutine(InvincibleCooldown());

            OnHealthChanged?.Invoke(new IDamageable.HealthChangedArgs(healthBefore, Health, damage));
            return;

            IEnumerator InvincibleCooldown()
            {
                IsInvincible = true;
                yield return new WaitForSeconds(invincibleCooldownTime);
                IsInvincible = false;
            }
        }

        public virtual void Heal(float amount)
        {
            float healthBefore = Health;
            Health += amount;
            healthChangedEffectorBase.DoHealEffect();
            OnHealthChanged?.Invoke(new IDamageable.HealthChangedArgs(healthBefore, Health, amount));
        }

        public virtual void Kill()
        {
            healthChangedEffectorBase.DoDieEffect();
            //TODO No attacker right now, but so far that's all we need, gonna add this when I have time.
            OnDead?.Invoke(new IDamageable.DieArgs());
        }
    }
}