using UnityEngine;

namespace CraftingGame
{
    public abstract class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField] private UIInteractableIndicator interactableIndicator;

        private bool isInteractable;

        public bool IsInteractable => isInteractable;

        public void TriggerInteractable()
        {
            isInteractable = true;
            interactableIndicator.Open();
        }

        public void StopInteractable()
        {
            isInteractable = false;
            interactableIndicator.Close();
        }

        public abstract void Interact();
        public abstract void StopInteraction();
    }
}