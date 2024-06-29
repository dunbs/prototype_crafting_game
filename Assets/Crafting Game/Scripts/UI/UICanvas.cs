using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace CraftingGame
{
    public abstract class UICanvas : MonoBehaviour
    {
        [SerializeField] private UIOpenEvent openEvent;
        [SerializeField] private UICloseEvent closeEvent;

        public bool IsOpened => gameObject.activeInHierarchy;

        protected virtual void Awake()
        {
            openEvent.Register(Open);
            closeEvent.Register(Close);

            Close();
        }

        protected virtual void OnDestroy()
        {
            openEvent.Unregister(Open);
            closeEvent.Unregister(Close);
        }

        public virtual void Toggle()
        {
            gameObject.SetActive(gameObject.activeSelf);
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}