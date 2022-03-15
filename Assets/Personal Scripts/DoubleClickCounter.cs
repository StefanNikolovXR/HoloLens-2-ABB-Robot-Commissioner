using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickCounter : MonoBehaviour
{
    public int counter = 0;
    public GameObject Coordinate;

    public void IncreaseCounterandStartBlink()
    {
        counter++;
        GetComponent<ColorSwitcher>().enable = true;
        StartCoroutine(ResetCounter());

         if (counter==2)
         {
             Coordinate.SetActive(false);
             StopCoroutine(ResetCounter());
         }

     }

     IEnumerator ResetCounter()
     {
         yield return new WaitForSecondsRealtime(3f);
         GetComponent<ColorSwitcher>().enable = false;
         counter = 0;

     }

     public void NullCounterandStopBlink()
     {
        GetComponent<ColorSwitcher>().enable = false;
        counter = 0;
    }
 }

