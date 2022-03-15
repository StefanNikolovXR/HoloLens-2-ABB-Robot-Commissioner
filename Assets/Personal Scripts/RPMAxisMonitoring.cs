using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using System.Runtime.InteropServices;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using TMPro;

public class RPMAxisMonitoring : MonoBehaviour
{
  //  public GameObject BrakeDistance_Container;
    public Rigidbody j1, j2, j3, j4, j5, j6;
    public GameObject j1brakerectangle, j2brakerectangle, j3brakerectangle;
    public GameObject j1circle, j2circle, j3circle, j4circle, j5circle, j6circle;
    public float j1vel, j2vel, j3vel, j4vel, j5vel, j6vel;
    public float j1old, j1new, j1dif, j2old, j2new, j2dif, j3old, j3new, j3dif, j4old, j4new, j4dif, j5old, j5new, j5dif, j6old, j6new, j6dif;
    public float j1prog, j2prog, j3prog, j4prog, j5prog, j6prog;
  //  public float j1brakedist, j2brakedist, j3brakedist;
    public TextMeshPro j1rpm, j2rpm, j3rpm, j4rpm, j5rpm, j6rpm;
    public TextMeshPro j1braking, j2braking, j3braking;
    public Color j1lerp, j2lerp, j3lerp, j4lerp, j5lerp, j6lerp;
    public bool activeSelf, brakingactive = true;
    public float j1max = 250, j2max = 250, j3max = 250, j4max = 320, j5max = 320, j6max = 420;
    public float j1min = 0, j2min = 0, j3min = 0, j4min = 0, j5min = 0, j6min = 0;

    public FinalAxisValues final;

    public void Awake()
    {
        j1old = j1.transform.localEulerAngles.y / 360 % j1max;
        j2old = j2.transform.localEulerAngles.z / 360 % j2max;
        j3old = j3.transform.localEulerAngles.z / 360 % j3max;
        j4old = j4.transform.localEulerAngles.x / 360 % j4max;
        j5old = j5.transform.localEulerAngles.z / 360 % j5max;
        j6old = j6.transform.localEulerAngles.x / 360 % j6max;
    }

    public void ParseMinMaxSpeeds()
    {
        j1min = final.asp_j1min;
        j2min = final.asp_j2min;
        j3min = final.asp_j3min;
        j4min = final.asp_j4min;
        j5min = final.asp_j5min;
        j6min = final.asp_j6min;

        j1max = final.asp_j1max;
        j2max = final.asp_j2max;
        j3max = final.asp_j3max;
        j4max = final.asp_j4max;
        j5max = final.asp_j5max;
        j6max = final.asp_j6max;
    }

    public void Update()
    {
        //j1prog = Mathf.InverseLerp(j1min, j1max, j1vel);
        //j1lerp = Color.Lerp(Color.red, Color.green, 1.5f - j1prog);
        //j1circle.GetComponent<Shaper2D>().innerColor = j1lerp;
        //j1circle.GetComponent<Shaper2D>().outerColor = j1lerp;

        j1vel = Mathf.Abs(j1.angularVelocity.y) * 57.2958f;
        j2vel = Mathf.Abs(j2.angularVelocity.z) * 57.2958f;
        j3vel = Mathf.Abs(j3.angularVelocity.z) * 57.2958f;
        j4vel = Mathf.Abs(j4.angularVelocity.x) * 57.2958f;
        j5vel = Mathf.Abs(j5.angularVelocity.z) * 57.2958f;
        j6vel = Mathf.Abs(j6.angularVelocity.z) * 57.2958f;

        j1circle.GetComponent<Shaper2D>().arcDegrees = j1vel;
        j2circle.GetComponent<Shaper2D>().arcDegrees = j2vel;
        j3circle.GetComponent<Shaper2D>().arcDegrees = j3vel;
        j4circle.GetComponent<Shaper2D>().arcDegrees = j4vel;
        j5circle.GetComponent<Shaper2D>().arcDegrees = j5vel;
        j6circle.GetComponent<Shaper2D>().arcDegrees = j6vel;

        j1rpm.text = $"{j1vel:F2}" + "°/s";
        j2rpm.text = $"{j2vel:F2}" + "°/s";
        j3rpm.text = $"{j3vel:F2}" + "°/s";
        j4rpm.text = $"{j4vel:F2}" + "°/s";
        j5rpm.text = $"{j5vel:F2}" + "°/s";
        j6rpm.text = $"{j6vel:F2}" + "°/s";

        j1braking.text = $"{j1vel / 25:F2}" + "°";
        j2braking.text = $"{j2vel / 25:F2}" + "°";
        j3braking.text = $"{j3vel / 25:F2}" + "°";

        j1brakerectangle.transform.localScale = new Vector3(j1vel / 500, j1brakerectangle.transform.localScale.y, j1brakerectangle.transform.localScale.z);
        j2brakerectangle.transform.localScale = new Vector3(j2vel / 500, j1brakerectangle.transform.localScale.y, j1brakerectangle.transform.localScale.z);
        j3brakerectangle.transform.localScale = new Vector3(j3vel / 500, j1brakerectangle.transform.localScale.y, j1brakerectangle.transform.localScale.z);

    }

}
