using UnityEngine;
using UnityEngine.EventSystems;

namespace HeathenEngineering.UX.uGUIExtras
{
    /// <summary>
    /// Represents a keyboard key as used by <see cref="Keyboard"/>
    /// </summary>
    [AddComponentMenu("UX/Key Collection/Key")]
    [RequireComponent(typeof(RectTransform), typeof(UnityEngine.UI.Button))]
    public class KeyCollectionKey : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerExitHandler, ISelectHandler
    {
        /// <summary>
        /// The parent keyboard which the key belongs to
        /// </summary>
        [HideInInspector]
        public KeyCollection keyboard;

        /// <summary>
        /// Defines how the key should be handled when press events occure
        /// </summary>
        [Tooltip("What type of key determins how the key responds when pressed")]
        public KeyCollectionKeyType keyType;
        /// <summary>
        /// Defines the visual representation and the return value on press of the key
        /// </summary>
        [SerializeField]
        public KeyCollectionKeyGlyph keyGlyph;

        public KeyboardKeyStrokeEvent pressed;
        public KeyboardKeyStrokeEvent isDown;
        public KeyboardKeyStrokeEvent isUp;
        public KeyboardKeyStrokeEvent isClicked;
        [HideInInspector]
        public RectTransform selfRectTransform;
        public KeyboardKeyTemplate template;
        private UnityEngine.UI.Button button;
        private bool keyboardFound = false;
        private bool isHeld = false;
        private float holdTime = 0;

        #region Unity Functions
        void Awake()
        {
            selfRectTransform = transform as RectTransform;
            ValidateKeyboard();
        }
        
        // Use this for initialization
        void Start()
        {
            ValidateKeyboard();

            if(button != null)
            {
                button.onClick.AddListener(new UnityEngine.Events.UnityAction(Press));
            }
        }

        void Update()
        {
            if(keyboard != null && keyboard.useKeyHold.Value && isHeld)
            {
                if(holdTime + keyboard.repeateTime.Value < Time.unscaledTime)
                {
                    holdTime = Time.unscaledTime;
                    Press();
                }
            }
        }
        #endregion

        #region Heathen Functions

        public void Selected(BaseEventData data)
        {
            
        }

        public void Press()
        {
            //if(keyType == KeyCollectionKeyType.WhiteSpace || keyType == KeyCollectionKeyType.Backspace || keyType == KeyCollectionKeyType.Delete)
            //{
            //    EditorParseKeyCode = true;
            //    keyGlyph.DefaultFromCode(keyGlyph.code);
            //}

            if (!keyboard.useShiftToggle && (keyGlyph.code == KeyCode.LeftShift || keyGlyph.code == KeyCode.RightShift))
                return;

            if (!keyboard.useAltGrToggle && (keyGlyph.code == KeyCode.AltGr))
                return;
            
            if (pressed != null)
                pressed.Invoke(this);
        }

        public string PressAndParse(string source, int inputIndex = -1)
        {
            Press();
            return ToString(source, inputIndex);
        }

        public KeyCode PressAndCode()
        {
            Press();
            return ToKeyCode();
        }

        public void UpdateTemplate(ref KeyboardKeyTemplate template)
        {
            if (template == null)
                template = keyGlyph;
            else
            {
                template.AltGr = keyGlyph.altGrString;
                template.Shifted = keyGlyph.shiftedString;
                template.Normal = keyGlyph.normalString;
                template.Code = keyGlyph.code;    
            }

            if (selfRectTransform == null)
                selfRectTransform = GetComponent<RectTransform>();

            template.KeyType = keyType;
            template.KeySize = selfRectTransform.sizeDelta;
            template.KeyOffset = selfRectTransform.anchoredPosition3D;
            template.KeyRotation = selfRectTransform.localEulerAngles;

            if (keyGlyph.normalDisplay != null)
                template.DisplayNormal = keyGlyph.normalDisplay.text;

            if (keyGlyph.shiftedDisplay != null)
                template.DisplayShifted = keyGlyph.shiftedDisplay.text;

            if (keyGlyph.altGrDisplay != null)
                template.DisplayAltGr = keyGlyph.altGrDisplay.text;

            if (keyGlyph.shiftedAltGrDisplay != null)
                template.DisplayShiftedAltGr = keyGlyph.shiftedAltGrDisplay.text;
        }

        public KeyboardKeyTemplate ToTemplate()
        {
            KeyboardKeyTemplate template = keyGlyph;
            
            if (selfRectTransform == null)
                selfRectTransform = GetComponent<RectTransform>();

            template.KeySize = selfRectTransform.sizeDelta;
            template.KeyOffset = selfRectTransform.anchoredPosition3D;
            template.KeyRotation = selfRectTransform.localEulerAngles;
            template.KeyType = keyType;

            if (keyGlyph.normalDisplay != null)
                template.DisplayNormal = keyGlyph.normalDisplay.text;

            if (keyGlyph.shiftedDisplay != null)
                template.DisplayShifted = keyGlyph.shiftedDisplay.text;

            if (keyGlyph.altGrDisplay != null)
                template.DisplayAltGr = keyGlyph.altGrDisplay.text;

            if (keyGlyph.shiftedAltGrDisplay != null)
                template.DisplayShiftedAltGr = keyGlyph.shiftedAltGrDisplay.text;

            return template;
        }

        public KeyCode ToKeyCode()
        {
            return keyGlyph.code;
        }

        public override string ToString()
        {
            return ToString("");
        }

        public string ToString(string source, int inputIndex = -1)
        {
            if (keyType == KeyCollectionKeyType.Backspace && !string.IsNullOrEmpty(source))
            {
                if (inputIndex < 0 || inputIndex >= source.Length - 1)
                    return source.Substring(0, source.Length - 1);
                else if (inputIndex > 0)
                    return source.Remove(inputIndex - 1, 1);
                else
                    return source;
            }

            else if (keyType == KeyCollectionKeyType.Delete && !string.IsNullOrEmpty(source) && inputIndex > 0 && inputIndex < source.Length - 1)
                return source.Remove(inputIndex, 1);

            else if (keyType == KeyCollectionKeyType.Modifier && (keyGlyph.code == KeyCode.LeftShift || keyGlyph.code == KeyCode.RightShift || keyGlyph.code == KeyCode.CapsLock))
            {
                switch(keyboard.state)
                {
                    case KeyCollectionKeyState.Normal:
                        keyboard.state = KeyCollectionKeyState.Shifted;
                        break;
                    case KeyCollectionKeyState.Shifted:
                        keyboard.state = KeyCollectionKeyState.Normal;
                        break;
                    case KeyCollectionKeyState.AltGr:
                        keyboard.state = KeyCollectionKeyState.ShiftedAltGr;
                        break;
                    case KeyCollectionKeyState.ShiftedAltGr:
                        keyboard.state = KeyCollectionKeyState.AltGr;
                        break;
                }
                return source;
            }
            else if (keyType == KeyCollectionKeyType.Modifier && keyGlyph.code == KeyCode.AltGr)
            {
                switch (keyboard.state)
                {
                    case KeyCollectionKeyState.Normal:
                        keyboard.state = KeyCollectionKeyState.AltGr;
                        break;
                    case KeyCollectionKeyState.Shifted:
                        keyboard.state = KeyCollectionKeyState.ShiftedAltGr;
                        break;
                    case KeyCollectionKeyState.AltGr:
                        keyboard.state = KeyCollectionKeyState.Normal;
                        break;
                    case KeyCollectionKeyState.ShiftedAltGr:
                        keyboard.state = KeyCollectionKeyState.Shifted;
                        break;
                }
                return source;
            }

            else if (keyType == KeyCollectionKeyType.Character || keyType == KeyCollectionKeyType.WhiteSpace)
            {
                string result = string.IsNullOrEmpty(source) ? "" : source;
                if (inputIndex < 0 || inputIndex >= result.Length - 1)
                {
                    switch (keyboard.state)
                    {
                        case KeyCollectionKeyState.AltGr:
                            return result + keyGlyph.altGrString;
                        case KeyCollectionKeyState.Normal:
                            return result + keyGlyph.normalString;
                        case KeyCollectionKeyState.Shifted:
                            return result + keyGlyph.shiftedString;
                        default:
                            return result + keyGlyph.shiftedAltGrString;
                    }
                }
                else
                {
                    switch (keyboard.state)
                    {
                        case KeyCollectionKeyState.AltGr:
                            return result.Insert(inputIndex, keyGlyph.altGrString);
                        case KeyCollectionKeyState.Normal:
                            return result.Insert(inputIndex, keyGlyph.normalString);
                        case KeyCollectionKeyState.Shifted:
                            return result.Insert(inputIndex, keyGlyph.shiftedString);
                        default:
                            return result.Insert(inputIndex, keyGlyph.shiftedAltGrString);
                    }
                }
            }

            else
                return source;
        }

        public bool ValidateKeyboard()
        {
            button = GetComponent<UnityEngine.UI.Button>();

            keyboardFound = GetKeyboard();

            if(keyGlyph.code == KeyCode.Tab || keyGlyph.code == KeyCode.Space)
            {
                EditorParseKeyCode = true;
                keyGlyph.DefaultFromCode(keyGlyph.code);
            }

            if (keyboardFound)
                keyboard.RegisterKey(this);
            return keyboardFound && button != null;
        }

        private bool GetKeyboard()
        {
            if (keyboard == null)
                keyboard = GetComponentInParent<KeyCollection>();

            return keyboard != null;
        }

        //TODO: temp multi touch support event handlers
        #region Temp multi-touch support
        public void OnPointerDown(PointerEventData eventData)
        {
            isHeld = true;
            holdTime = Time.unscaledTime;

            if (isDown != null)
                isDown.Invoke( this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHeld = false;

            if (isUp != null)
                isUp.Invoke(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (isClicked != null)
                isClicked.Invoke(this);

            //Only call pressed if there is no button and we are not a modifier type key
            if (button == null && keyType != KeyCollectionKeyType.Modifier)
            {
                if (pressed != null)
                    pressed.Invoke(this);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isHeld = false;
        }

        public void OnSelect(BaseEventData eventData)
        {
            keyboard.ActiveKey = this;
        }
        #endregion

        #endregion

        public bool EditorParseKeyCode;
    }
}
