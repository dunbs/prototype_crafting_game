using UnityEditor;
using UnityAtoms.Editor;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents.Editor
{
    /// <summary>
    /// Variable Inspector of type `IDamageable`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(IDamageableVariable))]
    public sealed class IDamageableVariableEditor : AtomVariableEditor<IDamageable, IDamageablePair> { }
}
