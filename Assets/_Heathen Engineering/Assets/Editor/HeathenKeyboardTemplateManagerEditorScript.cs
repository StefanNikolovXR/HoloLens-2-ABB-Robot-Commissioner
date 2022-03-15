using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using HeathenEngineering.UX.uGUIExtras;

[CustomEditor(typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager))]
public class HeathenKeyboardTemplateManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager keyboard = target as HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager;

        if (keyboard.workingTemplate == null)
            keyboard.workingTemplate = new HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplate() { TemplateName = "New Template" };

        keyboard.RefreshTemplate();

        EditorGUILayout.LabelField("Template", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        if (drawButton("Save As", 45))
        {
            keyboard.RefreshTemplate();
            string pathTarget = EditorUtility.SaveFilePanel("Save KeyCollection Layout", Application.dataPath, keyboard.workingTemplate.TemplateName, "asset");
            if (!string.IsNullOrEmpty(pathTarget))
            {
                try
                {
                    //XmlSerializer serialize = new XmlSerializer(typeof(HeathenEngineering.UIX.Serialization.KeyboardTemplate));
                    //StreamWriter fileStream = new StreamWriter(pathTarget);
                    //serialize.Serialize(fileStream, keyboard.workingTemplate);
                    //fileStream.Close();
                    //fileStream.Dispose();

                    if (!pathTarget.StartsWith(Application.dataPath))
                    {
                        Debug.LogError("Key Layouts must be saved within the project's Assets folder.");
                    }
                    else
                    {
                        pathTarget = pathTarget.Replace(Application.dataPath, "Assets");
                        var fileName = pathTarget.Substring(pathTarget.LastIndexOf("/") + 1);
                        pathTarget = pathTarget.Substring(0, pathTarget.Length - fileName.Length);
                        KeyLayout.SaveLayout(keyboard.keyboard, fileName, pathTarget);
                    }
                }
                catch
                {
                    Debug.LogError("An error occured while attempting to save the keyboard's template data");
                }
            }
        }
        if (keyboard.selectedTemplate != null)
        {
            if (drawButton("Refresh From", 45))
            {
                ReloadFromTemplate(keyboard);
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("References", EditorStyles.boldLabel);
        keyboard.Prototype = EditorGUILayout.ObjectField("Prototype", keyboard.Prototype, typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionKey), false) as HeathenEngineering.UX.uGUIExtras.KeyCollectionKey;
        keyboard.Container = EditorGUILayout.ObjectField("Container", keyboard.Container, typeof(RectTransform), true) as RectTransform;
        EditorGUILayout.Space();
        if (keyboard.headerRowTransform != null && keyboard.Container != null && keyboard.Prototype != null)
        {
            EditorGUILayout.HelpBox("If you do not intend to load templates at run time you can safely remove the Template Manager without effecting the instantiated keyboard.", MessageType.Info);
            EditorGUILayout.LabelField("Transforms", EditorStyles.boldLabel);
            ShowRows(keyboard);
        }
        EditorGUILayout.Space();
        LoadLayout(keyboard);
        LoadTemplate(keyboard);
        
        
        

        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }

    void ShowRows(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager keyboard)
    {
        keyboard.headerRowTransform = EditorGUILayout.ObjectField("Header Row", keyboard.headerRowTransform, typeof(RectTransform), true) as RectTransform;
        if (keyboard.rowTransforms == null)
            keyboard.rowTransforms = new System.Collections.Generic.List<RectTransform>();

        int rowCount = EditorGUILayout.IntField("Rows", keyboard.rowTransforms.Count);

        if (rowCount > keyboard.rowTransforms.Count)
        {
            int i = 1;
            foreach (RectTransform row in keyboard.rowTransforms)
            {
                keyboard.rowTransforms[i - 1] = EditorGUILayout.ObjectField("Row " + i.ToString(), row, typeof(RectTransform), true) as RectTransform;
                i++;
            }
            for (int x = 0; x < rowCount - (i - 1); x++)
            {
                keyboard.rowTransforms.Add(null);
            }
        }
        else if (rowCount < keyboard.rowTransforms.Count)
        {
            List<RectTransform> nTrans = new List<RectTransform>();
            for (int i = 0; i < rowCount; i++)
            {
                nTrans.Add(keyboard.rowTransforms[i]);
            }
            keyboard.rowTransforms.Clear();
            keyboard.rowTransforms.AddRange(nTrans);
        }
        else
        {
            for (int i = 0; i < keyboard.rowTransforms.Count; i++)
            {
                RectTransform row = keyboard.rowTransforms[i];
                keyboard.rowTransforms[i] = EditorGUILayout.ObjectField("Row " + i.ToString(), row, typeof(RectTransform), true) as RectTransform;
            }
        }
    }

    //void SaveToTemplate(HeathenEngineering.UIX.KeyCollectionTemplateManager keyboard)
    //{
    //    //TODO: save the current template to disk
    //}

    void LoadTemplate(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager keyboard)
    {
        legacyFoldOut = EditorGUILayout.BeginToggleGroup("Load Legacy Templates", legacyFoldOut);

        if (legacyFoldOut)
        {
            EditorGUILayout.LabelField("Current: " + (keyboard.selectedTemplate == null || string.IsNullOrEmpty(keyboard.selectedTemplate.TemplateName) ? "Unnamed" : keyboard.selectedTemplate.TemplateName));
            if (keyboard.Prototype != null && keyboard.Container != null)
            {
                TextAsset newAsset = EditorGUILayout.ObjectField("Legacy Template", null, typeof(TextAsset), false) as TextAsset;
                if (newAsset != null)
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplate));
                    StringReader reader = new StringReader(newAsset.text);

                    try
                    {
                        HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplate result = deserializer.Deserialize(reader) as HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplate;
                        reader.Close();

                        if (result != null)
                        {
                            keyboard.selectedTemplate = result;
                            ReloadFromTemplate(keyboard);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("Failed to read the selected template. Message: " + ex.Message);
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox("You must provide a key prototype in the Prototype field and a target Rect Transform in the Container field in order to load a template.", MessageType.Info);
            }

            EditorGUILayout.Space();
        }
        EditorGUILayout.EndToggleGroup();
    }

    bool legacyFoldOut = false;
    bool keyTemplate = true;

    void LoadLayout(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager keyboard)
    {
        keyTemplate = EditorGUILayout.BeginToggleGroup("Load Key Layout", keyTemplate);

        if (keyTemplate)
        {
            if (keyboard.Prototype != null)
            {
                KeyLayout newAsset = EditorGUILayout.ObjectField("Layout", null, typeof(KeyLayout), false) as KeyLayout;
                if (newAsset != null)
                {
                    newAsset.ApplyTo(keyboard.keyboard, keyboard.Prototype);
                }
            }
            else
            {
                EditorGUILayout.HelpBox("You must provide a key prototype in the Prototype field load a key layout.", MessageType.Info);
            }

            EditorGUILayout.Space();
        }
        EditorGUILayout.EndToggleGroup();
    }

    void ReloadFromTemplate(HeathenEngineering.UX.uGUIExtras.KeyCollectionTemplateManager keyboard)
    {
        try
        {
            if (keyboard.selectedTemplate != null)
            {
                keyboard.workingTemplate = keyboard.selectedTemplate;
                keyboard.RefreshKeyboard();
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to load the selected template. Message: " + ex.Message);
        }
    }

    bool drawButton(string label, float width)
    {
        Rect r = EditorGUILayout.BeginHorizontal("Button", GUILayout.Width(width));
        if (GUI.Button(r, GUIContent.none))
            return true;
        GUILayout.Label(label);
        EditorGUILayout.EndHorizontal();
        return false;
    }

    bool drawButton(string label)
    {
        Rect r = EditorGUILayout.BeginHorizontal("Button");
        if (GUI.Button(r, GUIContent.none))
            return true;
        GUILayout.Label(label);
        EditorGUILayout.EndHorizontal();
        return false;
    }

}
