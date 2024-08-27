namespace CraftingGame
{
    public interface IInteractable
    {
        public void TriggerInteractable();
        public void StopInteractable();

        public void Interact();

        public void StopInteraction();
    }
}