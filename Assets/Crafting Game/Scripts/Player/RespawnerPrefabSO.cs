using UnityEngine;

namespace CraftingGame
{
    [CreateAssetMenu(fileName = "Respawner", menuName = "Crafting/Respawner", order = 0)]
    public class RespawnerPrefabSO : ScriptableObject
    {
        public Respawner respawner;
    }
}