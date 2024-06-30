using System;
using System.Linq;
using System.Security.Cryptography;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CraftingGame
{
    public class DropDown : UICanvas, ICancelHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        private GameObject blocker;

        protected override void Awake()
        {
            base.Awake();
            button.onClick.AddListener(Close);
        }

        public override void Open()
        {
            base.Open();
            image.DOKill();
            image.DOFade(1, 0.3f)
                .From(0);
        }

        public override void Close()
        {
            image.DOKill();
            image.DOFade(0, 0.3f)
                .From(1)
                .OnComplete(base.Close);
        }

        public void OnCancel(BaseEventData eventData)
        {
            Close();
        }

        private void Update()
        {
            HideIfClickedOutside(image.gameObject);
        }

        private void HideIfClickedOutside(GameObject panel)
        {
            if (Input.GetMouseButton(0) && panel.activeSelf &&
                !RectTransformUtility.RectangleContainsScreenPoint(
                    panel.GetComponent<RectTransform>(),
                    Input.mousePosition))
            {
                panel.SetActive(false);
            }
        }
    }
}