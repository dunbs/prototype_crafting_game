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

            Refresh();
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