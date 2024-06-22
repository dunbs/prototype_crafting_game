using UnityEngine;

namespace CraftingGame
{
    public abstract class HealthChangedEffectorBase : MonoBehaviour
    {
        public abstract void DoHitEffect(Vector3 hitDirection);
        public abstract void DoDieEffect();
        public abstract void DoHealEffect();
    }
}