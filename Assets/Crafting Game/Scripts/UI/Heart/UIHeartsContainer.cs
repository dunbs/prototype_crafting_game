using System;
using System.Collections.Generic;
using UnityAtoms.CraftingGame.AtomEvents;
using UnityEngine;
using UnityEngine.Rendering;

namespace CraftingGame
{
    public class UIHeartsContainer : MonoBehaviour
    {
        [SerializeField] private UIHeartPoint prefab;
        [SerializeField] private Transform heartParent;
        [SerializeField] private IDamageableVariable damageableVariable;

        private List<UIHeartPoint> points = new();
        private IDamageable subscribedDamageable;

        private void Awake()
        {
            damageableVariable.Changed.Register(OnDamageableValue);
        }

        private void Start()
        {
            OnDamageableValue(damageableVariable.Value);
        }

        private void OnDamageableValue(IDamageable obj)
        {
            if (obj == null)
            {
                enabled = false;
                return;
            }

            enabled = true;
            if (subscribedDamageable != null) subscribedDamageable.OnHealthChanged -= OnHeartChanged;

            subscribedDamageable = obj;
            subscribedDamageable.OnHealthChanged += OnHeartChanged;
            UpdateHealth();
        }

        private void OnHeartChanged(IDamageable.HealthChangedArgs obj)
        {
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            UpdateMaxHealth();

            int health = Mathf.RoundToInt(damageableVariable.Value.MaxHealth);
            for (var i = 0; i < health; i++)
            {
                points[i].SetActive(i < damageableVariable.Value.Health);
            }
        }

        private void UpdateMaxHealth()
        {
            int maxHealth = Mathf.RoundToInt(damageableVariable.Value.MaxHealth);
            if (maxHealth == points.Count)
            {
                return;
            }

            for (int i = points.Count; i < maxHealth; i++)
            {
                var heartPoint = Instantiate(prefab, heartParent);
                heartPoint.transform.SetAsLastSibling();
                points.Add(heartPoint);
            }

            for (int i = points.Count - 1; i >= maxHealth; i--)
            {
                UIHeartPoint point = points[i];
                points.RemoveAt(i);
                Destroy(point.gameObject);
            }
        }
    }
}