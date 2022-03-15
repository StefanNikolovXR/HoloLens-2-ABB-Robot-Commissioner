using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace HeathenEngineering.UX.uGUIExtras
{
    [CustomEditor(typeof(LigatureLibrary))]
    public class HeathenLigatureToolEditorScript : Editor
    {
        Vector2 scrollPos;
        string input, output;

        public override void OnInspectorGUI()
        {
            var lib = target as HeathenEngineering.UX.uGUIExtras.LigatureLibrary;
            if (lib.map == null)
                lib.map = new List<LigatureReference>();

            EditorGUILayout.LabelField("Standard Ligature Options");
            EditorGUILayout.BeginHorizontal();
            if(GUILayout.Button("Common (© ™ à)", EditorStyles.toolbarButton))
            {
                lib.AddCommonLigatures();
            }
            if (GUILayout.Button("ˢᵘᵖᵖᵉʳScript", EditorStyles.toolbarButton))
            {
                lib.AddSupperScriptLigatures();
            }
            if (GUILayout.Button("Fractions (⅒ ½ ⅝)", EditorStyles.toolbarButton))
            {
                lib.AddFractionLigatures();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Katakana カタカナ", EditorStyles.toolbarButton))
            {
                lib.AddKatakanaLigatures();
            }
            if (GUILayout.Button("Korean 한국어", EditorStyles.toolbarButton))
            {
                lib.AddKatakanaLigatures();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Ligature Editor");
            EditorGUILayout.BeginHorizontal();
            input = EditorGUILayout.TextField(input);
            output = EditorGUILayout.TextField(output);
            var tColor = GUI.color;
            GUI.color = Color.green;
            if (GUILayout.Button("+", EditorStyles.miniButtonRight , GUILayout.Width(30)))
            {
                var nLig = new LigatureReference(input, output);
                lib.map.Insert(0, nLig);
                input = "";
                output = "";
                GUI.FocusControl("");
                EditorUtility.SetDirty(lib);
            }
            GUI.color = tColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Input Characters");
            EditorGUILayout.LabelField("Output Characters");
            EditorGUILayout.EndHorizontal();
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, EditorStyles.helpBox);
            List<LigatureReference> toRemove = new List<LigatureReference>();
            foreach(var l in lib.map)
            {
                EditorGUILayout.BeginHorizontal();
                
                var c = l.Characters;
                l.Characters = EditorGUILayout.TextField(l.Characters);
                if (c != l.Characters)
                    EditorUtility.SetDirty(lib);
                c = l.Ligature;
                l.Ligature = EditorGUILayout.TextField(l.Ligature);
                if (c != l.Ligature)
                    EditorUtility.SetDirty(lib);

                var color = GUI.color;
                GUI.color = Color.red;
                if (GUILayout.Button("-", EditorStyles.miniButtonRight, GUILayout.Width(15)))
                {
                    toRemove.Add(l);
                    GUI.FocusControl("");
                    EditorUtility.SetDirty(lib);
                }
                GUI.color = color;

                EditorGUILayout.EndHorizontal();
            }
            foreach (var r in toRemove)
                lib.map.Remove(r);
            EditorGUILayout.EndScrollView();
        }
    }
}
