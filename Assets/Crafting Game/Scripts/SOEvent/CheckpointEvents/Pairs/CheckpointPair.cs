using System;
using UnityEngine;
using CraftingGame;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;Checkpoint&gt;`. Inherits from `IPair&lt;Checkpoint&gt;`.
    /// </summary>
    [Serializable]
    public struct CheckpointPair : IPair<Checkpoint>
    {
        public Checkpoint Item1 { get => _item1; set => _item1 = value; }
        public Checkpoint Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private Checkpoint _item1;
        [SerializeField]
        private Checkpoint _item2;

        public void Deconstruct(out Checkpoint item1, out Checkpoint item2) { item1 = Item1; item2 = Item2; }
    }
}