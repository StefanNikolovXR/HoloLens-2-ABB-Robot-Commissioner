using UnityEngine;
using UnityEditor;
using HeathenEngineering.UX.uGUIExtras;

public class KeyboardMenuItems
{
    [MenuItem("GameObject/UX/uGUI/KeyCollection", false, 43116)]
    public static void CreateKeyboard(MenuCommand menuCommand)
    {
        GameObject parent = menuCommand != null && menuCommand.context != null ? menuCommand.context as GameObject : null;
        
        if(parent == null)
        {
            if (Selection.activeObject != null)
            {
                var upSearch = ((GameObject)Selection.activeObject).GetComponentInParent<Canvas>();
                if (upSearch != null)
                {
                    parent = upSearch.gameObject;
                }
                else
                {
                    var canvas = GameObject.FindObjectOfType<Canvas>();
                    parent = canvas != null ? canvas.gameObject : null;
                }
            }
            else
            {
                var canvas = GameObject.FindObjectOfType<Canvas>();
                parent = canvas != null ? canvas.gameObject : null;
            }
        }

        if(parent == null)
        {
            parent = new GameObject("Canvas", typeof(Canvas));
        }

        GameObject go = new GameObject(GameObjectUtility.GetUniqueNameForSibling(parent != null ? parent.transform : null, "VirtualKeyboard"));
        GameObjectUtility.SetParentAndAlign(go, parent);
        var rt = go.AddComponent<RectTransform>();
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 489);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 209);
        var board = go.AddComponent<KeyCollection>();
        board.useAltGrToggle.Value = true;
        board.useShiftToggle.Value = true;
        go.AddComponent<KeyCollectionOutputManager>();
        
        GameObject temp = new GameObject("Template");
        var tempT = temp.AddComponent<RectTransform>();
        tempT.sizeDelta = new Vector2(35,35);
        GameObjectUtility.SetParentAndAlign(temp, go);
        var im = temp.AddComponent<UnityEngine.UI.Image>();
        im.color = new Color(0.2549f, 0.2667f, 0.329f, 1);
        var btn = temp.AddComponent<UnityEngine.UI.Button>();
        var btnC = btn.colors;
        btnC.highlightedColor = new Color(0.5f, 0.5f, 0.65f, 1);
        btn.colors = btnC;
        var key = temp.AddComponent<KeyCollectionKey>();
        key.keyType = KeyCollectionKeyType.Character;
        key.EditorParseKeyCode = true;
        key.keyGlyph.code = KeyCode.T;

        var kd = go.AddComponent<KeyCollectionDesigner>();
        var kt = go.AddComponent<KeyCollectionTemplateManager>();        
        kd.keyHeight = 40;
        kd.keyWidth = 40;
        kd.keySpacing = 5;
        kd.rowSpacing = 5;
        
        kt.Container = rt;
        kd.Container = rt;
        
        GameObject nt = new GameObject("NormalText");
        var ntRt = nt.AddComponent<RectTransform>();
        var ntT = nt.AddComponent<TMPro.TextMeshProUGUI>();
        ntT.enableAutoSizing = true;
        ntT.fontSizeMin = 8;
        ntT.fontSizeMax = 60;
        ntT.alignment = TMPro.TextAlignmentOptions.Center;
        ntT.color = new Color(0.7817f, 0.7857f, 0.8117f);
        ntT.text = "T";
        ntRt.anchorMin = new Vector2(0.15f, 0.15f);
        ntRt.anchorMax = new Vector2(0.85f, 0.85f);
        key.keyGlyph.normal = ntRt;
        key.keyGlyph.normalDisplay = ntT;
        GameObjectUtility.SetParentAndAlign(nt, temp);
        ntRt.offsetMin = Vector2.zero;
        ntRt.offsetMax = Vector2.zero;

        GameObject st = new GameObject("ShiftText");
        var stRt = st.AddComponent<RectTransform>();
        var stT = st.AddComponent<TMPro.TextMeshProUGUI>();
        stT.enableAutoSizing = true;
        stT.fontSizeMin = 8;
        stT.fontSizeMax = 60;
        stT.alignment = TMPro.TextAlignmentOptions.Center;
        stT.color = new Color(0.7817f, 0.7857f, 0.8117f);
        stT.text = "T";
        stRt.anchorMin = new Vector2(0.15f, 0.15f);
        stRt.anchorMax = new Vector2(0.85f, 0.85f);
        key.keyGlyph.shifted = stRt;
        key.keyGlyph.shiftedDisplay = stT;
        GameObjectUtility.SetParentAndAlign(st, temp);
        stRt.offsetMin = Vector2.zero;
        stRt.offsetMax = Vector2.zero;
        st.SetActive(false);

        GameObject at = new GameObject("AltGrText");
        var atRt = at.AddComponent<RectTransform>();
        var atT = at.AddComponent<TMPro.TextMeshProUGUI>();
        atT.enableAutoSizing = true;
        atT.fontSizeMin = 8;
        atT.fontSizeMax = 60;
        atT.alignment = TMPro.TextAlignmentOptions.Center;
        atT.color = new Color(0.7817f, 0.7857f, 0.8117f);
        atT.text = "T";
        atRt.anchorMin = new Vector2(0.15f, 0.15f);
        atRt.anchorMax = new Vector2(0.85f, 0.85f);
        key.keyGlyph.altGr = atRt;
        key.keyGlyph.altGrDisplay = atT;
        GameObjectUtility.SetParentAndAlign(at, temp);
        atRt.offsetMin = Vector2.zero;
        atRt.offsetMax = Vector2.zero;
        at.SetActive(false);

        GameObject sat = new GameObject("ShiftAltGrText");
        var satRt = sat.AddComponent<RectTransform>();
        var satT = sat.AddComponent<TMPro.TextMeshProUGUI>();
        satT.enableAutoSizing = true;
        satT.fontSizeMin = 8;
        satT.fontSizeMax = 60;
        satT.alignment = TMPro.TextAlignmentOptions.Center;
        satT.color = new Color(0.7817f, 0.7857f, 0.8117f);
        satT.text = "T";
        satRt.anchorMin = new Vector2(0.15f, 0.15f);
        satRt.anchorMax = new Vector2(0.85f, 0.85f);
        key.keyGlyph.shiftedAltGr = satRt;
        key.keyGlyph.shiftedAltGrDisplay = satT;
        GameObjectUtility.SetParentAndAlign(sat, temp);
        satRt.offsetMin = Vector2.zero;
        satRt.offsetMax = Vector2.zero;
        sat.SetActive(false);

        kt.Prototype = key;
        kd.Prototype = key;
        temp.SetActive(false);

        Selection.activeObject = go;
        HeathenKeyboardKeyDesignerEditorScript.BuildKeyboardKeys(kd);
    }

    
}