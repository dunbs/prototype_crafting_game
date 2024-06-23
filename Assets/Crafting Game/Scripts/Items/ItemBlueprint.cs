using UnityEngine;

namespace CraftingGame
{
    [CreateAssetMenu(fileName = "Item Blueprint", menuName = "Crafting/Item Blueprint", order = 0)]
    public class ItemBlueprint : ScriptableObject
    {
        public Sprite icon;
        public string materialName;
        public Item prefab;
    }
}