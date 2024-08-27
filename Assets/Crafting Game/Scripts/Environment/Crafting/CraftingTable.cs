using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    public class CraftingTable : MonoBehaviour
    {
        [SerializeField] private Recipe[] recipes;
        // [SerializeField] private int slotCount;

        private ItemBlueprint[] itemBlueprints;

        public ItemBlueprint[] ItemBlueprints => itemBlueprints;
        public IReadOnlyList<Recipe> Recipes => recipes;
        // public int SlotCount => slotCount;

        private void Awake()
        {
            // itemBlueprints = new ItemBlueprint[slotCount];
        }

        public void SetSlot(int index, ItemBlueprint itemBlueprint)
        {
            itemBlueprints[index] = itemBlueprint;
        }

        public bool CanCraft(Recipe recipe)
        {
            return recipe.IsMatch(itemBlueprints);
        }

        public int GetMatchedRecipes(Recipe[] recipes)
        {
            int count = 0;
            foreach (Recipe e in this.recipes)
            {
                if (!e.IsCloseMatch(itemBlueprints)) continue;
                recipes[count++] = e;

                if (count >= recipes.Length) break;
            }

            return count;
        }
    }
}