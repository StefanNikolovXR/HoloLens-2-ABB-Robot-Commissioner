using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FetchVerticalArmTracing : MonoBehaviour
{
    public MeasureLine measurelinescript;
    public TextMeshPro verticaldistancecontainer;
    private string verticaldistanceconverted;

    void Update()
    {
        verticaldistanceconverted = measurelinescript.uiText_U.text.Replace("m", "");
        verticaldistancecontainer.text = measurelinescript.uiText_U.text;

    }
}
