using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event Instancer of type `MapManagerPair`. Inherits from `AtomEventInstancer&lt;MapManagerPair, MapManagerPairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/MapManagerPair Event Instancer")]
    public class MapManagerPairEventInstancer : AtomEventInstancer<MapManagerPair, MapManagerPairEvent> { }
}
