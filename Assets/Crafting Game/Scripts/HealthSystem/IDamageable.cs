using System;
using UnityEngine;

namespace CraftingGame
{
    public interface IDamageable
    {
        public struct HealthChangedArgs
        {
            public readonly float Before;
            public readonly float After;
            public readonly float ChangedAmount;
            // TODO consider adding MaxHealth

            public HealthChangedArgs(float before, float after, float changedAmount)
            {
                this.Before = before;
                this.After = after;
                this.ChangedAmount = changedAmount;
            }
        }

        public struct DieArgs
        {
            public readonly GameObject attacker;
        }

        public GameObject gameObject { get; }

        float MaxHealth { get; }
        float Health { get; }
        event Action<HealthChangedArgs> OnHealthChanged;
        event Action<DieArgs> OnDead;
        void DealDamage(UnityEngine.GameObject attacker, float damage, bool useDieEffect = false);
        void Heal(float amount);
        void Kill();
    }
}