using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// Event Instancer of type `CraftingTablePair`. Inherits from `AtomEventInstancer&lt;CraftingTablePair, CraftingTablePairEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/CraftingTablePair Event Instancer")]
    public class CraftingTablePairEventInstancer : AtomEventInstancer<CraftingTablePair, CraftingTablePairEvent> { }
}
