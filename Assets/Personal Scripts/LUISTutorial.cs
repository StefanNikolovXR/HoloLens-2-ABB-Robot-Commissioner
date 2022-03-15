using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LUISTutorial : MonoBehaviour
{
    public Animator LUISanimator;
    public LunarcomController lunarcomController;

    public void LUISTutorial1()
    {
        LUISanimator.SetBool("Tutorial1", true);
        StartCoroutine(Tutorial1toIdle());
        lunarcomController.outputbox.ToolTipText = "Let's begin! You can take as long as you need to read my messages and practice interactions. When you're ready to proceed, just tap on me from a distance.";
    }

    public void LUISTutorial2()
    {
        LUISanimator.SetBool("Tutorial1", true);
        StartCoroutine(Tutorial1toIdle());
        lunarcomController.outputbox.ToolTipText = "Let's begin! You can take as long as you need to read my messages and practice interactions. When you're ready to proceed, just tap on me from a distance.";
    }

    public void LUISCommandAcceptedCounting()
    {
        LUISanimator.SetBool("CommandAcceptedCounting", true);
        StartCoroutine(CommandAcceptedCounting());
    }

    public void LUISWaveHello()
    {
        LUISanimator.SetBool("WaveHello", true);
        StartCoroutine(WaveHello());
    }

    public void LUISGiveComment()
    {
        LUISanimator.SetBool("GiveComment", true);
        StartCoroutine(GiveComment());
    }

    public void LUISInputValue()
    {
        LUISanimator.SetBool("InputtingValue", true);
        StartCoroutine(InputValue());
    }

    public void LUISRotate()
    {
        LUISanimator.SetBool("Rotate", true);
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(5f);
        LUISanimator.SetBool("Rotate", false);
    }

    IEnumerator InputValue()
    {
        yield return new WaitForSeconds(5f);
        LUISanimator.SetBool("InputtingValue", false);
    }

    IEnumerator GiveComment()
    {
        yield return new WaitForSeconds(3f);
        LUISanimator.SetBool("GiveComment", false);
    }

    IEnumerator Tutorial1toIdle()
    {
        yield return new WaitForSeconds(5f);
        LUISanimator.SetBool("Tutorial1", false);
    }

    IEnumerator CommandAcceptedCounting()
    {
        yield return new WaitForSeconds(5f);
        LUISanimator.SetBool("CommandAcceptedCounting", false);
    }

    IEnumerator WaveHello()
    {
        yield return new WaitForSeconds(5f);
        LUISanimator.SetBool("WaveHello", false);
    }
}
