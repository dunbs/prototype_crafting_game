using System;
using UnityEngine;

namespace CraftingGame
{
    public abstract class UICanvas : MonoBehaviour
    {
        public bool IsOpened => gameObject.activeInHierarchy;

        protected virtual void Awake()
        {
            Close();
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