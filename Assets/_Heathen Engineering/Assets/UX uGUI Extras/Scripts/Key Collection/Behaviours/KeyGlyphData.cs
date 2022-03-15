using UnityEngine;
using System;

namespace HeathenEngineering.UX.uGUIExtras
{
    [Serializable]
    public struct KeyGlyphData
    {
        public string normal;
        public string shifted;
        public string altGr;
        public string altGrShifted;
        public KeyCode code;

        public KeyGlyphData(KeyCollectionKeyGlyph glyph)
        {
            normal = glyph.normalDisplay.text;
            shifted = glyph.shiftedDisplay.text;
            altGr = glyph.altGrDisplay.text;
            altGrShifted = glyph.shiftedAltGrDisplay.text;
            code = glyph.code;
        }
    }
}
