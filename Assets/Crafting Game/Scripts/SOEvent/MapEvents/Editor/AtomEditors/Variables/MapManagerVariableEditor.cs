using UnityEditor;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable Inspector of type `MapManager`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(MapManagerVariable))]
    public sealed class MapManagerVariableEditor : AtomVariableEditor<MapManager, MapManagerPair> { }
}
