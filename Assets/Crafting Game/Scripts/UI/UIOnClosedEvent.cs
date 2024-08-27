using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/OnClosed", fileName = "UIOnClosedEvent")]
    public class UIOnClosedEvent : AtomEvent<Void>
    {
        public override void Raise()
        {
            Raise(new Void());
        }
    }
}