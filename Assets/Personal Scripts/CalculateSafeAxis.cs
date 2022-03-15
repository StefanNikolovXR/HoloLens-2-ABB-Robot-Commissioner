using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System.Runtime.InteropServices;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;

public class CalculateSafeAxis : MonoBehaviour
{
    public GameObject SafeRangePositive, SafeRangeNegative, Joint;
    public float rot, progress, negrange, posrange;
    public TextMeshPro currentrot;
    public Color lerpedColor, defaultgreen;
    public bool simulation;

    public void Start()
    {
        negrange = SafeRangeNegative.GetComponent<Shaper2D>().arcDegrees * (-1);
        posrange = SafeRangePositive.GetComponent<Shaper2D>().arcDegrees;
        defaultgreen = new Color(0f, 255f, 0f, 255F);
        lerpedColor = defaultgreen;
    }

    public void Update()
    {

        if (simulation) { 

        rot = Joint.transform.localEulerAngles.z;
        rot = (rot > 180) ? rot - 360 : rot;

        currentrot.text = $"{rot:F2}" + "°";

        progress = Mathf.InverseLerp(negrange, posrange, rot);

        if (progress <= 0.25f)
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, 1f - progress);
        }

        else if (progress >= 0.75f)
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, progress);
        }

        else lerpedColor = defaultgreen;

        SafeRangePositive.GetComponent<Shaper2D>().innerColor = lerpedColor;
        SafeRangePositive.GetComponent<Shaper2D>().outerColor = lerpedColor;

        SafeRangeNegative.GetComponent<Shaper2D>().innerColor = lerpedColor;
        SafeRangeNegative.GetComponent<Shaper2D>().outerColor = lerpedColor;
        }
    }


}

