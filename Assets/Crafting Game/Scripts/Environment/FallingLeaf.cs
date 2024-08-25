using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CraftingGame
{
    public class FallingLeaf : MonoBehaviour
    {
        [SerializeField] private float delayedTimeToFall = 1.5f;
        [SerializeField] private float delayedTimeToRecover = 1.5f;
        [SerializeField] private Vector3 rotationOnDisappearance;
        [SerializeField] private Transform modelToRotate;
        [SerializeField] private Collider2D collider2D;

        private Vector3 initialRotation;
        private bool isTriggered;

        private void Awake()
        {
            initialRotation = modelToRotate.eulerAngles;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isTriggered)
            {
                StartCoroutine(FallCoroutine());
            }
        }

        private IEnumerator FallCoroutine()
        {
            const float rotationDuration = 0.5f;

            isTriggered = true;
            yield return new WaitForSeconds(delayedTimeToFall);
            collider2D.enabled = false;
            modelToRotate.DORotate(rotationOnDisappearance, rotationDuration).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(delayedTimeToRecover);
            modelToRotate.DORotate(initialRotation, rotationDuration).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(rotationDuration);
            collider2D.enabled = true;
            isTriggered = false;
        }
    }
}