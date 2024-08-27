using System;
using UnityEngine;

namespace CraftingGame
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private PositionData[] positionData;
        private int index = 0;

        public PositionData CurrentPositionData => positionData[index];

        [Serializable]
        public class PositionData
        {
            public Transform transform;
            public float stopDuration;
        }

        private void Awake()
        {
            Debug.Assert(positionData.Length > 0);
        }

        public void Next()
        {
            index = (index + 1) % positionData.Length;
        }

        private void OnDrawGizmosSelected()
        {
            if (positionData.Length == 0) return;

            Gizmos.DrawWireSphere(positionData[0].transform.position, 0.3f);
            for (var index = 1; index < positionData.Length; index++)
            {
                PositionData data = positionData[index];
                var position = data.transform.position;
                Gizmos.DrawWireSphere(position, 0.3f);
                Gizmos.DrawLine(positionData[index - 1].transform.position, position);
            }
        }
    }
}