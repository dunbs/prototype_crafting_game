using UnityEngine;

namespace CraftingGame
{
    public class UIInventoryItemSelectable : UIInventoryItem
    {
        [SerializeField] private DropDown dropDown;

        public override void SetItem(ItemBlueprint itemBlueprint, int count = 1)
        {
            base.SetItem(itemBlueprint, count);
            if (itemBlueprint.prefab is IEquipment)
            {
                button.onClick.AddListener(dropDown.Open);
            }
            else
            {
                button.onClick.RemoveListener(dropDown.Open);
            }
        }
    }
}