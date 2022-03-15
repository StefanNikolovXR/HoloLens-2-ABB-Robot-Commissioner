using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUISHovered : MonoBehaviour
{
    public Animator LUISanimator;
    public LunarcomController lunarcomController;
    private bool wavehello = true;

    public void OpeningWaveGesture()
    {
        if (wavehello) { 
            LUISanimator.SetBool("WaveHello", true);
            StartCoroutine(WaveHello());
            lunarcomController.outputbox.ToolTipText = "Hello and welcome to Rapid Robot Commissioner! My name is LUIS and I will be your virtual assistant. If you are a first time user and you'd like to go through a tutorial, please walk up and press the button in front of me.";
            wavehello = false;
        }
    }

IEnumerator WaveHello()
{
    yield return new WaitForSeconds(3f);
    LUISanimator.SetBool("WaveHello", false);
}
}
