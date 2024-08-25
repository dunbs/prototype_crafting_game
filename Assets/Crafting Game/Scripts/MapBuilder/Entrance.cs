using System;
using UnityAtoms.CraftingGame;
using UnityEngine;

namespace CraftingGame
{
    public class Entrance : MonoBehaviour
    {
        [SerializeField] private Transform playerPosition;
        [SerializeField] private MapConnection mapConnection;
        [SerializeField] private MapConnection targetMapConnection;
        [SerializeField] private MapManagerVariable mapManagerVariable;

        private MapManager mapManager;

        public Map Map { get; set; }

        public Transform PlayerPosition => playerPosition;

        public MapConnection MapConnection => mapConnection;

        private void OnEnable()
        {
            mapManagerVariable.Changed.Register(OnMapManagerEvent);
        }

        private void OnDisable()
        {
            mapManagerVariable.Changed.Unregister(OnMapManagerEvent);
        }

        private void OnMapManagerEvent(MapManager mapManager)
        {
            this.mapManager = mapManager;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Component component = other.attachedRigidbody ? other.attachedRigidbody : other;
            if (!component.CompareTag("Player"))
                return;

            mapManager.ChangeMap(targetMapConnection);
        }
    }
}