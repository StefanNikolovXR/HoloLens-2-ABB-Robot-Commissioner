using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionKey))]
public class HeathenKeyboardKeyEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        HeathenEngineering.UX.uGUIExtras.KeyCollectionKey key = target as HeathenEngineering.UX.uGUIExtras.KeyCollectionKey;
        var nKeyType = (HeathenEngineering.UX.uGUIExtras.KeyCollectionKeyType)EditorGUILayout.EnumPopup("Type", key.keyType);

        if (nKeyType != key.keyType)
        {
            key.keyType = nKeyType;

            if (!key.EditorParseKeyCode)
            {
                key.EditorParseKeyCode = true;   
            }

            key.keyType = key.keyGlyph.DefaultFromCode(key.keyGlyph.code);
            EditorUtility.SetDirty(key);
        }

        key.EditorParseKeyCode = EditorGUILayout.ToggleLeft("Parse return values from key code?", key.EditorParseKeyCode);
        KeyCode previousCode = (KeyCode)EditorGUILayout.EnumPopup("Code", key.keyGlyph.code);

        if (previousCode != key.keyGlyph.code)
        {
            if (previousCode == KeyCode.Space || previousCode == KeyCode.Tab)
            {
                key.keyGlyph.code = previousCode;
                key.keyType = key.keyGlyph.DefaultFromCode(key.keyGlyph.code);

                EditorGUILayout.HelpBox("White space key codes automatically parse the return value based on the provided code.", MessageType.Info);
            }
            else if (key.EditorParseKeyCode)
            {
                key.keyGlyph.code = previousCode;
                key.keyType = key.keyGlyph.DefaultFromCode(key.keyGlyph.code);
            }
            else
                key.keyGlyph.code = previousCode;

            EditorUtility.SetDirty(target);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("State Glyphs", EditorStyles.boldLabel);
        var trans = EditorGUILayout.ObjectField("Normal", key.keyGlyph.normal, typeof(RectTransform), true) as RectTransform;
        if (trans != key.keyGlyph.normal)
        {
            key.keyGlyph.normal = trans;
            EditorUtility.SetDirty(target);
        }
        if (key.keyGlyph.normal != null)
        {
            var display = EditorGUILayout.ObjectField("Text", key.keyGlyph.normalDisplay, typeof(TMPro.TextMeshProUGUI), true) as TMPro.TextMeshProUGUI;

            if(display != key.keyGlyph.normalDisplay)
            {
                key.keyGlyph.normalDisplay = display;
                EditorUtility.SetDirty(target);
            }

            if (!key.EditorParseKeyCode)
            {
                EditorGUILayout.LabelField("Return Value:");
                var textValue = EditorGUILayout.TextArea(key.keyGlyph.normalString);
                if(textValue != key.keyGlyph.normalString)
                {
                    key.keyGlyph.normalString = textValue;
                    EditorUtility.SetDirty(target);
                }
            }
        }
        EditorGUILayout.Space(); 
        trans = EditorGUILayout.ObjectField("On Shift", key.keyGlyph.shifted, typeof(RectTransform), true) as RectTransform;
        if (trans != key.keyGlyph.shifted)
        {
            key.keyGlyph.normal = trans;
            EditorUtility.SetDirty(target);
        }
        if (key.keyGlyph.shifted != null)
        {
            var display = EditorGUILayout.ObjectField("Text", key.keyGlyph.shiftedDisplay, typeof(TMPro.TextMeshProUGUI), true) as TMPro.TextMeshProUGUI;

            if (display != key.keyGlyph.shiftedDisplay)
            {
                key.keyGlyph.shiftedDisplay = display;
                EditorUtility.SetDirty(target);
            }

            if (!key.EditorParseKeyCode)
            {
                EditorGUILayout.LabelField("Return Value:");
                var textValue = EditorGUILayout.TextArea(key.keyGlyph.shiftedString);
                if (textValue != key.keyGlyph.normalString)
                {
                    key.keyGlyph.shiftedString = textValue;
                    EditorUtility.SetDirty(target);
                }
            }
        }
        EditorGUILayout.Space();
        trans = EditorGUILayout.ObjectField("On AltGr", key.keyGlyph.altGr, typeof(RectTransform), true) as RectTransform;
        if (trans != key.keyGlyph.altGr)
        {
            key.keyGlyph.normal = trans;
            EditorUtility.SetDirty(target);
        }
        if (key.keyGlyph.altGr != null)
        {
            var display = EditorGUILayout.ObjectField("Text", key.keyGlyph.altGrDisplay, typeof(TMPro.TextMeshProUGUI), true) as TMPro.TextMeshProUGUI;

            if (display != key.keyGlyph.altGrDisplay)
            {
                key.keyGlyph.altGrDisplay = display;
                EditorUtility.SetDirty(target);
            }

            if (!key.EditorParseKeyCode)
            {
                EditorGUILayout.LabelField("Return Value:");
                var textValue = EditorGUILayout.TextArea(key.keyGlyph.altGrString);
                if (textValue != key.keyGlyph.normalString)
                {
                    key.keyGlyph.altGrString = textValue;
                    EditorUtility.SetDirty(target);
                }
            }
        }
        EditorGUILayout.Space();
        trans = EditorGUILayout.ObjectField("On Shift + AltGr", key.keyGlyph.shiftedAltGr, typeof(RectTransform), true) as RectTransform;
        if (trans != key.keyGlyph.shiftedAltGr)
        {
            key.keyGlyph.normal = trans;
            EditorUtility.SetDirty(target);
        }
        if (key.keyGlyph.shiftedAltGr != null)
        {
            var display = EditorGUILayout.ObjectField("Text", key.keyGlyph.shiftedAltGrDisplay, typeof(TMPro.TextMeshProUGUI), true) as TMPro.TextMeshProUGUI;

            if (display != key.keyGlyph.shiftedAltGrDisplay)
            {
                key.keyGlyph.shiftedAltGrDisplay = display;
                EditorUtility.SetDirty(target);
            }

            if (!key.EditorParseKeyCode)
            {
                EditorGUILayout.LabelField("Return Value:");
                var textValue = EditorGUILayout.TextArea(key.keyGlyph.shiftedAltGrString);
                if (textValue != key.keyGlyph.shiftedAltGrString)
                {
                    key.keyGlyph.shiftedAltGrString = textValue;
                    EditorUtility.SetDirty(target);
                }
            }
        }

        

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Events");
        var p = serializedObject.FindProperty("pressed");
        EditorGUILayout.PropertyField(p);
        p = serializedObject.FindProperty("isDown");
        EditorGUILayout.PropertyField(p);
        p = serializedObject.FindProperty("isUp");
        EditorGUILayout.PropertyField(p);
        p = serializedObject.FindProperty("isClicked");
        EditorGUILayout.PropertyField(p);

        serializedObject.ApplyModifiedProperties();
    }
}
