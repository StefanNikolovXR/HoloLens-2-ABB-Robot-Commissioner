using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System.Runtime.InteropServices;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;

public class SlidertoSetSpeedLimits : MonoBehaviour
{

    public GameObject J1MinVisual, J1MaxVisual;
    public float j1min = 0, j1max = 0;
    public TextMeshPro SliderValueMinSpeed, SliderValueMaxSpeed;

    public void J1MinSpeed(SliderEventData eventData)
    {

        j1min = eventData.NewValue * 250;
        J1MinVisual.GetComponent<Shaper2D>().arcDegrees = j1min;
        SliderValueMinSpeed.text = $"{j1min:F2}" + "°/s";

        if (j1min == 0)

            SliderValueMinSpeed.text = $"No Min";

    }

    public void J1MaxSpeed(SliderEventData eventData)
    {

        j1max = eventData.NewValue * 250;
        J1MaxVisual.GetComponent<Shaper2D>().arcDegrees = j1max;
        SliderValueMaxSpeed.text = $"{j1max:F2}" + "°/s";

        if (j1max == 0) { 

            SliderValueMaxSpeed.text = $"No Max";
        }

        if (j1min>j1max)
        {
            SliderValueMaxSpeed.text = $"Fix Min!";
        }

    }

}
