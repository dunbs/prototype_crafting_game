using System;
using System.Collections.Generic;
using System.Linq;
using UnityAtoms.CraftingGame;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingGame
{
    public class UICrafting : UICanvas
    {
        [SerializeField] private CraftingTableVariable craftingTableVariable;
        [SerializeField] private InventoryBaseVariable inventoryBaseVariable;
        [SerializeField] private UICraftingRecipeItem uiCraftingRecipeItemPrefab;
        [SerializeField] private UIInventoryItem result;
        [SerializeField] private Transform itemParent;

        [SerializeField] private Button btnCraft;

        private List<UICraftingRecipeItem> items = new();
        private Recipe currentSelectedRecipe;

        protected override void Awake()
        {
            base.Awake();
            btnCraft.onClick.AddListener(Craft);
        }

        private void Craft()
        {
            if (currentSelectedRecipe is null) return;

            foreach (ItemBlueprint itemBlueprint in currentSelectedRecipe.ItemBlueprints)
            {
                inventoryBaseVariable.Value.RemoveFromInventory(itemBlueprint);
                print($"Removed {itemBlueprint}");
            }

            inventoryBaseVariable.Value.AddToInventory(currentSelectedRecipe.Result);

            // Update the resources to match the updated inventory
            UpdateItems();
            UpdateButtonCraftState();
        }

        public override void Open()
        {
            currentSelectedRecipe = null;
            UpdateItems();
            result.SetItem(null);
            UpdateButtonCraftState();
            base.Open();
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
                item.OnSelected += OnItemSelected;
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

        private void OnItemSelected(UICraftingRecipeItem recipeItem)
        {
            result.SetItem(recipeItem.Recipe.Result);
            currentSelectedRecipe = recipeItem.Recipe;
            UpdateButtonCraftState();
        }

        private void UpdateButtonCraftState()
        {
            btnCraft.interactable = currentSelectedRecipe?.IsMoreThanEnough(inventoryBaseVariable.Value.Items) ?? false;
        }
    }
}