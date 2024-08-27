using UnityAtoms.CraftingGame.AtomEvents;
using UnityEngine;

namespace CraftingGame
{
    public class DamageableSOConnector : MonoBehaviour
    {
        [SerializeField] private IDamageableVariable damageableVariable;

        private void Awake()
        {
            damageableVariable.Value = GetComponent<IDamageable>();
        }
    }
}