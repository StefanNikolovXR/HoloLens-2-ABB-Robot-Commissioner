using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using HeathenEngineering.UX.uGUIExtras;
[CustomEditor(typeof(HeathenEngineering.UX.uGUIExtras.KeyCollectionDesigner))]
public class HeathenKeyboardKeyDesignerEditorScript : Editor
{
    HeathenEngineering.UX.uGUIExtras.KeyCollectionDesigner designer;

    public override void OnInspectorGUI()
    {
        designer = target as HeathenEngineering.UX.uGUIExtras.KeyCollectionDesigner;
        EditorGUILayout.LabelField("Tools", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        if (drawButton("Generate", 45))
        {
            GenerateKeys(designer);
        }
        if (drawButton("Update Keys", 45))
        {
            UpdateKeys(designer);
        }
        if (drawButton("Clear", 45))
        {
            ClearAll(designer);
        }
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.LabelField("Common Templates", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        if (drawButton("QWERTY", 45))
        {
            QWERTY();
        }
        if (drawButton("AZERTY", 45))
        {
            AZERTY();
        }
        if (drawButton("Alpha Numeric", 45))
        {
            AlphaNumeric();
        }

        if (drawButton("Keypad", 45))
        {
            NumberPad();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("References", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Prototype"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Container"));

        if (designer.Prototype == null)
        {
            EditorGUILayout.HelpBox("You must provide a KeyCollectionKey prototype. This is simply a prefb representing your key structure that must include a KeyCollectionKey component. There are several examples in the SystemsUIX > Framework > On Screen KeyCollection > KeyCollection Prototypes folder.", MessageType.Warning);
        }
        else if (designer.Container == null)
        {
            EditorGUILayout.HelpBox("You must provide a RectTransform target for the keys to be put in, generally this is simply an Empty GameoBject child of the KeyCollection.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Structure", EditorStyles.boldLabel);
            //EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("keyWidth"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("keySpacing"));
            //EditorGUILayout.EndHorizontal();
            //EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("keyHeight"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rowSpacing"));
            //EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rowKeyCount"), true);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Key States", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Keys"), true);
        }
        serializedObject.ApplyModifiedProperties();
        //DrawDefaultInspector();
    }

    void QWERTY()
    {
        BuildKeyboardKeys(designer);
    }

    void AZERTY()
    {
        ClearAll(designer);

        designer.rowKeyCount.Clear();
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(7);

        GenerateKeys(designer);

        //Row 1
        designer.Keys[0].code = KeyCode.BackQuote; designer.Keys[0].width = designer.keyWidth;
        designer.Keys[1].code = KeyCode.Alpha1; designer.Keys[1].width = designer.keyWidth;
        designer.Keys[2].code = KeyCode.Alpha2; designer.Keys[2].width = designer.keyWidth;
        designer.Keys[3].code = KeyCode.Alpha3; designer.Keys[3].width = designer.keyWidth;
        designer.Keys[4].code = KeyCode.Alpha4; designer.Keys[4].width = designer.keyWidth;
        designer.Keys[5].code = KeyCode.Alpha5; designer.Keys[5].width = designer.keyWidth;
        designer.Keys[6].code = KeyCode.Alpha6; designer.Keys[6].width = designer.keyWidth;
        designer.Keys[7].code = KeyCode.Alpha7; designer.Keys[7].width = designer.keyWidth;
        designer.Keys[8].code = KeyCode.Alpha8; designer.Keys[8].width = designer.keyWidth;
        designer.Keys[9].code = KeyCode.Alpha9; designer.Keys[9].width = designer.keyWidth;
        designer.Keys[10].code = KeyCode.Alpha0; designer.Keys[10].width = designer.keyWidth;
        designer.Keys[11].code = KeyCode.Minus; designer.Keys[11].width = designer.keyWidth;
        designer.Keys[12].code = KeyCode.Equals; designer.Keys[12].width = designer.keyWidth;
        designer.Keys[13].code = KeyCode.Backspace; designer.Keys[13].width = designer.keyWidth * 2;

        //Row 2
        designer.Keys[14].code = KeyCode.Tab; designer.Keys[14].width = designer.keyWidth * 1.5f;
        designer.Keys[15].code = KeyCode.A; designer.Keys[15].width = designer.keyWidth;
        designer.Keys[16].code = KeyCode.Z; designer.Keys[16].width = designer.keyWidth;
        designer.Keys[17].code = KeyCode.E; designer.Keys[17].width = designer.keyWidth;
        designer.Keys[18].code = KeyCode.R; designer.Keys[18].width = designer.keyWidth;
        designer.Keys[19].code = KeyCode.T; designer.Keys[19].width = designer.keyWidth;
        designer.Keys[20].code = KeyCode.Y; designer.Keys[20].width = designer.keyWidth;
        designer.Keys[21].code = KeyCode.U; designer.Keys[21].width = designer.keyWidth;
        designer.Keys[22].code = KeyCode.I; designer.Keys[22].width = designer.keyWidth;
        designer.Keys[23].code = KeyCode.O; designer.Keys[23].width = designer.keyWidth;
        designer.Keys[24].code = KeyCode.P; designer.Keys[24].width = designer.keyWidth;
        designer.Keys[25].code = KeyCode.LeftBracket; designer.Keys[25].width = designer.keyWidth;
        designer.Keys[26].code = KeyCode.RightBracket; designer.Keys[26].width = designer.keyWidth;
        designer.Keys[27].code = KeyCode.Return; designer.Keys[27].width = designer.keyWidth * 1.5f;

        //Row 3
        designer.Keys[28].code = KeyCode.CapsLock; designer.Keys[28].width = designer.keyWidth * 2;
        designer.Keys[29].code = KeyCode.Q; designer.Keys[29].width = designer.keyWidth;
        designer.Keys[30].code = KeyCode.S; designer.Keys[30].width = designer.keyWidth;
        designer.Keys[31].code = KeyCode.D; designer.Keys[31].width = designer.keyWidth;
        designer.Keys[32].code = KeyCode.F; designer.Keys[32].width = designer.keyWidth;
        designer.Keys[33].code = KeyCode.G; designer.Keys[33].width = designer.keyWidth;
        designer.Keys[34].code = KeyCode.H; designer.Keys[34].width = designer.keyWidth;
        designer.Keys[35].code = KeyCode.J; designer.Keys[35].width = designer.keyWidth;
        designer.Keys[36].code = KeyCode.K; designer.Keys[36].width = designer.keyWidth;
        designer.Keys[37].code = KeyCode.L; designer.Keys[37].width = designer.keyWidth;
        designer.Keys[38].code = KeyCode.M; designer.Keys[38].width = designer.keyWidth;
        designer.Keys[39].code = KeyCode.Quote; designer.Keys[39].width = designer.keyWidth;
        designer.Keys[40].code = KeyCode.Hash; designer.Keys[40].width = designer.keyWidth;

        //Row 4
        designer.Keys[41].code = KeyCode.LeftShift; designer.Keys[41].width = designer.keyWidth;
        designer.Keys[42].code = KeyCode.Backslash; designer.Keys[42].width = designer.keyWidth;
        designer.Keys[43].code = KeyCode.W; designer.Keys[43].width = designer.keyWidth;
        designer.Keys[44].code = KeyCode.X; designer.Keys[44].width = designer.keyWidth;
        designer.Keys[45].code = KeyCode.C; designer.Keys[45].width = designer.keyWidth;
        designer.Keys[46].code = KeyCode.V; designer.Keys[46].width = designer.keyWidth;
        designer.Keys[47].code = KeyCode.B; designer.Keys[47].width = designer.keyWidth;
        designer.Keys[48].code = KeyCode.N; designer.Keys[48].width = designer.keyWidth;
        designer.Keys[49].code = KeyCode.Question; designer.Keys[49].width = designer.keyWidth;
        designer.Keys[50].code = KeyCode.Comma; designer.Keys[50].width = designer.keyWidth;
        designer.Keys[51].code = KeyCode.Period; designer.Keys[51].width = designer.keyWidth;
        designer.Keys[52].code = KeyCode.Slash; designer.Keys[52].width = designer.keyWidth;
        designer.Keys[53].code = KeyCode.RightShift; designer.Keys[53].width = designer.keyWidth * 2;

        //Row 5
        designer.Keys[54].code = KeyCode.LeftControl; designer.Keys[54].width = designer.keyWidth;
        designer.Keys[55].code = KeyCode.LeftWindows; designer.Keys[55].width = designer.keyWidth;
        designer.Keys[56].code = KeyCode.LeftAlt; designer.Keys[56].width = designer.keyWidth;
        designer.Keys[57].code = KeyCode.Space; designer.Keys[57].width = designer.keyWidth * 5.5f;
        designer.Keys[58].code = KeyCode.AltGr; designer.Keys[58].width = designer.keyWidth;
        designer.Keys[59].code = KeyCode.Menu; designer.Keys[59].width = designer.keyWidth;
        designer.Keys[60].code = KeyCode.RightControl; designer.Keys[60].width = designer.keyWidth;

        UpdateKeys(designer);
    }

    void Korean()
    {
        ClearAll(designer);

        designer.rowKeyCount.Clear();
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(7);

        GenerateKeys(designer);

        //Row 1
        designer.Keys[0].code = KeyCode.BackQuote; designer.Keys[0].width = designer.keyWidth;
        designer.Keys[1].code = KeyCode.Alpha1; designer.Keys[1].width = designer.keyWidth;
        designer.Keys[2].code = KeyCode.Alpha2; designer.Keys[2].width = designer.keyWidth;
        designer.Keys[3].code = KeyCode.Alpha3; designer.Keys[3].width = designer.keyWidth;
        designer.Keys[4].code = KeyCode.Alpha4; designer.Keys[4].width = designer.keyWidth;
        designer.Keys[5].code = KeyCode.Alpha5; designer.Keys[5].width = designer.keyWidth;
        designer.Keys[6].code = KeyCode.Alpha6; designer.Keys[6].width = designer.keyWidth;
        designer.Keys[7].code = KeyCode.Alpha7; designer.Keys[7].width = designer.keyWidth;
        designer.Keys[8].code = KeyCode.Alpha8; designer.Keys[8].width = designer.keyWidth;
        designer.Keys[9].code = KeyCode.Alpha9; designer.Keys[9].width = designer.keyWidth;
        designer.Keys[10].code = KeyCode.Alpha0; designer.Keys[10].width = designer.keyWidth;
        designer.Keys[11].code = KeyCode.Minus; designer.Keys[11].width = designer.keyWidth;
        designer.Keys[12].code = KeyCode.Equals; designer.Keys[12].width = designer.keyWidth;
        designer.Keys[13].code = KeyCode.Backspace; designer.Keys[13].width = designer.keyWidth * 2;

        //Row 2
        designer.Keys[14].code = KeyCode.Tab; designer.Keys[14].width = designer.keyWidth * 1.5f;
        designer.Keys[15].code = KeyCode.A; designer.Keys[15].width = designer.keyWidth;
        designer.Keys[16].code = KeyCode.Z; designer.Keys[16].width = designer.keyWidth;
        designer.Keys[17].code = KeyCode.E; designer.Keys[17].width = designer.keyWidth;
        designer.Keys[18].code = KeyCode.R; designer.Keys[18].width = designer.keyWidth;
        designer.Keys[19].code = KeyCode.T; designer.Keys[19].width = designer.keyWidth;
        designer.Keys[20].code = KeyCode.Y; designer.Keys[20].width = designer.keyWidth;
        designer.Keys[21].code = KeyCode.U; designer.Keys[21].width = designer.keyWidth;
        designer.Keys[22].code = KeyCode.I; designer.Keys[22].width = designer.keyWidth;
        designer.Keys[23].code = KeyCode.O; designer.Keys[23].width = designer.keyWidth;
        designer.Keys[24].code = KeyCode.P; designer.Keys[24].width = designer.keyWidth;
        designer.Keys[25].code = KeyCode.LeftBracket; designer.Keys[25].width = designer.keyWidth;
        designer.Keys[26].code = KeyCode.RightBracket; designer.Keys[26].width = designer.keyWidth;
        designer.Keys[27].code = KeyCode.Return; designer.Keys[27].width = designer.keyWidth * 1.5f;

        //Row 3
        designer.Keys[28].code = KeyCode.CapsLock; designer.Keys[28].width = designer.keyWidth * 2;
        designer.Keys[29].code = KeyCode.Q; designer.Keys[29].width = designer.keyWidth;
        designer.Keys[30].code = KeyCode.S; designer.Keys[30].width = designer.keyWidth;
        designer.Keys[31].code = KeyCode.D; designer.Keys[31].width = designer.keyWidth;
        designer.Keys[32].code = KeyCode.F; designer.Keys[32].width = designer.keyWidth;
        designer.Keys[33].code = KeyCode.G; designer.Keys[33].width = designer.keyWidth;
        designer.Keys[34].code = KeyCode.H; designer.Keys[34].width = designer.keyWidth;
        designer.Keys[35].code = KeyCode.J; designer.Keys[35].width = designer.keyWidth;
        designer.Keys[36].code = KeyCode.K; designer.Keys[36].width = designer.keyWidth;
        designer.Keys[37].code = KeyCode.L; designer.Keys[37].width = designer.keyWidth;
        designer.Keys[38].code = KeyCode.M; designer.Keys[38].width = designer.keyWidth;
        designer.Keys[39].code = KeyCode.Quote; designer.Keys[39].width = designer.keyWidth;
        designer.Keys[40].code = KeyCode.Hash; designer.Keys[40].width = designer.keyWidth;

        //Row 4
        designer.Keys[41].code = KeyCode.LeftShift; designer.Keys[41].width = designer.keyWidth;
        designer.Keys[42].code = KeyCode.Backslash; designer.Keys[42].width = designer.keyWidth;
        designer.Keys[43].code = KeyCode.W; designer.Keys[43].width = designer.keyWidth;
        designer.Keys[44].code = KeyCode.X; designer.Keys[44].width = designer.keyWidth;
        designer.Keys[45].code = KeyCode.C; designer.Keys[45].width = designer.keyWidth;
        designer.Keys[46].code = KeyCode.V; designer.Keys[46].width = designer.keyWidth;
        designer.Keys[47].code = KeyCode.B; designer.Keys[47].width = designer.keyWidth;
        designer.Keys[48].code = KeyCode.N; designer.Keys[48].width = designer.keyWidth;
        designer.Keys[49].code = KeyCode.Question; designer.Keys[49].width = designer.keyWidth;
        designer.Keys[50].code = KeyCode.Comma; designer.Keys[50].width = designer.keyWidth;
        designer.Keys[51].code = KeyCode.Period; designer.Keys[51].width = designer.keyWidth;
        designer.Keys[52].code = KeyCode.Slash; designer.Keys[52].width = designer.keyWidth;
        designer.Keys[53].code = KeyCode.RightShift; designer.Keys[53].width = designer.keyWidth * 2;

        //Row 5
        designer.Keys[54].code = KeyCode.LeftControl; designer.Keys[54].width = designer.keyWidth;
        designer.Keys[55].code = KeyCode.LeftWindows; designer.Keys[55].width = designer.keyWidth;
        designer.Keys[56].code = KeyCode.LeftAlt; designer.Keys[56].width = designer.keyWidth;
        designer.Keys[57].code = KeyCode.Space; designer.Keys[57].width = designer.keyWidth * 5.5f;
        designer.Keys[58].code = KeyCode.AltGr; designer.Keys[58].width = designer.keyWidth;
        designer.Keys[59].code = KeyCode.Menu; designer.Keys[59].width = designer.keyWidth;
        designer.Keys[60].code = KeyCode.RightControl; designer.Keys[60].width = designer.keyWidth;

        UpdateKeys(designer);
    }

    void AlphaNumeric()
    {
        ClearAll(designer);

        designer.rowKeyCount.Clear();
        designer.rowKeyCount.Add(10);
        designer.rowKeyCount.Add(10);
        designer.rowKeyCount.Add(9);
        designer.rowKeyCount.Add(7);
        designer.rowKeyCount.Add(3);

        GenerateKeys(designer);

        //Row 1
        designer.Keys[0].code = KeyCode.Alpha1; designer.Keys[0].width = designer.keyWidth;
        designer.Keys[1].code = KeyCode.Alpha2; designer.Keys[1].width = designer.keyWidth;
        designer.Keys[2].code = KeyCode.Alpha3; designer.Keys[2].width = designer.keyWidth;
        designer.Keys[3].code = KeyCode.Alpha4; designer.Keys[3].width = designer.keyWidth;
        designer.Keys[4].code = KeyCode.Alpha5; designer.Keys[4].width = designer.keyWidth;
        designer.Keys[5].code = KeyCode.Alpha6; designer.Keys[5].width = designer.keyWidth;
        designer.Keys[6].code = KeyCode.Alpha7; designer.Keys[6].width = designer.keyWidth;
        designer.Keys[7].code = KeyCode.Alpha8; designer.Keys[7].width = designer.keyWidth;
        designer.Keys[8].code = KeyCode.Alpha9; designer.Keys[8].width = designer.keyWidth;
        designer.Keys[9].code = KeyCode.Alpha0; designer.Keys[0].width = designer.keyWidth;

        //Row 2
        designer.Keys[10].code = KeyCode.Q; designer.Keys[10].width = designer.keyWidth;
        designer.Keys[11].code = KeyCode.W; designer.Keys[11].width = designer.keyWidth;
        designer.Keys[12].code = KeyCode.E; designer.Keys[12].width = designer.keyWidth;
        designer.Keys[13].code = KeyCode.R; designer.Keys[13].width = designer.keyWidth;
        designer.Keys[14].code = KeyCode.T; designer.Keys[14].width = designer.keyWidth;
        designer.Keys[15].code = KeyCode.Y; designer.Keys[15].width = designer.keyWidth;
        designer.Keys[16].code = KeyCode.U; designer.Keys[16].width = designer.keyWidth;
        designer.Keys[17].code = KeyCode.I; designer.Keys[17].width = designer.keyWidth;
        designer.Keys[18].code = KeyCode.O; designer.Keys[18].width = designer.keyWidth;
        designer.Keys[19].code = KeyCode.P; designer.Keys[19].width = designer.keyWidth;

        //Row 3
        designer.Keys[20].code = KeyCode.A; designer.Keys[20].width = designer.keyWidth;
        designer.Keys[21].code = KeyCode.S; designer.Keys[21].width = designer.keyWidth;
        designer.Keys[22].code = KeyCode.D; designer.Keys[22].width = designer.keyWidth;
        designer.Keys[23].code = KeyCode.F; designer.Keys[23].width = designer.keyWidth;
        designer.Keys[24].code = KeyCode.G; designer.Keys[24].width = designer.keyWidth;
        designer.Keys[25].code = KeyCode.H; designer.Keys[25].width = designer.keyWidth;
        designer.Keys[26].code = KeyCode.J; designer.Keys[26].width = designer.keyWidth;
        designer.Keys[27].code = KeyCode.K; designer.Keys[27].width = designer.keyWidth;
        designer.Keys[28].code = KeyCode.L; designer.Keys[28].width = designer.keyWidth;

        //Row 4
        designer.Keys[29].code = KeyCode.Z; designer.Keys[29].width = designer.keyWidth;
        designer.Keys[30].code = KeyCode.X; designer.Keys[30].width = designer.keyWidth;
        designer.Keys[31].code = KeyCode.C; designer.Keys[31].width = designer.keyWidth;
        designer.Keys[32].code = KeyCode.V; designer.Keys[32].width = designer.keyWidth;
        designer.Keys[33].code = KeyCode.B; designer.Keys[33].width = designer.keyWidth;
        designer.Keys[34].code = KeyCode.N; designer.Keys[34].width = designer.keyWidth;
        designer.Keys[35].code = KeyCode.M; designer.Keys[35].width = designer.keyWidth;

        //Row 5
        designer.Keys[36].code = KeyCode.Space; designer.Keys[36].width = designer.keyWidth * 5.5f;
        designer.Keys[37].code = KeyCode.Backspace; designer.Keys[37].width = designer.keyWidth * 2.5f;
        designer.Keys[38].code = KeyCode.Return; designer.Keys[38].width = designer.keyWidth * 2.5f;

        UpdateKeys(designer);
    }

    void NumberPad()
    {
        ClearAll(designer);

        designer.rowKeyCount.Clear();
        designer.rowKeyCount.Add(3);
        designer.rowKeyCount.Add(3);
        designer.rowKeyCount.Add(3);
        designer.rowKeyCount.Add(2);

        GenerateKeys(designer);

        //Row 1
        designer.Keys[0].code = KeyCode.Keypad7; designer.Keys[0].width = designer.keyWidth;
        designer.Keys[1].code = KeyCode.Keypad8; designer.Keys[1].width = designer.keyWidth;
        designer.Keys[2].code = KeyCode.Keypad9; designer.Keys[2].width = designer.keyWidth;

        //Row 2
        designer.Keys[3].code = KeyCode.Keypad4; designer.Keys[3].width = designer.keyWidth;
        designer.Keys[4].code = KeyCode.Keypad5; designer.Keys[4].width = designer.keyWidth;
        designer.Keys[5].code = KeyCode.Keypad6; designer.Keys[5].width = designer.keyWidth;

        //Row 3
        designer.Keys[6].code = KeyCode.Keypad1; designer.Keys[6].width = designer.keyWidth;
        designer.Keys[7].code = KeyCode.Keypad2; designer.Keys[7].width = designer.keyWidth;
        designer.Keys[8].code = KeyCode.Keypad3; designer.Keys[8].width = designer.keyWidth;

        //Row 4
        designer.Keys[9].code = KeyCode.Keypad0; designer.Keys[9].width = designer.keySpacing + (designer.keyWidth * 2);
        designer.Keys[10].code = KeyCode.KeypadPeriod; designer.Keys[10].width = designer.keyWidth;

        UpdateKeys(designer);
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

    public static void BuildKeyboardKeys(KeyCollectionDesigner designer)
    {
        ClearAll(designer);

        designer.rowKeyCount.Clear();
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(14);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(13);
        designer.rowKeyCount.Add(7);

        GenerateKeys(designer);

        //Row 1
        designer.Keys[0].code = KeyCode.BackQuote; designer.Keys[0].width = designer.keyWidth;
        designer.Keys[1].code = KeyCode.Alpha1; designer.Keys[1].width = designer.keyWidth;
        designer.Keys[2].code = KeyCode.Alpha2; designer.Keys[2].width = designer.keyWidth;
        designer.Keys[3].code = KeyCode.Alpha3; designer.Keys[3].width = designer.keyWidth;
        designer.Keys[4].code = KeyCode.Alpha4; designer.Keys[4].width = designer.keyWidth;
        designer.Keys[5].code = KeyCode.Alpha5; designer.Keys[5].width = designer.keyWidth;
        designer.Keys[6].code = KeyCode.Alpha6; designer.Keys[6].width = designer.keyWidth;
        designer.Keys[7].code = KeyCode.Alpha7; designer.Keys[7].width = designer.keyWidth;
        designer.Keys[8].code = KeyCode.Alpha8; designer.Keys[8].width = designer.keyWidth;
        designer.Keys[9].code = KeyCode.Alpha9; designer.Keys[9].width = designer.keyWidth;
        designer.Keys[10].code = KeyCode.Alpha0; designer.Keys[10].width = designer.keyWidth;
        designer.Keys[11].code = KeyCode.Minus; designer.Keys[11].width = designer.keyWidth;
        designer.Keys[12].code = KeyCode.Equals; designer.Keys[12].width = designer.keyWidth;
        designer.Keys[13].code = KeyCode.Backspace; designer.Keys[13].width = designer.keyWidth * 2;

        //Row 2
        designer.Keys[14].code = KeyCode.Tab; designer.Keys[14].width = designer.keyWidth * 1.5f;
        designer.Keys[15].code = KeyCode.Q; designer.Keys[15].width = designer.keyWidth;
        designer.Keys[16].code = KeyCode.W; designer.Keys[16].width = designer.keyWidth;
        designer.Keys[17].code = KeyCode.E; designer.Keys[17].width = designer.keyWidth;
        designer.Keys[18].code = KeyCode.R; designer.Keys[18].width = designer.keyWidth;
        designer.Keys[19].code = KeyCode.T; designer.Keys[19].width = designer.keyWidth;
        designer.Keys[20].code = KeyCode.Y; designer.Keys[20].width = designer.keyWidth;
        designer.Keys[21].code = KeyCode.U; designer.Keys[21].width = designer.keyWidth;
        designer.Keys[22].code = KeyCode.I; designer.Keys[22].width = designer.keyWidth;
        designer.Keys[23].code = KeyCode.O; designer.Keys[23].width = designer.keyWidth;
        designer.Keys[24].code = KeyCode.P; designer.Keys[24].width = designer.keyWidth;
        designer.Keys[25].code = KeyCode.LeftBracket; designer.Keys[25].width = designer.keyWidth;
        designer.Keys[26].code = KeyCode.RightBracket; designer.Keys[26].width = designer.keyWidth;
        designer.Keys[27].code = KeyCode.Return; designer.Keys[27].width = designer.keyWidth * 1.5f;

        //Row 3
        designer.Keys[28].code = KeyCode.CapsLock; designer.Keys[28].width = designer.keyWidth * 2;
        designer.Keys[29].code = KeyCode.A; designer.Keys[29].width = designer.keyWidth;
        designer.Keys[30].code = KeyCode.S; designer.Keys[30].width = designer.keyWidth;
        designer.Keys[31].code = KeyCode.D; designer.Keys[31].width = designer.keyWidth;
        designer.Keys[32].code = KeyCode.F; designer.Keys[32].width = designer.keyWidth;
        designer.Keys[33].code = KeyCode.G; designer.Keys[33].width = designer.keyWidth;
        designer.Keys[34].code = KeyCode.H; designer.Keys[34].width = designer.keyWidth;
        designer.Keys[35].code = KeyCode.J; designer.Keys[35].width = designer.keyWidth;
        designer.Keys[36].code = KeyCode.K; designer.Keys[36].width = designer.keyWidth;
        designer.Keys[37].code = KeyCode.L; designer.Keys[37].width = designer.keyWidth;
        designer.Keys[38].code = KeyCode.Semicolon; designer.Keys[38].width = designer.keyWidth;
        designer.Keys[39].code = KeyCode.Quote; designer.Keys[39].width = designer.keyWidth;
        designer.Keys[40].code = KeyCode.Hash; designer.Keys[40].width = designer.keyWidth;

        //Row 4
        designer.Keys[41].code = KeyCode.LeftShift; designer.Keys[41].width = designer.keyWidth;
        designer.Keys[42].code = KeyCode.Backslash; designer.Keys[42].width = designer.keyWidth;
        designer.Keys[43].code = KeyCode.Z; designer.Keys[43].width = designer.keyWidth;
        designer.Keys[44].code = KeyCode.X; designer.Keys[44].width = designer.keyWidth;
        designer.Keys[45].code = KeyCode.C; designer.Keys[45].width = designer.keyWidth;
        designer.Keys[46].code = KeyCode.V; designer.Keys[46].width = designer.keyWidth;
        designer.Keys[47].code = KeyCode.B; designer.Keys[47].width = designer.keyWidth;
        designer.Keys[48].code = KeyCode.N; designer.Keys[48].width = designer.keyWidth;
        designer.Keys[49].code = KeyCode.M; designer.Keys[49].width = designer.keyWidth;
        designer.Keys[50].code = KeyCode.Comma; designer.Keys[50].width = designer.keyWidth;
        designer.Keys[51].code = KeyCode.Period; designer.Keys[51].width = designer.keyWidth;
        designer.Keys[52].code = KeyCode.Slash; designer.Keys[52].width = designer.keyWidth;
        designer.Keys[53].code = KeyCode.RightShift; designer.Keys[53].width = designer.keyWidth * 2;

        //Row 5
        designer.Keys[54].code = KeyCode.LeftControl; designer.Keys[54].width = designer.keyWidth;
        designer.Keys[55].code = KeyCode.LeftWindows; designer.Keys[55].width = designer.keyWidth;
        designer.Keys[56].code = KeyCode.LeftAlt; designer.Keys[56].width = designer.keyWidth;
        designer.Keys[57].code = KeyCode.Space; designer.Keys[57].width = designer.keyWidth * 5.5f;
        designer.Keys[58].code = KeyCode.AltGr; designer.Keys[58].width = designer.keyWidth;
        designer.Keys[59].code = KeyCode.Menu; designer.Keys[59].width = designer.keyWidth;
        designer.Keys[60].code = KeyCode.RightControl; designer.Keys[60].width = designer.keyWidth;

        UpdateKeys(designer);
    }

    static void ClearAll(KeyCollectionDesigner designer)
    {
        designer.Keys.Clear();

        if (designer.Container == null)
            return;

        List<GameObject> tList = new List<GameObject>();
        foreach (Transform ob in designer.Container)
        {
            tList.Add(ob.gameObject);
        }

        while (tList.Count > 0)
        {
            var g = tList[0];
            tList.Remove(g);
            if (g != designer.Prototype.gameObject)
                GameObject.DestroyImmediate(g);
        }
    }

    static void GenerateKeys(KeyCollectionDesigner designer)
    {
        if (designer.Container == null)
            return;

        designer.Keys.Clear();

        List<GameObject> tList = new List<GameObject>();
        foreach (Transform ob in designer.Container)
        {
            tList.Add(ob.gameObject);
        }

        while (tList.Count > 0)
        {
            var g = tList[0];
            tList.Remove(g);
            if (g != designer.Prototype.gameObject)
                GameObject.DestroyImmediate(g);
        }

        var vGroup = designer.Container.GetComponent<UnityEngine.UI.VerticalLayoutGroup>();

        if (vGroup == null)
            vGroup = designer.Container.gameObject.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();

        vGroup.spacing = designer.rowSpacing;
        vGroup.childControlHeight = true;
        vGroup.childControlWidth = true;

        int c = 0;
        for (int i = 0; i < designer.rowKeyCount.Count; i++)
        {
            var rGo = new GameObject("Row " + i.ToString());
            rGo.transform.SetParent(designer.Container);
            rGo.transform.localPosition = Vector3.zero;
            rGo.transform.localScale = Vector3.one;
            rGo.AddComponent<RectTransform>();
            var hGroup = rGo.AddComponent<UnityEngine.UI.HorizontalLayoutGroup>();
            hGroup.spacing = designer.keySpacing;
            hGroup.childControlHeight = true;
            hGroup.childControlWidth = true;

            for (int ii = 0; ii < designer.rowKeyCount[i]; ii++)
            {
                var k = GameObject.Instantiate(designer.Prototype.gameObject);
                var kCom = k.GetComponent<KeyCollectionKey>();
                kCom.keyboard = designer.GetComponent<KeyCollection>();
                k.SetActive(true);
                k.name = "Key " + c.ToString();
                c++;
                var kRt = k.GetComponent<RectTransform>();
                kRt.SetParent(rGo.transform);
                kRt.localPosition = Vector3.zero;
                kRt.localScale = Vector3.one;
                var kLe = k.AddComponent<UnityEngine.UI.LayoutElement>();
                kLe.preferredWidth = designer.keyWidth;
                kLe.preferredHeight = designer.keyHeight;


                kCom.EditorParseKeyCode = true;
                kCom.keyGlyph.code = KeyCode.None;
                kCom.keyType = kCom.keyGlyph.DefaultFromCode(KeyCode.None);

                designer.Keys.Add(new KeyRef() { code = KeyCode.None, target = kCom, width = designer.keyWidth });
            }
        }
    }

    static void UpdateKeys(KeyCollectionDesigner designer)
    {
        foreach (var k in designer.Keys)
        {
            k.target.keyGlyph.code = k.code;
            k.target.keyType = k.target.keyGlyph.DefaultFromCode(k.code);
            k.target.GetComponent<UnityEngine.UI.LayoutElement>().preferredWidth = k.width;
            if (k.target.keyGlyph.normalDisplay != null)
                EditorUtility.SetDirty(k.target.keyGlyph.normalDisplay);

            if (k.target.keyGlyph.shiftedDisplay != null)
                EditorUtility.SetDirty(k.target.keyGlyph.shiftedDisplay);

            if (k.target.keyGlyph.altGrDisplay != null)
                EditorUtility.SetDirty(k.target.keyGlyph.altGrDisplay);

            if (k.target.keyGlyph.shiftedAltGrDisplay != null)
                EditorUtility.SetDirty(k.target.keyGlyph.shiftedAltGrDisplay);
        }

        Canvas.ForceUpdateCanvases();
    }
}
