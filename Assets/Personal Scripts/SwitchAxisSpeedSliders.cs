using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAxisSpeedSliders : MonoBehaviour
{

    public GameObject negangleslider, posangleslider, minspeedslider, maxspeedslider;
    public GameObject negangleplate, posangleplate, minspeedplate, maxspeedplate;

    public void NegAngleButton ()
    {
        if (negangleslider.activeSelf == false) { 
            negangleslider.SetActive(true);
            posangleslider.SetActive(false);
            negangleplate.SetActive(true);
            posangleplate.SetActive(false);
        }

        else if (negangleslider.activeSelf == true)
        {
            negangleslider.SetActive(false);
            posangleslider.SetActive(true);
            negangleplate.SetActive(false);
            posangleplate.SetActive(true);
        }
    }

    public void PosAngleButton()
    {
        if (posangleslider.activeSelf == false)
        {
            negangleslider.SetActive(false);
            posangleslider.SetActive(true);
            negangleplate.SetActive(false);
            posangleplate.SetActive(true);
        }

        else if (posangleslider.activeSelf == true)
        {
            negangleslider.SetActive(true);
            posangleslider.SetActive(false);
            negangleplate.SetActive(true);
            posangleplate.SetActive(false);
            
        }
    }

    public void MinSpeedButton()
    {
        if (minspeedslider.activeSelf == false)
        {
            minspeedslider.SetActive(true);
            maxspeedslider.SetActive(false);
            minspeedplate.SetActive(true);
            maxspeedplate.SetActive(false);
        }

        else if (minspeedslider.activeSelf == true)
        {
            minspeedslider.SetActive(false);
            maxspeedslider.SetActive(true);
            minspeedplate.SetActive(false);
            maxspeedplate.SetActive(true);
        }
    }

    public void MaxSpeedButton()
    {
        if (maxspeedslider.activeSelf == false)
        {
            minspeedslider.SetActive(false);
            maxspeedslider.SetActive(true);
            minspeedplate.SetActive(false);
            maxspeedplate.SetActive(true);
        }

        else if (maxspeedslider.activeSelf == true)
        {
            minspeedslider.SetActive(true);
            maxspeedslider.SetActive(false);
            minspeedplate.SetActive(true);
            maxspeedplate.SetActive(false);
        }
    }
}
