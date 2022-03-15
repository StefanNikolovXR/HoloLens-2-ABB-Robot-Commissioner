using UnityEngine;
using System;

namespace HeathenEngineering.UX.uGUIExtras
{

    [Serializable]
    public struct KeyCollectionKeyGlyph
    {
        [SerializeField]
        public Transform normal;
        [SerializeField]
        public string normalString;
        [SerializeField]
        public TMPro.TextMeshProUGUI normalDisplay;
        [SerializeField]
        public Transform shifted;
        [SerializeField]
        public string shiftedString;
        [SerializeField]
        public TMPro.TextMeshProUGUI shiftedDisplay;
        [SerializeField]
        public Transform altGr;
        [SerializeField]
        public string altGrString;
        [SerializeField]
        public TMPro.TextMeshProUGUI altGrDisplay;
        [SerializeField]
        public Transform shiftedAltGr;
        [SerializeField]
        public string shiftedAltGrString;
        [SerializeField]
        public TMPro.TextMeshProUGUI shiftedAltGrDisplay;
        [SerializeField]
        public KeyCode code;

        public static implicit operator KeyboardKeyTemplate(KeyCollectionKeyGlyph value)
        {
            KeyboardKeyTemplate template = new KeyboardKeyTemplate();

            template.AltGr = value.altGrString;
            template.ShiftedAltGr = value.shiftedAltGrString;
            template.Shifted = value.shiftedString;
            template.Normal = value.normalString;
            template.Code = value.code;

            if (value.normalDisplay != null)
                template.DisplayNormal = value.normalDisplay.text;

            if (value.shiftedDisplay != null)
                template.DisplayShifted = value.shiftedDisplay.text;

            if (value.altGrDisplay != null)
                template.DisplayAltGr = value.altGrDisplay.text;

            if (value.shiftedAltGrDisplay != null)
                template.DisplayShiftedAltGr = value.shiftedAltGrDisplay.text;

            return template;
        }

        public void Set(KeyGlyphData keyGlyph)
        {
            normalDisplay.text = keyGlyph.normal;
            shiftedDisplay.text = keyGlyph.shifted;
            altGrDisplay.text = keyGlyph.altGr;
            shiftedAltGrDisplay.text = keyGlyph.altGrShifted;
            normalString = keyGlyph.normal;
            shiftedString = keyGlyph.shifted;
            altGrString = keyGlyph.altGr;
            shiftedAltGrString = keyGlyph.altGrShifted;
            code = keyGlyph.code;
        }

        public KeyCollectionKeyType DefaultFromCode(KeyCode code)
        {
            KeyCollectionKeyType rVal = KeyCollectionKeyType.Character;
            this.code = code;
            if (code == KeyCode.Space || code == KeyCode.LeftArrow || code == KeyCode.UpArrow || code == KeyCode.RightArrow || code == KeyCode.DownArrow)
            {
                if (normalDisplay != null)
                    normalDisplay.text = "";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "";

                if (altGrDisplay != null)
                    altGrDisplay.text = "";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "";

                if (code == KeyCode.Space)
                {
                    rVal = KeyCollectionKeyType.WhiteSpace;
                    normalString = " ";
                    shiftedString = " ";
                    altGrString = " ";
                    shiftedAltGrString = " ";
                }
                else
                {
                    rVal = KeyCollectionKeyType.Modifier;
                    normalString = "";
                    shiftedString = "";
                    altGrString = "";
                    shiftedAltGrString = "";
                }
            }
            else if (code == KeyCode.CapsLock || code == KeyCode.Return || code == KeyCode.Tab || code == KeyCode.Escape || code == KeyCode.Backspace || code == KeyCode.Break || code == KeyCode.Pause || code == KeyCode.ScrollLock || code == KeyCode.Print || code == KeyCode.Delete || code == KeyCode.PageDown || code == KeyCode.PageUp || code == KeyCode.Insert || code == KeyCode.Numlock || code == KeyCode.End || code == KeyCode.Home || code == KeyCode.AltGr || code == KeyCode.Menu || code == KeyCode.SysReq)
            {
                if (code == KeyCode.Escape)
                {
                    if (normalDisplay != null)
                        normalDisplay.text = "Esc";

                    if (shiftedDisplay != null)
                        shiftedDisplay.text = "Esc";

                    if (altGrDisplay != null)
                        altGrDisplay.text = "Esc";

                    if (shiftedAltGrDisplay != null)
                        shiftedAltGrDisplay.text = "Esc";
                }
                else if (code == KeyCode.Print)
                {
                    if (normalDisplay != null)
                        normalDisplay.text = "Prt Scrn";

                    if (shiftedDisplay != null)
                        shiftedDisplay.text = "Prt Scrn";

                    if (altGrDisplay != null)
                        altGrDisplay.text = "Prt Scrn";

                    if (shiftedAltGrDisplay != null)
                        shiftedAltGrDisplay.text = "Prt Scrn";
                }
                else
                {
                    if (normalDisplay != null)
                        normalDisplay.text = code.ToString();

                    if (shiftedDisplay != null)
                        shiftedDisplay.text = code.ToString();

                    if (altGrDisplay != null)
                        altGrDisplay.text = code.ToString();

                    if (shiftedAltGrDisplay != null)
                        shiftedAltGrDisplay.text = code.ToString();
                }

                if(code == KeyCode.Return)
                {
                    rVal = KeyCollectionKeyType.WhiteSpace;
                    normalString = "\n";
                    shiftedString = "\n";
                    altGrString = "\n";
                    shiftedAltGrString = "\n";
                }
                else if (code == KeyCode.Tab)
                {
                    rVal = KeyCollectionKeyType.WhiteSpace;
                    normalString = "\t";
                    shiftedString = "\t";
                    altGrString = "\t";
                    shiftedAltGrString = "\t";
                }
                else
                {
                    if (code == KeyCode.Backspace || code == KeyCode.Delete)
                        rVal = KeyCollectionKeyType.Backspace;
                    else
                        rVal = KeyCollectionKeyType.Function;

                    normalString = "";
                    shiftedString = "";
                    altGrString = "";
                    shiftedAltGrString = "";
                }
            }
            else if (code == KeyCode.LeftAlt || code == KeyCode.RightAlt)
            {
                rVal = KeyCollectionKeyType.Modifier;

                if (normalDisplay != null)
                    normalDisplay.text = "Alt";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Alt";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Alt";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Alt";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.LeftApple || code == KeyCode.RightApple)
            {
                rVal = KeyCollectionKeyType.Modifier;

                if (normalDisplay != null)
                    normalDisplay.text = "Apple";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Apple";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Apple";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Apple";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.LeftCommand || code == KeyCode.RightCommand)
            {
                rVal = KeyCollectionKeyType.Function;

                if (normalDisplay != null)
                    normalDisplay.text = "Command";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Command";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Command";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Command";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.LeftControl || code == KeyCode.RightControl)
            {
                rVal = KeyCollectionKeyType.Function;

                if (normalDisplay != null)
                    normalDisplay.text = "Ctrl";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Ctrl";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Ctrl";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Ctrl";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.LeftShift || code == KeyCode.RightShift)
            {
                rVal = KeyCollectionKeyType.Modifier;

                if (normalDisplay != null)
                    normalDisplay.text = "Shift";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Shift";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Shift";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Shift";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.LeftWindows || code == KeyCode.RightWindows)
            {
                rVal = KeyCollectionKeyType.Function;

                if (normalDisplay != null)
                    normalDisplay.text = "Win";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Win";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Win";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Win";

                normalString = "";
                shiftedString = "";
                altGrString = "";
                shiftedAltGrString = "";
            }
            else if (code == KeyCode.KeypadEnter)
            {
                rVal = KeyCollectionKeyType.WhiteSpace;

                if (normalDisplay != null)
                    normalDisplay.text = "Enter";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "Enter";

                if (altGrDisplay != null)
                    altGrDisplay.text = "Enter";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "Enter";

                normalString = "\n";
                shiftedString = "\n";
                altGrString = "\n";
                shiftedAltGrString = "\n";
            }
            else if (code == KeyCode.Period)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = ".";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = ">";

                if (altGrDisplay != null)
                    altGrDisplay.text = ".";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = ">";

                normalString = ".";
                shiftedString = ">";
                altGrString = ".";
                shiftedAltGrString = ">";
            }
            else if (code == KeyCode.KeypadPeriod)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = ".";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = ".";

                if (altGrDisplay != null)
                    altGrDisplay.text = ".";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = ".";

                normalString = ".";
                shiftedString = ".";
                altGrString = ".";
                shiftedAltGrString = ".";
            }
            else if (code == KeyCode.Exclaim)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "1";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "!";

                if (altGrDisplay != null)
                    altGrDisplay.text = "!";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "1";

                normalString = "1";
                shiftedString = "!";
                altGrString = "1";
                shiftedAltGrString = "!";
            }
            else if (code == KeyCode.LeftBracket)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "[";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "{";

                if (altGrDisplay != null)
                    altGrDisplay.text = "[";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "{";

                normalString = "[";
                shiftedString = "{";
                altGrString = "[";
                shiftedAltGrString = "{";
            }
            else if (code == KeyCode.RightBracket)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "]";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "}";

                if (altGrDisplay != null)
                    altGrDisplay.text = "]";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "}";

                normalString = "]";
                shiftedString = "}";
                altGrString = "]";
                shiftedAltGrString = "}";
            }
            else if (code == KeyCode.Hash)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "#";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "~";

                if (altGrDisplay != null)
                    altGrDisplay.text = "#";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "~";

                normalString = "#";
                shiftedString = "~";
                altGrString = "#";
                shiftedAltGrString = "~";
            }
            else if (code == KeyCode.BackQuote)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "`";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "¬";

                if (altGrDisplay != null)
                    altGrDisplay.text = "¦";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "¦";

                normalString = "`";
                shiftedString = "¬";
                altGrString = "¦";
                shiftedAltGrString = "¦";
            }
            else if (code == KeyCode.Alpha4)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "4";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "$";

                if (altGrDisplay != null)
                    altGrDisplay.text = "€";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "€";

                normalString = "4";
                shiftedString = "$";
                altGrString = "€";
                shiftedAltGrString = "€";
            }
            else if (code == KeyCode.Backslash)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "\\";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "|";

                if (altGrDisplay != null)
                    altGrDisplay.text = "\\";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "|";

                normalString = "\\";
                shiftedString = "|";
                altGrString = "\\";
                shiftedAltGrString = "|";
            }
            else if (code == KeyCode.Less || code == KeyCode.Comma)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = ",";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "<";

                if (altGrDisplay != null)
                    altGrDisplay.text = ",";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "<";

                normalString = ",";
                shiftedString = "<";
                altGrString = ",";
                shiftedAltGrString = "<";
            }
            else if (code == KeyCode.Greater)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = ".";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = ">";

                if (altGrDisplay != null)
                    altGrDisplay.text = ".";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = ">";

                normalString = ".";
                shiftedString = ">";
                altGrString = ".";
                shiftedAltGrString = ">";
            }
            else if (code == KeyCode.Equals || code == KeyCode.Plus)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "=";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "+";

                if (altGrDisplay != null)
                    altGrDisplay.text = "=";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "+";

                normalString = "=";
                shiftedString = "+";
                altGrString = "=";
                shiftedAltGrString = "+";
            }
            else if (code == KeyCode.KeypadDivide)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "/";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "/";

                if (altGrDisplay != null)
                    altGrDisplay.text = "/";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "/";

                normalString = "/";
                shiftedString = "/";
                altGrString = "/";
                shiftedAltGrString = "/";
            }
            else if (code == KeyCode.Dollar)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "$";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "$";

                if (altGrDisplay != null)
                    altGrDisplay.text = "$";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "$";

                normalString = "$";
                shiftedString = "$";
                altGrString = "$";
                shiftedAltGrString = "$";
            }
            else if (code == KeyCode.DoubleQuote)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "\"";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "\"";

                if (altGrDisplay != null)
                    altGrDisplay.text = "\"";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "\"";

                normalString = "\"";
                shiftedString = "\"";
                altGrString = "\"";
                shiftedAltGrString = "\"";
            }
            else if (code == KeyCode.Colon || code == KeyCode.Semicolon)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = ";";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = ":";

                if (altGrDisplay != null)
                    altGrDisplay.text = ";";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = ":";

                normalString = ";";
                shiftedString = ":";
                altGrString = ";";
                shiftedAltGrString = ":";
            }
            else if (code == KeyCode.Question || code == KeyCode.Slash)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "/";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "?";

                if (altGrDisplay != null)
                    altGrDisplay.text = "/";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "?";

                normalString = ".";
                shiftedString = ">";
                altGrString = ".";
                shiftedAltGrString = ">";
            }
            else if (code == KeyCode.Asterisk || code == KeyCode.KeypadMultiply)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "*";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "*";

                if (altGrDisplay != null)
                    altGrDisplay.text = "*";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "*";

                normalString = "*";
                shiftedString = "*";
                altGrString = "*";
                shiftedAltGrString = "*";
            }
            else if (code == KeyCode.KeypadMinus)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "-";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "-";

                if (altGrDisplay != null)
                    altGrDisplay.text = "-";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "-";

                normalString = "-";
                shiftedString = "-";
                altGrString = "-";
                shiftedAltGrString = "-";
            }
            else if (code == KeyCode.KeypadPlus)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "+";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "+";

                if (altGrDisplay != null)
                    altGrDisplay.text = "+";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "+";

                normalString = "+";
                shiftedString = "+";
                altGrString = "+";
                shiftedAltGrString = "+";
            }
            else if (code == KeyCode.Quote || code == KeyCode.At)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "'";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "@";

                if (altGrDisplay != null)
                    altGrDisplay.text = "'";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "'";

                normalString = "'";
                shiftedString = "@";
                altGrString = "'";
                shiftedAltGrString = "@";
            }
            else if (code == KeyCode.Minus || code == KeyCode.Underscore)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "-";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "_";

                if (altGrDisplay != null)
                    altGrDisplay.text = "-";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "_";

                normalString = "-";
                shiftedString = "_";
                altGrString = "-";
                shiftedAltGrString = "_";
            }
            else if (code == KeyCode.Alpha0)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "0";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = ")";

                if (altGrDisplay != null)
                    altGrDisplay.text = "0";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = ")";

                normalString = "0";
                shiftedString = ")";
                altGrString = "0";
                shiftedAltGrString = ")";
            }
            else if (code == KeyCode.Alpha1)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "1";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "!";

                if (altGrDisplay != null)
                    altGrDisplay.text = "1";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "!";

                normalString = "1";
                shiftedString = "!";
                altGrString = "1";
                shiftedAltGrString = "!";
            }
            else if (code == KeyCode.Alpha2)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "2";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "\"";

                if (altGrDisplay != null)
                    altGrDisplay.text = "2";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "\"";

                normalString = "2";
                shiftedString = "\"";
                altGrString = "2";
                shiftedAltGrString = "\"";
            }
            else if (code == KeyCode.Alpha3)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "3";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "£";

                if (altGrDisplay != null)
                    altGrDisplay.text = "3";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "£";

                normalString = "3";
                shiftedString = "£";
                altGrString = "3";
                shiftedAltGrString = "£";
            }
            else if (code == KeyCode.Alpha5)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "5";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "%";

                if (altGrDisplay != null)
                    altGrDisplay.text = "5";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "%";

                normalString = "5";
                shiftedString = "%";
                altGrString = "5";
                shiftedAltGrString = "%";
            }
            else if (code == KeyCode.Alpha6)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "6";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "^";

                if (altGrDisplay != null)
                    altGrDisplay.text = "6";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "^";

                normalString = "6";
                shiftedString = "^";
                altGrString = "6";
                shiftedAltGrString = "^";
            }
            else if (code == KeyCode.Alpha7)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "7";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "&";

                if (altGrDisplay != null)
                    altGrDisplay.text = "7";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "&";

                normalString = "7";
                shiftedString = "&";
                altGrString = "7";
                shiftedAltGrString = "&";
            }
            else if (code == KeyCode.Alpha8)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "8";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "*";

                if (altGrDisplay != null)
                    altGrDisplay.text = "8";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "*";

                normalString = "8";
                shiftedString = "*";
                altGrString = "8";
                shiftedAltGrString = "*";
            }
            else if (code == KeyCode.Alpha9)
            {
                rVal = KeyCollectionKeyType.Character;

                if (normalDisplay != null)
                    normalDisplay.text = "9";

                if (shiftedDisplay != null)
                    shiftedDisplay.text = "(";

                if (altGrDisplay != null)
                    altGrDisplay.text = "9";

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = "(";

                normalString = "9";
                shiftedString = "(";
                altGrString = "9";
                shiftedAltGrString = "(";
            }
            else
            {
                rVal = KeyCollectionKeyType.Character;

                normalString = code.ToString().ToLower().Replace("alpha", "").Replace(" ", "").Replace("keypad", "");
                shiftedString = code.ToString().ToUpper().Replace("ALPHA", "").Replace(" ", "").Replace("KEYPAD", ""); ;
                altGrString = code.ToString().ToLower().Replace("alpha", "").Replace(" ", "").Replace("keypad", ""); ;
                shiftedAltGrString = code.ToString().ToUpper().Replace("ALPHA", "").Replace(" ", "").Replace("KEYPAD", ""); ;

                if (code == KeyCode.A)
                {
                    altGrString = "á";
                    shiftedAltGrString = "Á";
                }
                else if (code == KeyCode.E)
                {
                    altGrString = "é";
                    shiftedAltGrString = "É";
                }
                else if (code == KeyCode.I)
                {
                    altGrString = "í";
                    shiftedAltGrString = "Í";
                }
                else if (code == KeyCode.O)
                {
                    altGrString = "ó";
                    shiftedAltGrString = "Ó";
                }
                else if (code == KeyCode.U)
                {
                    altGrString = "ú";
                    shiftedAltGrString = "Ú";
                }

                if (normalDisplay != null)
                    normalDisplay.text = normalString;

                if (shiftedDisplay != null)
                    shiftedDisplay.text = shiftedString;

                if (altGrDisplay != null)
                    altGrDisplay.text = altGrString;

                if (shiftedAltGrDisplay != null)
                    shiftedAltGrDisplay.text = shiftedAltGrString;
                
            }
            return rVal;
        }

        public void ApplyTemplate(KeyboardKeyTemplate template)
        {
            DefaultFromCode(code);

            normalString = template.Normal;
            shiftedString = template.Shifted;
            altGrString = template.AltGr;
            shiftedAltGrString = template.ShiftedAltGr;
        }
    }
}
