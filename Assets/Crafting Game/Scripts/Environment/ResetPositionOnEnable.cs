using System;
using UnityEngine;

namespace CraftingGame
{
    public class ResetPositionOnEnable : MonoBehaviour
    {
        private Vector3 position;
        private Quaternion rotation;

        private void Awake()
        {
            position = transform.position;
            rotation = transform.rotation;
        }

        private void OnEnable()
        {
            transform.SetPositionAndRotation(position, rotation);
        }
    }
}