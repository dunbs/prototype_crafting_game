using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : ItemBase
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private ParticleSystem particleSystem;

        [FormerlySerializedAs("bluePrint")] [SerializeField]
        private ItemBlueprint blueprint;

        public override ItemBlueprint ItemBlueprint => blueprint;

        public override Rigidbody2D Rigidbody2D
        {
            get => rigidbody2D;
            protected set => rigidbody2D = value;
        }

        private void Reset()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public override void GetPickedUp()
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}