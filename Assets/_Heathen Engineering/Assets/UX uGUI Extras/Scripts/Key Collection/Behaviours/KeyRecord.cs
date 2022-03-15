using UnityEngine;
using System;

namespace HeathenEngineering.UX.uGUIExtras
{
    [Serializable]
    public struct KeyRecord
    {
        public bool parseFromKeyCode;
        /// <summary>
        /// Defines how the key should be handled when press events occure
        /// </summary>
        [Tooltip("What type of key determins how the key responds when pressed")]
        public KeyCollectionKeyType keyType;
        /// <summary>
        /// Defines the visual representation and the return value on press of the key
        /// </summary>
        [SerializeField]
        public KeyGlyphData keyGlyph;
        [SerializeField]
        public Vector2 Size;
        [SerializeField]
        public Vector3 Position;
        [SerializeField]
        public Vector3 Rotation;
        [SerializeField]
        public Vector3 Scale;

        public KeyRecord(Transform root, KeyCollectionKey key)
        {
            parseFromKeyCode = key.EditorParseKeyCode;
            keyType = key.keyType;
            keyGlyph = new KeyGlyphData(key.keyGlyph);
            key.selfRectTransform = key.gameObject.GetComponent<RectTransform>();
            Size = key.selfRectTransform.sizeDelta;
            Position = root.InverseTransformPoint(key.selfRectTransform.position);
            var parent = key.selfRectTransform.parent;
            key.selfRectTransform.SetParent(root);
            Rotation = key.selfRectTransform.localEulerAngles;
            Scale = key.selfRectTransform.localScale;
            key.selfRectTransform.SetParent(parent);
        }
    }
}
