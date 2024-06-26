using UnityEngine;
using UnityEngine.UI;

namespace CraftingGame
{
    public class UIHeartPoint : MonoBehaviour
    {
        [SerializeField] private Image healthPoint;

        public void SetActive(bool isActive)
        {
            healthPoint.enabled = isActive;
        }
    }
}