using UnityEngine;

namespace HeathenEngineering.UX.uGUIExtras
{
    [AddComponentMenu("UX/Ligature/Ligature Helper")]
    public class LigatureHelper : MonoBehaviour
    {
        /// <summary>
        /// List of ligatures to test for
        /// </summary>
        public LigatureLibrary library;

        private UnityEngine.UI.InputField field;
        private TMPro.TMP_InputField tmp_inputField;

        private void Start()
        {
            field = GetComponent<UnityEngine.UI.InputField>();
            if (field != null)
                field.onValueChanged.AddListener(ParseAll);

            tmp_inputField = GetComponent<TMPro.TMP_InputField>();
            if (tmp_inputField != null)
                tmp_inputField.onValueChanged.AddListener(ParseAll);
        }

        public void ParseAll(string value)
        {
            if (library == null)
                return;

            var r = library.ParseAll(value);
            if (value != r)
            {
                if (tmp_inputField != null)
                    tmp_inputField.text = r;
                if (field != null)
                    field.text = r;
            }
        }
    }
}