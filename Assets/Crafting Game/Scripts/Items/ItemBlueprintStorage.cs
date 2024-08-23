using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    [CreateAssetMenu(menuName = "Crafting/Item Blueprint Storage", fileName = "Item Blueprint Storage")]
    public class ItemBlueprintStorage : ScriptableObject
    {
        [SerializeField] private ItemBlueprint[] allItemBlueprints;

        public IReadOnlyList<ItemBlueprint> AllItemBlueprints => allItemBlueprints;

        public ItemBlueprint GetItemWithId(string id)
        {
            return AllItemBlueprints.SingleOrDefault(e => e.id.Equals(id));
        }
    }
}