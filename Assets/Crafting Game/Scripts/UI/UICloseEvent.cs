using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/Close", fileName = "UICloseEvent")]
    public class UICloseEvent : AtomEvent<Void>
    {
        public override void Raise()
        {
            Raise(new Void());
        }
    }
}