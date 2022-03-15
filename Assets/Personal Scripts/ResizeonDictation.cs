using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Microsoft.MixedReality.Toolkit.UI
{

    public class ResizeonDictation : MonoBehaviour
    {
        public TextMeshProUGUI DictatedText;
        public GameObject CreatedComment;

        public void ConvertDictatedtoString()
        {
            CreatedComment.GetComponent<ToolTip>().ToolTipText = DictatedText.text;
        }
    }
}