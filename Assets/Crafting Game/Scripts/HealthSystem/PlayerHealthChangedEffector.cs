using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace CraftingGame
{
    public class PlayerHealthChangedEffector : HealthChangedEffectorBase
    {
        [SerializeField] private CharacterController2D characterController2D;
        [SerializeField] private SpriteRenderer whiteRenderer;
        [SerializeField] private ParticleSystem dieFx;
        [SerializeField] private ParticleSystem healingFx;
        [SerializeField] private float delayedDieDuration = 1;
        [SerializeField] private float flashDuration = 0.3f;

        public override void DoHitEffect(Vector3 hitDirection)
        {
            StartCoroutine(FlashCoroutine());
            Vector2 damageDir = hitDirection * 40f;
            characterController2D.Knockback(damageDir);
            return;

            IEnumerator FlashCoroutine()
            {
                whiteRenderer.enabled = true;
                yield return new WaitForSeconds(flashDuration);
                whiteRenderer.enabled = false;
            }
        }

        public override void DoDieEffect()
        {
            Instantiate(dieFx.gameObject, transform.position, transform.rotation);
            DOVirtual.DelayedCall(delayedDieDuration, () => gameObject.SetActive(false));
        }

        public override void DoHealEffect()
        {
            healingFx.Play();
        }
    }
}