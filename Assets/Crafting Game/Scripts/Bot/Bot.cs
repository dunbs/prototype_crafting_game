using System;
using System.Linq;
using UnityEngine;

namespace CraftingGame
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private Path path;
        [SerializeField] private float speed = 20;
        [SerializeField] private float chasingSpeed = 80;
        [SerializeField] private CharacterController2D characterController2D;
        [SerializeField] private State state;

        [Header("Chase")]
        [SerializeField] private Vector2 chaseMaxDistance = new Vector2(10, 1);
        [SerializeField] private DetectionArea detectionArea;

        private bool hasDetectionArea;

        private enum State
        {
            Moving,
            Chase
        }

        private void Awake()
        {
            hasDetectionArea = detectionArea;
        }

        private void Update()
        {
            state = DecideState();
            switch (state)
            {
                case State.Moving:
                    DoMovingState();
                    break;
                case State.Chase:
                    DoChaseState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region Transitions

        private State DecideState()
        {
            if (!hasDetectionArea)
                return State.Moving;

            switch (state)
            {
                case State.Moving:
                    foreach (var body in detectionArea.BodiesInArea)
                    {
                        if (CanChase(body))
                        {
                            chaseTarget = body;
                            return State.Chase;
                        }
                    }

                    break;
                case State.Chase:
                    if (!CanChase(chaseTarget))
                    {
                        chaseTarget = null;
                        return State.Moving;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return state;
        }

        #endregion

        #region Moving

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

        #endregion

        #region Chasing

        private Transform chaseTarget;

        private void DoChaseState()
        {
            var targetPosition = chaseTarget.position;
            var currentPosition = transform.position;
            targetPosition.y = currentPosition.y; // No logic to move upwards yet

            var nextPosition = Vector3.MoveTowards(currentPosition, targetPosition,
                chasingSpeed * Time.deltaTime);

            characterController2D.Move((nextPosition - currentPosition).x, false, false);
        }

        private bool CanChase(Transform target)
        {
            if (!target) return false;

            var targetPosition = target.position;
            var currentPosition = transform.position;
            return targetPosition.x - currentPosition.x < chaseMaxDistance.x &&
                   targetPosition.y - currentPosition.y < chaseMaxDistance.y &&
                   detectionArea.BodiesInArea.Contains(target);
        }

        #endregion
    }
}