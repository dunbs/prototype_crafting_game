using UnityEngine;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// Event of type `IDamageable`. Inherits from `AtomEvent&lt;IDamageable&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/IDamageable", fileName = "IDamageableEvent")]
    public sealed class IDamageableEvent : AtomEvent<IDamageable>
    {
    }
}
