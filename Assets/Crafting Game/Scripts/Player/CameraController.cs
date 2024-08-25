using System;
using Cinemachine;
using UnityEngine;

namespace CraftingGame
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineConfiner2D confiner2D;

        public static CameraController Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SetConfiner(Collider2D collider2D)
        {
            confiner2D.m_BoundingShape2D = collider2D;
        }
    }
}