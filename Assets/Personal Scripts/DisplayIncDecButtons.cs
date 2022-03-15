using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIncDecButtons : MonoBehaviour
{
    public GameObject increasebutton;
    public GameObject decreasebutton;
    public GameObject sidestext;
    public GameObject setupbutton;

    public void DisplayafterDelay()
    {
        sidestext.SetActive(true);
        setupbutton.SetActive(false);
        StartCoroutine(Wait1Second());
        increasebutton.SetActive(true);
        decreasebutton.SetActive(true);
        
    }

    IEnumerator Wait1Second()
    {
        yield return new WaitForSecondsRealtime(1.5f);
    }
}
