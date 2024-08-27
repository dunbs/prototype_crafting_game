using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingGame
{
    public class UICraftingRecipeItem : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem itemPrefab;
        [SerializeField] private Transform itemParent;
        [SerializeField] private UIInventoryItem result;
        [SerializeField] private Button button;

        private List<UIInventoryItem> items = new();

        private Recipe recipe;

        public Recipe Recipe => recipe;

        public event Action<UICraftingRecipeItem> OnSelected;

        private void Awake()
        {
            button.onClick.AddListener(() => OnSelected?.Invoke(this));
        }

        public void SetRecipe(Recipe recipe)
        {
            this.recipe = recipe;

            result.SetItem(recipe.Result, 1);

            UpdateMaxItems(recipe.ItemBlueprintDict.Count);
            int index = 0;
            foreach ((ItemBlueprint item, int itemCount) in recipe.ItemBlueprintDict)
            {
                items[index].SetItem(item, itemCount);
                index++;
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
                var item = Instantiate(itemPrefab, itemParent);
                item.transform.SetAsLastSibling();
                items.Add(item);
            }

            for (int i = items.Count - 1; i >= count; i--)
            {
                var item = items[i];
                items.RemoveAt(i);
                Destroy(item.gameObject);
            }
        }
    }
}