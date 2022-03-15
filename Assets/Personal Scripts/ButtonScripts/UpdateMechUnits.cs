using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMechUnits : MonoBehaviour
{
   
    public GameObject J1, J2, J3, J4, J5, J6;
    public string manualjog;

    private float J1pos, J2pos, J3pos, J4pos, J5pos, J6pos;
    private string J1_str, J2_str, J3_str, J4_str, J5_str, J6_str;

    void FixedUpdate ()
    {
        
        J1pos = UnityEditor.TransformUtils.GetInspectorRotation(J1.transform).y * (-1);
        J2pos = UnityEditor.TransformUtils.GetInspectorRotation(J2.transform).z;
        J3pos = UnityEditor.TransformUtils.GetInspectorRotation(J3.transform).z;
        J4pos = UnityEditor.TransformUtils.GetInspectorRotation(J4.transform).x;
        J5pos = UnityEditor.TransformUtils.GetInspectorRotation(J5.transform).z;
        J6pos = UnityEditor.TransformUtils.GetInspectorRotation(J6.transform).x;
        //  
        J1_str = J1pos.ToString("F2");
        J2_str = J2pos.ToString("F2");
        J3_str = J3pos.ToString("F2");
        J4_str = J4pos.ToString("F2");
        J5_str = J5pos.ToString("F2");
        J6_str = J6pos.ToString("F2");

        manualjog = "[" + J1_str + "," + J2_str + "," + J3_str + "," + J4_str + "," + J5_str + "," + J6_str + "]";

    }
}
