using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CraftingGame
{
    public class Interactor : MonoBehaviour
    {
        private HashSet<IInteractable> interactables = new HashSet<IInteractable>();
        private IInteractable currentInteractable;
        private SimpleControls simpleControls;

        private void OnEnable()
        {
            simpleControls = new SimpleControls();
            simpleControls.Enable();
            simpleControls.gameplay.interact.performed += OnInteract;
        }

        private void OnDisable()
        {
            simpleControls = new SimpleControls();
            simpleControls.Disable();
            simpleControls.gameplay.interact.performed += OnInteract;
        }

        private void OnInteract(InputAction.CallbackContext obj)
        {
            currentInteractable?.Interact();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;

            if (!component.TryGetComponent<IInteractable>(out var interactable))
            {
                return;
            }

            if (interactables.Count == 0)
            {
                interactable.TriggerInteractable();
                currentInteractable = interactable;
            }

            interactables.Add(interactable);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;

            if (!component.TryGetComponent<IInteractable>(out var interactable))
            {
                return;
            }

            if (currentInteractable == interactable)
            {
                interactable.StopInteractable();
            }

            interactables.Remove(interactable);

            if (interactables.Count > 0)
            {
                currentInteractable = interactables.First();
                currentInteractable.TriggerInteractable();
            }
        }
    }
}