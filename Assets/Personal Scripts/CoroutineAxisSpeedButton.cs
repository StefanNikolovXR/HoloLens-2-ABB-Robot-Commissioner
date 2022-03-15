using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineAxisSpeedButton : MonoBehaviour
{

    public GameObject button1, button2, button3, buttoncollection;

    public void TriggerButtonWait()
    {
        StartCoroutine(ButtonWaittoAppear());
    }

    public void TriggerButtonWaitDown()
    {
        StartCoroutine(ButtonWaittoAppearDown());
    }

    IEnumerator ButtonWaittoAppear()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        button1.SetActive(false);
        button2.SetActive(true);
    }

    IEnumerator ButtonWaittoAppearDown()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        buttoncollection.SetActive(false);
        button3.SetActive(true);
        button1.SetActive(false);
    }

}
