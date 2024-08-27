using System;
using UnityEngine.Events;
using CraftingGame;

namespace UnityAtoms.CraftingGame
{
    /// <summary>
    /// None generic Unity Event of type `InventoryBase`. Inherits from `UnityEvent&lt;InventoryBase&gt;`.
    /// </summary>
    [Serializable]
    public sealed class InventoryBaseUnityEvent : UnityEvent<InventoryBase> { }
}
