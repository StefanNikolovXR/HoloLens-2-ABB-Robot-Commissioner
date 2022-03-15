using UnityEngine;
using System;
namespace HeathenEngineering.UX.uGUIExtras
{
    [Serializable]
    public class LigatureReference
    {
        [SerializeField]
        public string Ligature;
        [SerializeField]
        public string Characters;        

        public LigatureReference()
        {
            Characters = "";
            Ligature = "";
        }

        public LigatureReference(string Chars, string Lig)
        {
            Characters = Chars;
            Ligature = Lig;
        }

        public bool EndsWith(string value)
        {
            return value.EndsWith(Characters);
        }

        public bool Contains(string value)
        {
            return value.Contains(Characters);
        }

        public string ReplaceAll(string value)
        {
            return value.Replace(Characters, Ligature);
        }

        public string ReplaceEnd(string value)
        {
            if (EndsWith(value))
            {
                return value.Substring(0, value.Length - Characters.Length) + Ligature;
            }
            else
                return value;
        }
    }
}