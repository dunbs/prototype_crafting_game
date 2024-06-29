using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingGame
{
    public class UIInventoryItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI txtName;
        [SerializeField] private Button button;
        [SerializeField] private Image selectedOutline;

        private ItemBlueprint itemBlueprint;

        public ItemBlueprint ItemBlueprint => itemBlueprint;

        public void SetItem(ItemBlueprint itemBlueprint)
        {
            this.itemBlueprint = itemBlueprint;
            icon.sprite = itemBlueprint.icon;
            txtName.text = itemBlueprint.materialName;
        }

        public void SetSelected(bool isSelected = true)
        {
            selectedOutline.enabled = isSelected;
        }
    }
}