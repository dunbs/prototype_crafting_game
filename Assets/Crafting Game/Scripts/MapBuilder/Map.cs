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
        private ShouldEnableOnMapLoad[] shouldEnableOnMapLoads;

        public MapConnection[] MapConnections => mapConnections;

        public Entrance[] Entrances => entrances;

        public event Action<Map, bool> OnMapActive;

        public void Init()
        {
            entrances = GetComponentsInChildren<Entrance>(true);
            mapConnections = entrances.Select(e => e.MapConnection).ToArray();
            shouldEnableOnMapLoads = GetComponentsInChildren<ShouldEnableOnMapLoad>(true);
        }

        private void OnEnable()
        {
            OnMapActive?.Invoke(this, true);
            CameraController.Instance.SetConfiner(confiner);
            foreach (ShouldEnableOnMapLoad shouldEnableOnMapLoad in shouldEnableOnMapLoads)
            {
                shouldEnableOnMapLoad.gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
            OnMapActive?.Invoke(this, false);
        }
    }
}