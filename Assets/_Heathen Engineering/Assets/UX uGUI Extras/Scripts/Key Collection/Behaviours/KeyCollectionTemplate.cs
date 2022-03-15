using UnityEngine;

namespace HeathenEngineering.UX.uGUIExtras
{
    public class KeyCollectionTemplate
    {
        private string templateName;
        public string TemplateName
        {
            get { return templateName; }
            set { templateName = value; }
        }

        /// <summary>
        /// Can be null, typically used for function keys if at all
        /// </summary>
        private KeyboardTemplateRow headerRow;
        public KeyboardTemplateRow HeaderRow
        {
            get { return headerRow; }
            set { headerRow = value; }
        }
        /// <summary>
        /// The main set of keys
        /// </summary>
        private KeyboardTemplateRow[] primaryRows;
        public KeyboardTemplateRow[] PrimaryRows
        {
            get { return primaryRows; }
            set { primaryRows = value; }
        }
    }

    public class KeyboardTemplateRow
    {
        private KeyboardKeyTemplate[] keys;
        public KeyboardKeyTemplate[] Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        private Vector3 rowOffset;
        public Vector3 RowOffset
        {
            get { return rowOffset; }
            set { rowOffset = value; }
        }

        private Vector3 rowRotation;
        public Vector3 RowRotation
        {
            get { return rowRotation; }
            set { rowRotation = value; }
        }
    }

    public class KeyboardKeyTemplate
    {
        private KeyCollectionKeyType keyType;
        public KeyCollectionKeyType KeyType
        {
            get { return keyType; }
            set { keyType = value; }
        }

        private KeyCode code;
        public KeyCode Code
        {
            get { return code; }
            set { code = value; }
        }

        private string normal;
        public string Normal
        {
            get { return normal; }
            set { normal = value; }
        }

        private string shifted;
        public string Shifted
        {
            get { return shifted; }
            set { shifted = value; }
        }

        private string altGr;
        public string AltGr
        {
            get { return altGr; }
            set { altGr = value; }
        }

        private string shiftedAltGr;
        public string ShiftedAltGr
        {
            get { return shiftedAltGr; }
            set { shiftedAltGr = value; }
        }

        private string displayNormal;
        public string DisplayNormal
        {
            get { return displayNormal; }
            set { displayNormal = value; }
        }

        private string displayShifted;
        public string DisplayShifted
        {
            get { return displayShifted; }
            set { displayShifted = value; }
        }

        private string displayAltGr;
        public string DisplayAltGr
        {
            get { return displayAltGr; }
            set { displayAltGr = value; }
        }

        private string displayShiftedAltGr;
        public string DisplayShiftedAltGr
        {
            get { return displayShiftedAltGr; }
            set { displayShiftedAltGr = value; }
        }

        private Vector2 keySize;
        public Vector2 KeySize
        {
            get { return keySize; }
            set { keySize = value; }
        }

        private Vector3 keyOffset;
        public Vector3 KeyOffset
        {
            get { return keyOffset; }
            set { keyOffset = value; }
        }

        private Vector3 keyRotation;
        public Vector3 KeyRotation
        {
            get { return keyRotation; }
            set { keyRotation = value; }
        }
    }
}
