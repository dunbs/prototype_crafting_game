using System;
using UnityEngine.Events;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// None generic Unity Event of type `IDamageable`. Inherits from `UnityEvent&lt;IDamageable&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDamageableUnityEvent : UnityEvent<IDamageable> { }
}
