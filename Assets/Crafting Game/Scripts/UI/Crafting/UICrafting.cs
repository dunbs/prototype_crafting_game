using System;
using System.Collections.Generic;
using System.Linq;
using UnityAtoms.CraftingGame;
using UnityEngine;

namespace CraftingGame
{
    public class UICrafting : UICanvas
    {
        [SerializeField] private CraftingTableVariable craftingTableVariable;
        [SerializeField] private InventoryBaseVariable inventoryBaseVariable;
        [SerializeField] private UICraftingRecipeItem uiCraftingRecipeItemPrefab;
        [SerializeField] private Transform itemParent;

        private List<UICraftingRecipeItem> items = new();

        public override void Open()
        {
            base.Open();
            UpdateItems();
        }

        private void UpdateItems()
        {
            var craftingTable = craftingTableVariable.Value;
            var inventory = inventoryBaseVariable.Value;

            var recipes = craftingTable.Recipes
                .OrderBy(recipe => recipe.CountMissingItems(inventory.Items))
                .ToArray();

            UpdateMaxItems(recipes.Length);
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                item.SetRecipe(recipes[i]);
            }
        }

        private void UpdateMaxItems(int count)
        {
            if (count == items.Count)
            {
                return;
            }

            for (int i = items.Count; i < count; i++)
            {
                var item = Instantiate(uiCraftingRecipeItemPrefab, itemParent);
                item.transform.SetAsLastSibling();
                items.Add(item);
            }

            for (int i = items.Count; i > count; i--)
            {
                var item = items[i];
                items.RemoveAt(i);
                Destroy(item);
            }
        }
    }
}