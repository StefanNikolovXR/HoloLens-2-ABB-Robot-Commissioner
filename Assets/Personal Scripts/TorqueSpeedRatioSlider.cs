using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;

public class TorqueSpeedRatioSlider : MonoBehaviour
{
    public int sliderstatus;
    public float j1_torque, j2_torque, j3_torque, j4_torque, j5_torque, j6_torque, speed;
    public TextMeshPro j1_txt, j2_txt, j3_txt, j4_txt, j5_txt, j6_txt, speed_txt, currvalue;
    public InputfromUnitytoRS input;
    public PinchSlider slider;

    void Start()
    {
        j1_torque = 500;
        j2_torque = 500;
        j3_torque = 500;
        j4_torque = 500;
        j5_torque = 500;
        j6_torque = 500;
        speed = 100;
    }

    public void SetupSlider()
    {
        switch (sliderstatus)
        {
            case 1:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j1_torque);
                j1_txt.text = $"{j1_torque:F0}";
                break;

            case 2:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j2_torque);
                j2_txt.text = $"{j2_torque:F0}";
                break;

            case 3:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j3_torque);
                j3_txt.text = $"{j3_torque:F0}";
                break;

            case 4:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j4_torque);
                j4_txt.text = $"{j4_torque:F0}";
                break;

            case 5:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j5_torque);
                j5_txt.text = $"{j5_torque:F0}";
                break;

            case 6:
                slider.SliderValue = Mathf.InverseLerp(500, 9000, j6_torque);
                j6_txt.text = $"{j6_torque:F0}";
                break;

            case 7:
                slider.SliderValue = Mathf.InverseLerp(0, 100, speed);
                speed_txt.text = $"{speed:F0}" + "%";
                break;

            default:
                break;
        }
    }

    public void SliderMotion(SliderEventData eventData)
    {
        switch (sliderstatus)
        {
            case 1:
                j1_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j1_torque:F0}";
                j1_txt.text = $"{j1_torque:F0}";
                break;

            case 2:
                j2_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j2_torque:F0}";
                j2_txt.text = $"{j2_torque:F0}";
                break;

            case 3:
                j3_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j3_torque:F0}";
                j3_txt.text = $"{j3_torque:F0}";
                break;

            case 4:
                j4_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j4_torque:F0}";
                j4_txt.text = $"{j4_torque:F0}";
                break;

            case 5:
                j5_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j5_torque:F0}";
                j5_txt.text = $"{j5_torque:F0}";
                break;

            case 6:
                j6_torque = (500 + eventData.NewValue * 8500);
                currvalue.text = $"{j6_torque:F0}";
                j6_txt.text = $"{j6_torque:F0}";
                break;

            case 7:
                speed = (0 + eventData.NewValue * 100);
                currvalue.text = $"{speed:F0}" + "%";
                speed_txt.text = $"{speed:F0}" + "%";
                break;

            default:
                break;

        }
    }

    public void EndSliderMotion(SliderEventData eventData)
    {
        switch (sliderstatus)
        {
            case 1:
                input.j1torquestr = $"{j1_torque:F0}";
                input.j1torquestr_neg = "-" + $"{j1_torque:F0}";
                break;

            case 2:
                input.j2torquestr = $"{j2_torque:F0}";
                input.j2torquestr_neg = "-" + $"{j2_torque:F0}";
                break;

            case 3:
                input.j3torquestr = $"{j3_torque:F0}";
                input.j3torquestr_neg = "-" + $"{j3_torque:F0}";
                break;

            case 4:
                input.j4torquestr = $"{j4_torque:F0}";
                input.j4torquestr_neg = "-" + $"{j4_torque:F0}";
                break;

            case 5:
                input.j5torquestr = $"{j5_torque:F0}";
                input.j5torquestr_neg = "-" + $"{j5_torque:F0}";
                break;

            case 6:
                input.j6torquestr = $"{j6_torque:F0}";
                input.j6torquestr_neg = "-" + $"{j6_torque:F0}";
                break;

            case 7:
                input.speed = $"{speed:F0}";
                break;

            default:
                break;
        }
    }

}
