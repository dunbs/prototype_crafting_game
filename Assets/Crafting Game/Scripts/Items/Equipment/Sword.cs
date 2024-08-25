using UnityEngine;

namespace CraftingGame
{
    public class Sword : Weapon
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Tree"))
            {
                return;
            }

            base.OnTriggerEnter2D(other);
        }
    }
}