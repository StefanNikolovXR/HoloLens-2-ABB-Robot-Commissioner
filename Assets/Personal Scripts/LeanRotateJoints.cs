using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class LeanRotateJoints : MonoBehaviour
{
    public GameObject j1, j2, j3, j4, j5, j6;

    public void MoveJ1(float j1_y)
    {
        j1.transform.localRotationTransition(Quaternion.Euler(0, j1_y, 0), 2.0f);
    }

    public void MoveJ2(float j2_z)
    {
        j2.transform.localRotationTransition(Quaternion.Euler(0, 0, j2_z), 2.0f);
    }

    public void MoveJ3(float j3_z)
    {
        j3.transform.localRotationTransition(Quaternion.Euler(0, 0, j3_z), 2.0f);
    }

    public void MoveJ4(float j4_x)
    {
        j4.transform.localRotationTransition(Quaternion.Euler(j4_x, 0, 0), 2.0f);
    }

    public void MoveJ5(float j5_z)
    {
        j5.transform.localRotationTransition(Quaternion.Euler(0, 0, j5_z), 2.0f);
    }

    public void MoveJ6(float j6_x)
    {
        j6.transform.localRotationTransition(Quaternion.Euler(j6_x, 0, 0), 2.0f);
    }

}
