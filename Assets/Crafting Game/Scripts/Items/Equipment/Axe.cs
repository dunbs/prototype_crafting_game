using UnityEngine;

namespace CraftingGame
{
    public class Axe : Weapon
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Tree"))
            {
                return;
            }

            Debug.LogError(other, other);

            base.OnTriggerEnter2D(other);
        }
    }
}