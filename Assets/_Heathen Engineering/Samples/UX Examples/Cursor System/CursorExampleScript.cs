using UnityEngine;

namespace HeathenEngineering.UX
{
    public class CursorExampleScript : MonoBehaviour
    {
        public string kbUrl;
        public string discordUrl;
        public string assetUrl;

        public void OpenKb()
        {
            UnityEngine.Application.OpenURL(kbUrl);
        }

        public void OpenDiscord()
        {
            UnityEngine.Application.OpenURL(discordUrl);
        }

        public void OpenAsset()
        {
            UnityEngine.Application.OpenURL(assetUrl);
        }
    }
}
