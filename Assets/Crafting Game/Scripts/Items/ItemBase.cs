using UnityEngine;

namespace CraftingGame
{
    public abstract class ItemBase : MonoBehaviour
    {
        public abstract ItemBlueprint ItemBlueprint { get; }
        public abstract Rigidbody2D Rigidbody2D { get; protected set; }

        public abstract void GetPickedUp();
    }
}