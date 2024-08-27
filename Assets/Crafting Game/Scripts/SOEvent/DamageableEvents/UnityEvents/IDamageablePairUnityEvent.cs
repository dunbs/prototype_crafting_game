using System;
using UnityEngine.Events;
using CraftingGame;

namespace UnityAtoms.CraftingGame.AtomEvents
{
    /// <summary>
    /// None generic Unity Event of type `IDamageablePair`. Inherits from `UnityEvent&lt;IDamageablePair&gt;`.
    /// </summary>
    [Serializable]
    public sealed class IDamageablePairUnityEvent : UnityEvent<IDamageablePair> { }
}
