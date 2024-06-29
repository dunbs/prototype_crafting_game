using UnityAtoms.CraftingGame;
using UnityEngine;
using System.Linq;

namespace CraftingGame
{
    public class UICraftingRecipeMaterialItem : UIInventoryItem
    {
        [SerializeField] private InventoryBaseVariable inventoryBaseVariable;

        public override void SetItem(ItemBlueprint itemBlueprint, int count)
        {
            base.SetItem(itemBlueprint, count);
            var itemCount = inventoryBaseVariable.Value.Items.Count(itemBlueprint.Equals);
            txtCount.text = $"{itemCount} / {count}";
            txtCount.color = itemCount >= count ? Color.white : Color.red;
        }
    }
}