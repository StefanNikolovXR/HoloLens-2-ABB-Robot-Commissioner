using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System.Runtime.InteropServices;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;

public class CalculateRPM : MonoBehaviour
{
    public GameObject MaxSpeedVisual, MinSpeedVisual, SpeedVisual;
    public float velocity, oldpos, newpos, difference, progress, minspeed, maxspeed;
    public TextMeshPro jointRPM;
    public Color lerpedColor;

    public void Start()
    {

        oldpos = transform.rotation.z;
        minspeed = MinSpeedVisual.GetComponent<Shaper2D>().arcDegrees;
        maxspeed = MaxSpeedVisual.GetComponent<Shaper2D>().arcDegrees;
    }

    public void Update()
    {
        newpos = transform.rotation.z;
        difference = (newpos - oldpos);
        velocity = Mathf.Abs(difference / Time.deltaTime * 60);
        oldpos = newpos;
        newpos = transform.rotation.z;
        jointRPM.text = $"{velocity:F2}" + "°/s";

        SpeedVisual.GetComponent<Shaper2D>().arcDegrees = velocity;

        progress = Mathf.InverseLerp(minspeed, maxspeed, velocity);

        if (progress <= 0.5f)
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, 1f-progress);
        }

        else
        {
            lerpedColor = Color.Lerp(Color.green, Color.red, progress);
        }

        SpeedVisual.GetComponent<Shaper2D>().innerColor = lerpedColor;
        SpeedVisual.GetComponent<Shaper2D>().outerColor = lerpedColor;
    }


}
