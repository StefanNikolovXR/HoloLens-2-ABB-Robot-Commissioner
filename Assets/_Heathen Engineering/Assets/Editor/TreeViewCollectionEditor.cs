using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using HeathenEngineering.UX.uGUIExtras;

[CanEditMultipleObjects, CustomEditor(typeof(TreeViewCollection), false)]
public class TreeViewCollectionEditor : GraphicEditor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (serializedObject.FindProperty("root").objectReferenceValue != null
            && serializedObject.FindProperty("nodePrototype").objectReferenceValue != null)
        {
            if (GUILayout.Button("+ Create Child", EditorStyles.toolbarButton))
            {
                var n = (target as TreeViewCollection).CreateNode();
                Undo.RegisterCreatedObjectUndo(n.gameObject, "Create" + n.gameObject.name);
            }
        }
        DrawDefaultInspector();
        serializedObject.ApplyModifiedProperties();
    }

    bool DrawButton(string label, float width)
    {
        Rect r = EditorGUILayout.BeginHorizontal("Button", GUILayout.Width(width));
        if (GUI.Button(r, GUIContent.none))
            return true;
        GUILayout.Label(label);
        EditorGUILayout.EndHorizontal();
        return false;
    }
}
