using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private Map[] maps;
        [SerializeField] private UIOpenEvent loadingUIOpenEvent;
        [SerializeField] private UICloseEvent loadingUICloseEvent;

        private Map currentMap;

        private void Awake()
        {
            foreach (Map map in maps)
            {
                map.gameObject.SetActive(false);
                map.OnMapActive += OnMapActive;
            }

            maps.First().gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            foreach (Map map in maps)
            {
                map.OnMapActive -= OnMapActive;
            }
        }

        private void OnMapActive(Map map, bool active)
        {
            if (active)
            {
                currentMap = map;
            }
        }

        public void ChangeMap(MapConnection mapConnection)
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine());

            IEnumerator Coroutine()
            {
                loadingUIOpenEvent.Raise();
                yield return new WaitForSeconds(0.5f);
                var newMap = maps.First(map => map.MapConnections.Contains(mapConnection));
                currentMap.gameObject.SetActive(false);
                newMap.gameObject.SetActive(true);
                var entrance = newMap.Entrances.First(e => e.MapConnection == mapConnection).PlayerPosition;
                PlayerController.Instance.transform.SetPositionAndRotation(entrance.position, entrance.rotation);
                yield return new WaitForSeconds(0.3f);
                loadingUICloseEvent.Raise();
            }
        }
    }
}