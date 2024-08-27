using System;
using UnityEngine;

namespace CraftingGame
{
    public class ItemPicker : MonoBehaviour
    {
        [SerializeField] private InventoryBase inventory;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            if (component.TryGetComponent<ItemBase>(out var item) && item.GetPickedUp())
            {
                inventory.AddToInventory(item.ItemBlueprint);
            }
        }
    }
}