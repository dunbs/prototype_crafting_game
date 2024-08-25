using System;
using UnityAtoms;
using UnityEngine;

namespace CraftingGame
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private CheckpointVariable checkpointVariable;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.CompareTag("Player"))
            {
                checkpointVariable.Value = this;
            }
        }
    }
}