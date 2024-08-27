using System;
using UnityEngine;
using CraftingGame;
namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// IPair of type `&lt;InventoryBase&gt;`. Inherits from `IPair&lt;InventoryBase&gt;`.
    /// </summary>
    [Serializable]
    public struct InventoryBasePair : IPair<InventoryBase>
    {
        public InventoryBase Item1 { get => _item1; set => _item1 = value; }
        public InventoryBase Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private InventoryBase _item1;
        [SerializeField]
        private InventoryBase _item2;

        public void Deconstruct(out InventoryBase item1, out InventoryBase item2) { item1 = Item1; item2 = Item2; }
    }
}