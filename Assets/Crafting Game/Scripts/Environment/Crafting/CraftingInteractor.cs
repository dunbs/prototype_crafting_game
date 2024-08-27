using System;
using UnityAtoms.CraftingGame;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    public class CraftingInteractor : InteractableBase
    {
        [SerializeField] private CraftingTable craftingTable;
        [SerializeField] private CraftingTableVariable craftingTableVariable;
        [SerializeField] private UICraftingOpenEvent uiCraftingOpenEvent;

        [FormerlySerializedAs("onClosedEvent")] [SerializeField]
        private UIOnClosedEvent onUIClosedEvent;

        private bool isInteracting;

        private void Reset()
        {
            craftingTable = GetComponent<CraftingTable>();
        }

        private void OnEnable()
        {
            onUIClosedEvent.Register(OnUIClosed);
        }

        private void OnDisable()
        {
            onUIClosedEvent.Unregister(OnUIClosed);
        }

        private void OnUIClosed()
        {
            if (isInteracting)
            {
                StopInteraction();
            }
        }

        public override void Interact()
        {
            if (!IsInteractable) return;

            craftingTableVariable.Value = craftingTable;
            uiCraftingOpenEvent.Raise();
            isInteracting = true;
        }

        public override void StopInteraction()
        {
            isInteracting = false;
        }
    }
}