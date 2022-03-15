using UnityEngine;

namespace HeathenEngineering.UX
{
    [System.Serializable]
    public class CursorAnimation
    {
        public bool loop = false;
        public Texture2D[] textureArray;
        public float framesPerSecond = 30;
    }
}
