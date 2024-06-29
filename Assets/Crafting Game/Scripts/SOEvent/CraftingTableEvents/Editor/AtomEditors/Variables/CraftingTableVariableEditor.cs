using UnityEditor;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable Inspector of type `CraftingTable`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(CraftingTableVariable))]
    public sealed class CraftingTableVariableEditor : AtomVariableEditor<CraftingTable, CraftingTablePair> { }
}
