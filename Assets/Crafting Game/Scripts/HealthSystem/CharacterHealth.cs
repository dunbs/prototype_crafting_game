using System;
using System.Collections;
using UnityEngine;

namespace CraftingGame
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private HealthChangedEffectorBase healthChangedEffectorBase;
        [SerializeField] private float invincibleCooldownTime = 0f;
        [field: SerializeField] public float Health { get; set; }

        public event Action<IDamageable.HealthChangedArgs> OnHealthChanged;
        public bool IsInvincible { get; set; }

        public virtual void DealDamage(GameObject attacker, float damage)
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
            healthChangedEffectorBase.DoHitEffect(damageDir);
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
        }
    }
}