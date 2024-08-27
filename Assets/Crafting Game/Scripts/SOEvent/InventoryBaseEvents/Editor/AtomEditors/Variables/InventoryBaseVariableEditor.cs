using UnityEditor;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable Inspector of type `InventoryBase`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(InventoryBaseVariable))]
    public sealed class InventoryBaseVariableEditor : AtomVariableEditor<InventoryBase, InventoryBasePair> { }
}
