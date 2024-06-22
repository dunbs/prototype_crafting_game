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

            public HealthChangedArgs(float before, float after, float changedAmount)
            {
                this.Before = before;
                this.After = after;
                this.ChangedAmount = changedAmount;
            }
        }

        float Health { get; }
        event Action<HealthChangedArgs> OnHealthChanged;
        void DealDamage(UnityEngine.GameObject attacker, float damage);
        void Heal(float amount);
        void Kill();
    }
}