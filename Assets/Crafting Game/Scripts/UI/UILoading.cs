using DG.Tweening;
using UnityEngine;

namespace CraftingGame
{
    public class UILoading : UICanvas
    {
        [SerializeField] private CanvasGroup canvasGroup;

        public override void Open()
        {
            base.Open();
            canvasGroup.DOKill();
            canvasGroup.DOFade(1, 0.3f);
        }

        public override void Close()
        {
            canvasGroup.DOKill();
            canvasGroup.DOFade(0, 0.3f).OnComplete(base.Close);
        }
    }
}