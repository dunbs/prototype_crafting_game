using System;
using UnityEngine;
using CraftingGame;
namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// IPair of type `&lt;MapManager&gt;`. Inherits from `IPair&lt;MapManager&gt;`.
    /// </summary>
    [Serializable]
    public struct MapManagerPair : IPair<MapManager>
    {
        public MapManager Item1 { get => _item1; set => _item1 = value; }
        public MapManager Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private MapManager _item1;
        [SerializeField]
        private MapManager _item2;

        public void Deconstruct(out MapManager item1, out MapManager item2) { item1 = Item1; item2 = Item2; }
    }
}