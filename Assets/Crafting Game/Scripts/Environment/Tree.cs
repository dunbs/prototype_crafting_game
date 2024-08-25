using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CraftingGame
{
    public class Tree : MonoBehaviour, IDamageable
    {
        [SerializeField] private ParticleSystem fxDie;
        [SerializeField] private Transform fxPosition;
        [SerializeField] private ItemBlueprint dropBlueprint;
        [SerializeField] private Vector2 dropAmountRange = new Vector2(1, 3);
        [field: SerializeField] public float MaxHealth { get; private set; }
        public float Health { get; private set; }
        public event Action<IDamageable.HealthChangedArgs> OnHealthChanged;
        public event Action<IDamageable.DieArgs> OnDead;

        private void OnEnable()
        {
            Health = MaxHealth;
        }

        public void DealDamage(GameObject attacker, float damage)
        {
            var previousHealth = Health;
            Health -= damage;
            OnHealthChanged?.Invoke(new IDamageable.HealthChangedArgs(previousHealth, Health, damage));

            if (Health <= 0)
            {
                Kill();
                return;
            }

            transform.DOKill();
            transform.DOShakeRotation(0.3f, new Vector3(0, 0, 4));
        }

        public void Heal(float amount)
        {
            var previousHealth = Health;
            Health += amount;
            OnHealthChanged?.Invoke(new IDamageable.HealthChangedArgs(previousHealth, Health, amount));
        }

        public void Kill()
        {
            Instantiate(fxDie, fxPosition.position, fxPosition.rotation);
            gameObject.SetActive(false);
            OnDead?.Invoke(new IDamageable.DieArgs());

            var dropPrefab = dropBlueprint.prefab;
            var amount = dropAmountRange.Random();
            for (int i = 0; i < amount; i++)
            {
                var drop = Instantiate(dropPrefab, fxPosition.position, Quaternion.identity);
                drop.Rigidbody2D.AddForce(new Vector2(Random.Range(-5f, 5f), Random.Range(1f, 5f)),
                    ForceMode2D.Impulse);
            }
        }
    }
}