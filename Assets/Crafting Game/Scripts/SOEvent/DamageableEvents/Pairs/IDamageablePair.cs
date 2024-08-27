using System;
using UnityEngine;
using CraftingGame;
namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// IPair of type `&lt;IDamageable&gt;`. Inherits from `IPair&lt;IDamageable&gt;`.
    /// </summary>
    [Serializable]
    public struct IDamageablePair : IPair<IDamageable>
    {
        public IDamageable Item1 { get => _item1; set => _item1 = value; }
        public IDamageable Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private IDamageable _item1;
        [SerializeField]
        private IDamageable _item2;

        public void Deconstruct(out IDamageable item1, out IDamageable item2) { item1 = Item1; item2 = Item2; }
    }
}