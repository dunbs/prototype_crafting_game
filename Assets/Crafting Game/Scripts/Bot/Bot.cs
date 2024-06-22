using System;
using UnityEngine;

namespace CraftingGame
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private Path path;
        [SerializeField] private float speed = 20;
        [SerializeField] private CharacterController2D characterController2D;

        private State state;

        private enum State
        {
            Moving,
            Chase
        }

        private void Update()
        {
            switch (state)
            {
                case State.Moving:
                    DoMovingState();
                    break;
                case State.Chase:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private float nextMovementTimestamp;

        private void DoMovingState()
        {
            if (nextMovementTimestamp > Time.time)
            {
                characterController2D.Move(0, false, false);
                return;
            }

            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = path.CurrentPositionData.transform.position;

            if (Mathf.Abs(currentPosition.x - targetPosition.x) < 0.05f)
            {
                if (path.CurrentPositionData.stopDuration > 0)
                {
                    nextMovementTimestamp = Time.time + path.CurrentPositionData.stopDuration;
                    path.Next();
                    return;
                }

                path.Next();
                targetPosition = path.CurrentPositionData.transform.position;
            }

            var nextPosition = Vector3.MoveTowards(currentPosition, targetPosition,
                speed * Time.deltaTime);

            characterController2D.Move((nextPosition - currentPosition).x, false, false);
        }
    }
}