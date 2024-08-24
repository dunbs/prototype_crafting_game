using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    public class DetectionArea : MonoBehaviour
    {
        private List<Transform> bodiesInArea = new();

        public IReadOnlyCollection<Transform> BodiesInArea => bodiesInArea;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var body = other.attachedRigidbody ? other.attachedRigidbody.transform : other.transform;
            if (!body.CompareTag("Player")) return;

            bodiesInArea.Add(body);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var body = other.attachedRigidbody ? other.attachedRigidbody.transform : other.transform;
            if (!body.CompareTag("Player")) return;

            bodiesInArea.Remove(body);
        }
    }
}