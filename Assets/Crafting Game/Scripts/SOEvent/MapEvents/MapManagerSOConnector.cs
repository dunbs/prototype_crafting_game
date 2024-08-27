using System;
using UnityAtoms.CraftingGame;
using UnityEngine;

namespace CraftingGame
{
    public class MapManagerSOConnector : MonoBehaviour
    {
        [SerializeField] private MapManagerVariable mapManagerVariable;

        private void Awake()
        {
            mapManagerVariable.Value = GetComponent<MapManager>();
        }
    }
}