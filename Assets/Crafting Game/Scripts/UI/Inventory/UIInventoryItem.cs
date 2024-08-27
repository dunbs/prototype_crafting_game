using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingGame
{
    public class UIInventoryItem : MonoBehaviour
    {
        [SerializeField] protected Image icon;
        [SerializeField] protected TextMeshProUGUI txtName;
        [SerializeField] protected TextMeshProUGUI txtCount;
        [SerializeField] protected Button button;
        [SerializeField] protected Image selectedOutline;

        private ItemBlueprint itemBlueprint;
        private int count;

        public event System.Action<bool> OnSelected;

        public ItemBlueprint ItemBlueprint => itemBlueprint;

        private void Awake()
        {
            if (selectedOutline)
                selectedOutline.enabled = false;
        }

        public virtual void SetItem(ItemBlueprint itemBlueprint, int count = 1)
        {
            this.count = count;
            this.itemBlueprint = itemBlueprint;
            icon.sprite = itemBlueprint?.icon;
            icon.enabled = itemBlueprint is not null;
            txtName.text = itemBlueprint?.materialName ?? "Select a recipe";
            txtCount.text = count > 1 ? count.ToString() : "";
        }

        public void SetSelected(bool isSelected = true)
        {
            if (!selectedOutline) return;

            selectedOutline.enabled = isSelected;
            OnSelected?.Invoke(isSelected);
        }

        public void SetSelected_NoRaiseEvent(bool isSelected = true)
        {
            if (!selectedOutline) return;

            selectedOutline.enabled = isSelected;
        }
    }
}