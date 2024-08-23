﻿using System;
using UnityEngine;

namespace CraftingGame
{
    [CreateAssetMenu(fileName = "Item Blueprint", menuName = "Crafting/Item Blueprint", order = 0)]
    public class ItemBlueprint : ScriptableObject
    {
        public string id;
        public Sprite icon;
        public string materialName;
        public Item prefab;

#if UNITY_EDITOR
        [ContextMenu("Generate new id")]
        private void GenerateNewId()
        {
            id = UnityEditor.GUID.Generate().ToString();
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.AssetDatabase.SaveAssetIfDirty(this);
        }
#endif
        public override bool Equals(object other)
        {
            if (other is not ItemBlueprint otherItemBlueprint) return false;

            return otherItemBlueprint.id == id;
        }
    }
}