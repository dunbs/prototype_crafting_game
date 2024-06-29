using System;
using UnityEngine;
using CraftingGame;
namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// IPair of type `&lt;CraftingTable&gt;`. Inherits from `IPair&lt;CraftingTable&gt;`.
    /// </summary>
    [Serializable]
    public struct CraftingTablePair : IPair<CraftingTable>
    {
        public CraftingTable Item1 { get => _item1; set => _item1 = value; }
        public CraftingTable Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private CraftingTable _item1;
        [SerializeField]
        private CraftingTable _item2;

        public void Deconstruct(out CraftingTable item1, out CraftingTable item2) { item1 = Item1; item2 = Item2; }
    }
}