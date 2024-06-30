using DG.Tweening;
using UnityEngine;

namespace CraftingGame
{
    public class UIInteractableIndicator : UICanvas
    {
        protected override void Awake()
        {
            base.Awake();
            transform.localScale = Vector3.zero;
        }

        public override void Open()
        {
            base.Open();
            transform.DOKill();
            transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack).From(Vector3.zero);
        }

        public override void Close()
        {
            transform.DOKill();
            transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(base.Close);
        }
    }
}