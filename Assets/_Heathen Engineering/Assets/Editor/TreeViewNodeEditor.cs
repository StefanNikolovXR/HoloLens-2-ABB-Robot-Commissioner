using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using HeathenEngineering.UX.uGUIExtras;

[CustomEditor(typeof(TreeViewNode), false)]
public class TreeViewNodeEditor : GraphicEditor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        if (serializedObject.FindProperty("tree").objectReferenceValue != null
            && serializedObject.FindProperty("collection").objectReferenceValue != null)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+ Create Sibling", EditorStyles.toolbarButton))
            {
                var n = (target as TreeViewNode).tree.CreateNode();
                Undo.RegisterCreatedObjectUndo(n.gameObject, "Create" + n.gameObject.name);
            }
            if (GUILayout.Button("+ Create Child", EditorStyles.toolbarButton))
            {
                var n = (target as TreeViewNode).CreateChildNode();
                Undo.RegisterCreatedObjectUndo(n.gameObject, "Create" + n.gameObject.name);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("˄ Move Up", EditorStyles.toolbarButton))
            {
                (target as TreeViewNode).MoveUp();
            }
            if (GUILayout.Button("˅ Move Down", EditorStyles.toolbarButton))
            {
                (target as TreeViewNode).MoveDown();
            }
            if (GUILayout.Button("˂ Promote", EditorStyles.toolbarButton))
            {
                (target as TreeViewNode).Promote();
            }
            if (GUILayout.Button("˃ Demote", EditorStyles.toolbarButton))
            {
                (target as TreeViewNode).Demote();                
            }
            EditorGUILayout.EndHorizontal();
        }
        DrawDefaultInspector();
        serializedObject.ApplyModifiedProperties();
    }
}
