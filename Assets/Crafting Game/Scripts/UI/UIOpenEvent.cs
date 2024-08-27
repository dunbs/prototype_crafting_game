using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/UI/Open", fileName = "UICloseEvent")]
    public class UIOpenEvent : AtomEvent<Void>
    {
        public override void Raise()
        {
            Raise(new Void());
        }
    }
}