using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using HeathenEngineering.UX.uGUIExtras;
using System.Collections;

namespace HeathenEngineering.EditorScripts
{
    [CustomEditor(typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionOutputManager))]
    public class HeathenKeyboardOutputManagerEditorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            HeathenEngineering.UX.uGUIExtras.KeyCollectionOutputManager keyboard = target as HeathenEngineering.UX.uGUIExtras.KeyCollectionOutputManager;

            //keyboard.insertPoint = EditorGUILayout.IntField("Insert Point", keyboard.insertPoint);
            //keyboard.selectionLength = EditorGUILayout.IntField("Selection Width", keyboard.selectionLength);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Output", EditorStyles.boldLabel);
            DoOutputLink(keyboard);

            if (GUI.changed)
                EditorUtility.SetDirty(target);

            serializedObject.ApplyModifiedProperties();
        }

        void DoOutputLink(HeathenEngineering.UX.uGUIExtras.KeyCollectionOutputManager keyboard)
        {
            keyboard.autoLinkHID = EditorGUILayout.ToggleLeft("Respond to 'real' keyboard input", keyboard.autoLinkHID);

            keyboard.targetType = (KeyCollectionOutputTargetType)EditorGUILayout.EnumPopup("Target Type", keyboard.targetType);

            if (keyboard.targetType == KeyCollectionOutputTargetType.Component)
            {
                EditorGUILayout.HelpBox("Under this mode a reference to any Componenet's string attribute can be used as the output target by referncing the GameObject, Componenet and member attribute in editor or in script by setting the linkedGameObject, linkedBehaviour and Field accordingly.'.", MessageType.Info);
                keyboard.linkedGameObject = EditorGUILayout.ObjectField("Linked GameObject", keyboard.linkedGameObject, typeof(GameObject), true) as GameObject;

                if (keyboard.linkedGameObject != null)
                {
                    keyboard.ValidateLinkedData();
                    List<string> options = new List<string>();
                    foreach (Component com in keyboard.linkedBehaviours)
                    {
                        options.Add(com.GetType().ToString());

                    }
                    int indexOf = keyboard.linkedBehaviours.IndexOf(keyboard.linkedBehaviour);
                    int newIndex = EditorGUILayout.Popup("On Behaviour", indexOf, options.ToArray());
                    if (indexOf != newIndex)
                    {
                        keyboard.linkedBehaviour = keyboard.linkedBehaviours[newIndex];
                        keyboard.ValidateLinkedData();
                        if (keyboard.fields.Count <= 0)
                            return;
                    }
                    //Debug.Log("Found properties to list");
                    indexOf = keyboard.fields.IndexOf(keyboard.field);
                    newIndex = EditorGUILayout.Popup("For Property", indexOf, keyboard.fields.ToArray());
                    if (newIndex != indexOf)
                    {
                        keyboard.field = keyboard.fields[newIndex];
                        EditorUtility.SetDirty(target);
                    }
                }
            }
            else if (keyboard.targetType == KeyCollectionOutputTargetType.InputField)
            {
                EditorGUILayout.HelpBox("Under this mode a reference to a target InputField is provided in editor or via script by calling 'SetInputTarget([InputField])'.", MessageType.Info);
                keyboard.ManualSetInputTarget(EditorGUILayout.ObjectField("Target", keyboard.lastInputField, typeof(UnityEngine.UI.InputField), true) as UnityEngine.UI.InputField);
            }
            else if (keyboard.targetType == KeyCollectionOutputTargetType.Text)
            {
                EditorGUILayout.HelpBox("Under this mode a reference to a target UnityEngine.UI.Text is provided in editor.'.", MessageType.Info);
                if (keyboard.linkedBehaviour != null && keyboard.linkedBehaviour.GetComponent<UnityEngine.UI.Text>() == null)
                    keyboard.ManualSetTextTarget(null);

                keyboard.ManualSetTextTarget(EditorGUILayout.ObjectField("Target", keyboard.linkedBehaviour, typeof(UnityEngine.UI.Text), true) as UnityEngine.UI.Text);
            }
            else if (keyboard.targetType == KeyCollectionOutputTargetType.Function)
            {
                EditorGUILayout.HelpBox("Under this mode Output Manager will pass the pressed KeyCollectionKey to the provided handler which can be specified in editor or by listening to KeyStrokeEvent'.", MessageType.Info);
                SerializedProperty eventProp = serializedObject.FindProperty("keyStrokeEvent");

                EditorGUILayout.PropertyField(eventProp);
            }
            else if (keyboard.targetType == KeyCollectionOutputTargetType.EventSystem)
            {
                EditorGUILayout.HelpBox("Under this mode the Output Manager will monitor the currently selected gameobject and if that object is of type InputField it will target it for output otherwise the last known targeed InputField will be used as the target.", MessageType.Info);
            }
        }

    }
}
