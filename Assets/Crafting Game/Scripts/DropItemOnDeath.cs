using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace CraftingGame
{
    public class DropItemOnDeath : MonoBehaviour
    {
        [FormerlySerializedAs("itemBluePrint")] [SerializeField] private ItemBlueprint itemBlueprint;

        private IDamageable damageable;

        private void Awake()
        {
            damageable = GetComponent<IDamageable>();
            Assert.IsNotNull(damageable);
            damageable.OnDead += OnDead;
        }

        private void OnDestroy()
        {
            damageable.OnDead -= OnDead;
        }

        private void OnDead(IDamageable.DieArgs obj)
        {
            var item = Instantiate(itemBlueprint.prefab, transform.position, transform.rotation);
            item.Rigidbody2D.AddForce(new Vector2(Random.value, 1) * Random.Range(2, 7), ForceMode2D.Impulse);
        }
    }
}