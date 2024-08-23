using UnityEngine;

namespace CraftingGame
{
    public interface IEquipment
    {
        public GameObject gameObject { get; }
        public Transform transform { get; }

        public IEquipOwner Owner { get; }

        public void Equip(IEquipOwner owner);
    }
}