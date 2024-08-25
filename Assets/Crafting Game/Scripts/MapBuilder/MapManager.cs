using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Serialization;

namespace CraftingGame
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private Map[] maps;
        [SerializeField] private UIOpenEvent loadingUIOpenEvent;
        [SerializeField] private UICloseEvent loadingUICloseEvent;
        [SerializeField] private CheckpointVariable checkpointVariable;
        [SerializeField] private CheckpointVariable respawnCheckpointVariable;

        private Map currentMap;

        private void Awake()
        {
            foreach (Map map in maps)
            {
                map.Init();
                map.gameObject.SetActive(false);
                map.OnMapActive += OnMapActive;
            }
        }

        private void Start()
        {
            maps[0].gameObject.SetActive(true);
            PlayerController.Instance.GetComponent<CharacterHealth>().OnDead += OnDead;
        }

        private void OnDead(IDamageable.DieArgs obj)
        {
            ReviveCharacter();
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
            return;

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

        public void RespawnCharacter()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine());
            return;

            IEnumerator Coroutine()
            {
                loadingUIOpenEvent.Raise();
                yield return new WaitForSeconds(0.3f);
                var checkpoint = checkpointVariable.Value.transform;
                PlayerController.Instance.transform.SetPositionAndRotation(checkpoint.position, checkpoint.rotation);
                PlayerController.Instance.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                loadingUICloseEvent.Raise();
            }
        }

        private void ReviveCharacter()
        {
            StopAllCoroutines();
            StartCoroutine(Coroutine());
            return;

            IEnumerator Coroutine()
            {
                loadingUIOpenEvent.Raise();
                yield return new WaitForSeconds(0.3f);
                var checkpoint = respawnCheckpointVariable.Value;
                PlayerController.Instance.transform.SetPositionAndRotation(checkpoint.transform.position,
                    checkpoint.transform.rotation);
                var newMap = FindMapOfCheckpoint(checkpoint);
                currentMap.gameObject.SetActive(false);
                newMap.gameObject.SetActive(true);
                currentMap = newMap;
                PlayerController.Instance.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                loadingUICloseEvent.Raise();
            }

            Map FindMapOfCheckpoint(Checkpoint checkpoint)
            {
                foreach (Map map in maps)
                {
                    if (checkpoint.transform.IsChildOf(map.transform))
                    {
                        return map;
                    }
                }

                return null;
            }
        }
    }
}