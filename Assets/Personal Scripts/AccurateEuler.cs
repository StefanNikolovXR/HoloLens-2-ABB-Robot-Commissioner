using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class AccurateEuler : MonoBehaviour
{
    public GameObject J1, J2, J3, J4, J5, J6;
    public float J1pos, J2pos, J3pos, J4pos, J5pos, J6pos;
    public string J1_str, J2_str, J3_str, J4_str, J5_str, J6_str;
    public TextMeshPro axisvalue;
    public string manualjog = "";
    public bool j1mod = false, j2mod = false, j3mod = false, j4mod = false, j5mod = false, j6mod = false;

    public void Update ()
    {
        J1pos = J1.transform.localEulerAngles.z;
        J2pos = J2.transform.localEulerAngles.y;
        J3pos = J3.transform.localEulerAngles.y;
        J4pos = J4.transform.localEulerAngles.x;
        J5pos = J5.transform.localEulerAngles.y;
        J6pos = J6.transform.localEulerAngles.x - 720;

        J1_str = J1pos.ToString("f2");
        J2_str = J2pos.ToString("f2");
        J3_str = J3pos.ToString("f2");
        J4_str = J4pos.ToString("f2");
        J5_str = J5pos.ToString("f2");
        J6_str = J6pos.ToString("f2");

        manualjog = "[" + J1_str + "," + J2_str + "," + J3_str + "," + J4_str + "," + J5_str + "," + J6_str + "]";
    }

    public void FixedUpdate ()
    {
        if (j1mod)
        {
            axisvalue.text = $"{J1pos:F2}" + "°";
        }

        if (j2mod)
        {
            axisvalue.text = $"{J2pos:F2}" + "°";
        }

        if (j3mod)
        {
            axisvalue.text = $"{J3pos:F2}" + "°";
        }

        if (j4mod)
        {
            axisvalue.text = $"{J4pos:F2}" + "°";
        }

        if (j5mod)
        {
            axisvalue.text = $"{J5pos:F2}" + "°";
        }

        if (j6mod)
        {
            axisvalue.text = $"{J6pos:F2}" + "°";
        }
    }

    public void j1moving()
    {
        j1mod = true;
    }

    public void j1stopped()
    {
        j1mod = false;
    }

    public void j2moving()
    {
        j2mod = true;
    }

    public void j2stopped()
    {
        j2mod = false;
    }

    public void j3moving()
    {
        j3mod = true;
    }

    public void j3stopped()
    {
        j3mod = false;
    }

    public void j4moving()
    {
        j4mod = true;
    }

    public void j4stopped()
    {
        j4mod = false;
    }

    public void j5moving()
    {
        j5mod = true;
    }

    public void j5stopped()
    {
        j5mod = false;
    }

    public void j6moving()
    {
        j6mod = true;
    }

    public void j6stopped()
    {
        j1mod = false;
    }

}
