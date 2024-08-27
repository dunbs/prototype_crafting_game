using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/InventoryOpen", fileName = "UIInventoryOpenEvent")]
    public sealed class UIInventoryOpenEvent : UIOpenEvent { }
}