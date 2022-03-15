using UnityEngine;
using System.Collections.Generic;
using System;

namespace HeathenEngineering.UX.uGUIExtras
{
    [AddComponentMenu("UX/Key Collection/Key Collection Designer")]
    [RequireComponent(typeof(KeyCollection))]
    public class KeyCollectionDesigner : MonoBehaviour
    {
        public KeyCollectionKey Prototype;
        public RectTransform Container;
        
        public List<int> rowKeyCount = new List<int>();
        public float keyWidth;
        public float keyHeight;
        public float rowSpacing;
        public float keySpacing;
        
        public List<KeyRef> Keys = new List<KeyRef>();
        
        public void GenerateKeys()
        {
            if (Container == null)
                return;

            Keys.Clear();

            List<GameObject> tList = new List<GameObject>();
            foreach (Transform ob in Container)
            {
                tList.Add(ob.gameObject);
            }

            while(tList.Count > 0)
            {
                var g = tList[0];
                tList.Remove(g);
                if (g != Prototype.gameObject)
                    GameObject.DestroyImmediate(g);
            }

            var vGroup = Container.GetComponent<UnityEngine.UI.VerticalLayoutGroup>();

            if (vGroup == null)
                vGroup = Container.gameObject.AddComponent<UnityEngine.UI.VerticalLayoutGroup>();

            vGroup.spacing = rowSpacing;
            vGroup.childControlHeight = true;
            vGroup.childControlWidth = true;

            var contextSpace = Container.GetComponent<UnityEngine.UI.ContentSizeFitter>();

            if (contextSpace == null)
                contextSpace = Container.gameObject.AddComponent<UnityEngine.UI.ContentSizeFitter>();

            contextSpace.horizontalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;
            contextSpace.verticalFit = UnityEngine.UI.ContentSizeFitter.FitMode.PreferredSize;

            int c = 0;
            for (int i = 0; i < rowKeyCount.Count; i++)
            {
                var rGo = new GameObject("Row " + i.ToString());
                rGo.transform.SetParent(Container);
                rGo.transform.localPosition = Vector3.zero;
                rGo.transform.localScale = Vector3.one;
                rGo.AddComponent<RectTransform>();
                var hGroup = rGo.AddComponent<UnityEngine.UI.HorizontalLayoutGroup>();
                hGroup.spacing = keySpacing;
                hGroup.childControlHeight = true;
                hGroup.childControlWidth = true;

                for (int ii = 0; ii < rowKeyCount[i]; ii++)
                {
                    var k = Instantiate(Prototype.gameObject);
                    k.name = "Key " + c.ToString();
                    c++;
                    var kRt = k.GetComponent<RectTransform>();
                    kRt.SetParent(rGo.transform);
                    kRt.localPosition = Vector3.zero;
                    kRt.localScale = Vector3.one;
                    var kLe = k.AddComponent<UnityEngine.UI.LayoutElement>();
                    kLe.minWidth = keyWidth;
                    kLe.minHeight = keyHeight;

                    var kCom = k.GetComponent<KeyCollectionKey>();
                    kCom.EditorParseKeyCode = true;
                    kCom.keyGlyph.code = KeyCode.K;
                    kCom.keyType = kCom.keyGlyph.DefaultFromCode(KeyCode.K);

                    Keys.Add(new KeyRef() { code = KeyCode.K, target = kCom, width = keyWidth });
                }
            }
        }

        public void UpdateKeys()
        {
            foreach (var k in Keys)
            {
                k.target.keyGlyph.code = k.code;
                k.target.keyType = k.target.keyGlyph.DefaultFromCode(k.code);
                k.target.GetComponent<UnityEngine.UI.LayoutElement>().minWidth = k.width;
            }
        }
    }

    [Serializable]
    public class KeyRef
    {
        public float width;
        public KeyCode code;
        public KeyCollectionKey target;
    }
}
