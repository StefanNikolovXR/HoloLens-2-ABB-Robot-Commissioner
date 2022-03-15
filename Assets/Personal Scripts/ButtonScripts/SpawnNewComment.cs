using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.CognitiveServices.Speech;
using UnityEngine.UI;

public class SpawnNewComment : MonoBehaviour
{
    public LunarcomButtonController lunarcom;

    private GameObject NewComment;

    private Vector3 commentpos;

    public GameObject instantiatedcomment;

    public ToolTip originaloutputbox;

    public GameObject tooltipcontainer;

    public LUISTutorial luis;

    void Start()
    {
        commentpos = new Vector3(0, 0, 0);
    }

    public void SpawnNewCommentonTap()
    {
        if (lunarcom.speechRecognitionMode == RecognitionMode.Speech_Recognizer)
        {
            tooltipcontainer.GetComponent<ToolTip>().ToolTipText = originaloutputbox.ToolTipText;
            NewComment = Instantiate(instantiatedcomment, commentpos, Quaternion.identity);
            NewComment.SetActive(true);
            luis.LUISGiveComment();
        }

        if (lunarcom.speechRecognitionMode == RecognitionMode.Intent_Recognizer)
        {
            lunarcom.ToggleSelected();
        }

    }

}


