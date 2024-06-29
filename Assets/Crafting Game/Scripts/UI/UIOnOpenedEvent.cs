using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/OnOpened", fileName = "UIOnOpenedEvent")]
    public class UIOnOpenedEvent : AtomEvent<Void>
    {
        public override void Raise()
        {
            Raise(new Void());
        }
    }
}