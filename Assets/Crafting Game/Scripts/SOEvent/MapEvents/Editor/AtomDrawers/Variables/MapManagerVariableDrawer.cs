#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Variable property drawer of type `MapManager`. Inherits from `AtomDrawer&lt;MapManagerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(MapManagerVariable))]
    public class MapManagerVariableDrawer : VariableDrawer<MapManagerVariable> { }
}
#endif
