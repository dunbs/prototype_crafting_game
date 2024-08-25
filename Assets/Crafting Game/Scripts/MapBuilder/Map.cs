using System;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Collider2D confiner;

        private MapConnection[] mapConnections;
        private Entrance[] entrances;

        public MapConnection[] MapConnections => mapConnections;

        public Entrance[] Entrances => entrances;

        public event Action<Map, bool> OnMapActive;

        private void Awake()
        {
            entrances = GetComponentsInChildren<Entrance>();
            mapConnections = entrances.Select(e => e.MapConnection).ToArray();
        }

        private void OnEnable()
        {
            OnMapActive?.Invoke(this, true);
            CameraController.Instance.SetConfiner(confiner);
        }

        private void OnDisable()
        {
            OnMapActive?.Invoke(this, false);
        }
    }
}