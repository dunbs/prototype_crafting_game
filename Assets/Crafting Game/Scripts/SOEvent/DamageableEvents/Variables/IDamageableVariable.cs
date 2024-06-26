using UnityEngine;
using System;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// Variable of type `IDamageable`. Inherits from `AtomVariable&lt;IDamageable, IDamageablePair, IDamageableEvent, IDamageablePairEvent, IDamageableIDamageableFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/IDamageable", fileName = "IDamageableVariable")]
    public sealed class IDamageableVariable : AtomVariable<IDamageable, IDamageablePair, IDamageableEvent,
        IDamageablePairEvent, IDamageableIDamageableFunction>
    {
        protected override bool ValueEquals(IDamageable other)
        {
            return object.ReferenceEquals(other, Value);
        }
    }
}