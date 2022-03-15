using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallButtonBlinker : MonoBehaviour
{
    private bool preventblink = false;

    public void StartandStopBlink()
    {
        if(!preventblink) { 
        GetComponent<ColorSwitcher>().enable = true;
        StartCoroutine(TimeoutBlink());
        }
    }

    IEnumerator TimeoutBlink()
    {
        preventblink = true;
        yield return new WaitForSecondsRealtime(1f);
        GetComponent<ColorSwitcher>().enable = false;
        preventblink = false;
        }

    }



