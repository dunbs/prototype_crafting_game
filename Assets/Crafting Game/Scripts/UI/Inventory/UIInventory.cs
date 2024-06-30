using System.Collections.Generic;
using System.Linq;
using UnityAtoms.CraftingGame;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CraftingGame
{
    public class UIInventory : UICanvas
    {
        [SerializeField] private UIInventoryItem itemPrefab;
        [SerializeField] private Transform itemParent;
        [SerializeField] private InventoryBaseVariable inventoryBaseVariable;

        private InventoryBase inventory;
        private List<UIInventoryItem> inventoryItems = new();
        private int equipped;

        protected override void Awake()
        {
            SimpleControls simpleControls = new SimpleControls();
            simpleControls.Enable();
            simpleControls.gameplay.Inventory.performed += InteractOnPerformed;
            inventoryBaseVariable.Changed.Register(OnInventoryVariableChanged);
            base.Awake();
        }

        private void InteractOnPerformed(InputAction.CallbackContext callback)
        {
            Open();
        }

        private void OnInventoryVariableChanged(InventoryBase inventoryBase)
        {
            if (inventory)
            {
                inventory.OnItemAdded -= OnItemAdded;
                inventory.OnItemRemoved -= OnItemRemoved;
            }

            inventory = inventoryBase;
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemRemoved += OnItemRemoved;
            inventory.OnItemEquipped += OnItemEquipped;

            Refresh();
        }

        private void OnItemEquipped(InventoryBase.EquippedEventArgs equippedEventArgs)
        {
            if (equippedEventArgs.index >= 0)
            {
                for (var i = 0; i < inventoryItems.Count; i++)
                {
                    inventoryItems[i].SetSelected_NoRaiseEvent(equippedEventArgs.index == i);
                }
            }
        }

        private void OnItemAdded(ItemBlueprint itemBlueprint)
        {
            // TODO Can be optimized
            Refresh();
        }

        private void OnItemRemoved(ItemBlueprint itemBlueprint)
        {
            // TODO Can be optimized
            Refresh();
        }

        public void Refresh()
        {
            UpdateMaxItems();

            var items = inventory.Items;

            for (var i = 0; i < inventoryItems.Count; i++)
            {
                var item = inventoryItems[i];
                var blueprint = items[i];
                item.SetItem(blueprint, 1);
            }

            if (inventory.EquippedIndex >= 0)
            {
                inventoryItems[inventory.EquippedIndex].SetSelected(true);
            }
        }

        private void UpdateMaxItems()
        {
            int count = Mathf.RoundToInt(inventory.Items.Count);
            if (count == inventoryItems.Count)
            {
                return;
            }

            for (int i = inventoryItems.Count; i < count; i++)
            {
                var item = Instantiate(itemPrefab, itemParent);
                int inventoryIndex = i;
                item.OnSelected += selected =>
                {
                    if (selected)
                    {
                        foreach (UIInventoryItem uiInventoryItem in inventoryItems)
                        {
                            if (uiInventoryItem != item)
                                uiInventoryItem.SetSelected(false);
                        }
                    }

                    inventoryBaseVariable.Value.SetEquipped(selected
                        ? inventoryIndex
                        : -1); // Should have passed a boolean or use another function, but I am pressured with time
                };
                item.transform.SetAsLastSibling();
                inventoryItems.Add(item);
            }

            for (int i = inventoryItems.Count - 1; i >= count; i--)
            {
                var item = inventoryItems[i];
                inventoryItems.RemoveAt(i);
                Destroy(item.gameObject);
            }
        }
    }
}