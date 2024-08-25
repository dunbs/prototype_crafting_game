using System;
using UnityEngine;

namespace CraftingGame
{
    public interface IEquipment
    {
        public event Action<IEquipment> OnBroke;

        public ItemBlueprint ItemBlueprint { get; }
        public GameObject gameObject { get; }
        public Transform transform { get; }

        public IEquipOwner Owner { get; }

        public void Equip(IEquipOwner owner);
    }
}