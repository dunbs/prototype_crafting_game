using System;
using UnityAtoms.CraftingGame;
using UnityEngine;

namespace CraftingGame
{
    public class InventoryBaseSOConnector : MonoBehaviour
    {
        [SerializeField] private InventoryBaseVariable inventoryBaseVariable;

        private void Awake()
        {
            inventoryBaseVariable.Value = GetComponent<InventoryBase>();
        }
    }
}