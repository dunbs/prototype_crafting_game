#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.CraftingGame.Editor
{
    /// <summary>
    /// Value List property drawer of type `MapManager`. Inherits from `AtomDrawer&lt;MapManagerValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(MapManagerValueList))]
    public class MapManagerValueListDrawer : AtomDrawer<MapManagerValueList> { }
}
#endif
