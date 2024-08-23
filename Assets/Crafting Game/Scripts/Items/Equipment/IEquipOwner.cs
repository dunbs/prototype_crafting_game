using UnityEngine;

namespace CraftingGame
{
    public interface IEquipOwner
    {
        public GameObject gameObject { get; }
        public Transform EquipHolderTransform { get; }
        public AnimationEventTrigger AnimationEventTrigger { get; }
    }
}