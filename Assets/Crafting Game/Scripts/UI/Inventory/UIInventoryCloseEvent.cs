using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/InventoryClose", fileName = "UIInventoryCloseEvent")]
    public sealed class UIInventoryCloseEvent : UICloseEvent { }
}