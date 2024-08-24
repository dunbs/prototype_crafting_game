using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

namespace CraftingGame
{
    /// <summary>
    /// Various helper tools
    /// </summary>
    public static class Utilities
    {
        #region Lists and Arrays

        public static void Insert<T>(this T[] a, int index, T value, int? count = null)
        {
            for (int i = count ?? a.Length - 1; i >= index; i--)
            {
                a[i + 1] = a[i];
            }

            a[index] = value;
        }

        public static T GetRandomAndRemove<T>(this List<T> deck, bool retainOrder = false)
        {
            var index = UnityEngine.Random.Range(0, deck.Count);
            var random = deck[index];
            if (retainOrder)
            {
                deck.RemoveAt(index);
            }
            else
            {
                deck[index] = deck[^1];
                deck.RemoveAt(deck.Count - 1);
            }

            return random;
        }

        public static T GetRandom<T>(this List<T> deck)
        {
            if (deck.Count == 0)
            {
                return default;
            }

            var index = UnityEngine.Random.Range(0, deck.Count);
            var random = deck[index];
            return random;
        }

        public static T GetRandom<T>(this T[] deck)
        {
            if (deck.Length == 0)
            {
                return default;
            }

            return deck[UnityEngine.Random.Range(0, deck.Length)];
        }

        public static void Shuffle<T>(this List<T> deck)
        {
            for (var i = 0; i < deck.Count; i++)
            {
                var temp = deck[i];
                var randomIndex = UnityEngine.Random.Range(0, deck.Count);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
        }

        public static void Shuffle<T>(this T[] deck)
        {
            for (var i = 0; i < deck.Length; i++)
            {
                var temp = deck[i];
                var randomIndex = UnityEngine.Random.Range(0, deck.Length);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }
        }

        #endregion

        /// <summary>
        /// Get a random point inside the provided bounds
        /// </summary>
        /// <param name="bounds"></param>
        /// <returns></returns>
        public static Vector3 RandomPoint(this Bounds bounds)
        {
            return new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        #region UI

        public static bool IsPointerOverUIObject()
        {
            //check mouse
            if (EventSystem.current.IsPointerOverGameObject())
                return true;

            //check touch
            if (Input.touchCount > 0)
                if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                    return true;

            return false;
        }

        public static void SetSize(this RectTransform rectTransform, Vector2 newSize)
        {
            var currSize = rectTransform.rect.size;
            var sizeDiff = newSize - currSize;
            var pivot = rectTransform.pivot;
            rectTransform.offsetMin -= new Vector2(sizeDiff.x * pivot.x,
                sizeDiff.y * pivot.y);
            rectTransform.offsetMax += new Vector2(sizeDiff.x * (1.0f - pivot.x),
                sizeDiff.y * (1.0f - pivot.y));
        }

        #endregion

        #region Vector3

        /// <summary>
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Vector3 tạo với <c>Vector3.forward</c> một góc = angle</returns>
        public static Vector3 GetVectorFromAngle(float angle)
        {
            var angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>Góc được tạo bởi <c>dir</c> và <c>Vector3.forward</c></returns>
        public static float GetAngleFromVector(Vector3 dir)
        {
            dir = dir.normalized;
            var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
            if (angle < 0) angle += 360;
            //int angle = Mathf.RoundToInt(n);

            return angle;
        }

        public static Vector3 Set(this Vector3 vector3, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector3.x,
                y ?? vector3.y,
                z ?? vector3.z);
        }

        public static Vector3 SetRef(this ref Vector3 vector3, float? x = null, float? y = null, float? z = null)
        {
            vector3 = new Vector3(x ?? vector3.x,
                y ?? vector3.y,
                z ?? vector3.z);
            return vector3;
        }

        /// <summary>
        /// Move the vector towards the provided direction
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector3 Move(this Vector3 vector3, Vector3 direction)
        {
            return vector3 + direction;
        }


        public static Vector2 Set(this Vector2 vector2, float? x = null, float? y = null)
        {
            return new Vector2(x == null ? vector2.x : (float) x,
                y == null ? vector2.y : (float) y);
        }

        public static Vector2 ToVectorXZ(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        public static Vector3 ToVectorXZ(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0, vector2.y);
        }

        public static bool Approximately(this Quaternion quatA, Quaternion value, float acceptableRange = 0.0004f)
        {
            return 1 - Mathf.Abs(Quaternion.Dot(quatA, value)) < acceptableRange;
        }

        public static int Random(this Vector2Int minMax)
        {
            return UnityEngine.Random.Range(minMax.x, minMax.y);
        }

        public static float Random(this Vector2 minMax)
        {
            return UnityEngine.Random.Range(minMax.x, minMax.y);
        }

        #endregion


        #region Transform

        public static void Swap(this Transform transform, Transform target, bool position = true, bool rotation = true)
        {
            if (position)
                (transform.position, target.position) = (target.position, transform.position);
            if (rotation)
                (transform.rotation, target.rotation) = (target.rotation, transform.rotation);
        }

        public static void CopyTransformRecursively(this Transform transform, Transform target)
        {
#if UNITY_EDITOR
            if (transform.childCount != target.childCount)
            {
                Debug.LogWarning(
                    $"{transform} does not have the same amount of child as {target}");
            }
#endif

            transform.SetLocalPositionAndRotation(target.localPosition, target.localRotation);

            for (int i = 0; i < transform.childCount & i < target.childCount; i++)
            {
                var child = transform.GetChild(i);
                var targetChild = target.GetChild(i);
                child.CopyTransformRecursively(targetChild);
            }
        }

        public static void SetLayerRecursively(this Transform parent, int layer)
        {
            parent.gameObject.layer = layer;
            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                SetLayerRecursively(child, layer);
            }
        }

        public static T CopyComponent<T>(this GameObject destination, T original) where T : Component
        {
            if (original == null)
                return null;

            var comp = destination.AddComponent(original.GetType());

            return comp.GetCopyOf(original);
        }

        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public |
                                                   System.Reflection.BindingFlags.NonPublic |
                                                   System.Reflection.BindingFlags.Instance |
                                                   System.Reflection.BindingFlags.Default |
                                                   System.Reflection.BindingFlags.DeclaredOnly;
            System.Reflection.PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }

            System.Reflection.FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }

            return comp as T;
        }

        #endregion

        public static Color Set(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            return new Color(r ?? color.r,
                g ?? color.g,
                b ?? color.b,
                a ?? color.a);
        }
    }
}