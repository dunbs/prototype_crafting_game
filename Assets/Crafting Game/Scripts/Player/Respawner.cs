using System;
using DG.Tweening;
using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    [RequireComponent(typeof(IDamageable))]
    public class Respawner : MonoBehaviour
    {
        [SerializeField] private CheckpointVariable checkpointVariable;
        [SerializeField] private RespawnerPrefabSO respawnerPrefab;
        [SerializeField] private float delay;

        private IDamageable damageable;

        private void Awake()
        {
            damageable = GetComponent<IDamageable>();
            damageable.OnDead += DamageableOnOnDead;
        }

        private void OnDestroy()
        {
            damageable.OnDead -= DamageableOnOnDead;
        }

        private void DamageableOnOnDead(IDamageable.DieArgs obj)
        {
            DOVirtual.DelayedCall(delay, () =>
            {
                GameObject.Instantiate(
                    respawnerPrefab.respawner,
                    checkpointVariable.Value.transform.position,
                    Quaternion.identity);
            });
        }
    }
}