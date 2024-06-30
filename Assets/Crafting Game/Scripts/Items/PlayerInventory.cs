using System;
using System.Linq;

namespace CraftingGame
{
    public class PlayerInventory : Inventory
    {
        private void Awake()
        {
            var data = SaveSystem.Inventory.Load();
            if (data.itemBlueprints != null) AddRange(data.itemBlueprints);
            EquippedIndex = data.equipped;
        }

        public override void AddToInventory(ItemBlueprint item)
        {
            base.AddToInventory(item);


            SaveSystem.Inventory.Save(new SaveSystem.Inventory.Data()
            {
                itemBlueprints =
                    Items.ToList(), // Changing the list to protected | Try casting | maybe the linq system has already performed the optimal check
                equipped = EquippedIndex
            });
        }

        public override void RemoveFromInventory(ItemBlueprint item)
        {
            base.RemoveFromInventory(item);
            SaveSystem.Inventory.Save(new SaveSystem.Inventory.Data()
            {
                itemBlueprints =
                    Items.ToList(), // Changing the list to protected | Try casting | maybe the linq system has already performed the optimal check
                equipped = EquippedIndex
            });
        }

        public override void SetEquipped(int index)
        {
            base.SetEquipped(index);
            SaveSystem.Inventory.Save(new SaveSystem.Inventory.Data()
            {
                itemBlueprints =
                    Items.ToList(), // Changing the list to protected | Try casting | maybe the linq system has already performed the optimal check
                equipped = EquippedIndex
            });
        }
    }
}