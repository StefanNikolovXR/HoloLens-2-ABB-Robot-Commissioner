using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class RPMJointCalculations : MonoBehaviour
{
    public GameObject AccurateEulerContainer;
    public GameObject j1, j2, j3, j4, j5, j6;
    public float j1vel, j2vel, j3vel, j4vel, j5vel, j6vel;
    public float j1old, j1new, j1dif, j2old, j2new, j2dif, j3old, j3new, j3dif, j4old, j4new, j4dif, j5old, j5new, j5dif, j6old, j6new, j6dif;
    public bool j1neg, j2neg, j3neg, j4neg, j5neg, j6neg;

    public void Awake()
    {
        j1old = AccurateEulerContainer.GetComponent<AccurateEuler>().J1pos % 360;
        j2old = AccurateEulerContainer.GetComponent<AccurateEuler>().J2pos % 360;
        j3old = AccurateEulerContainer.GetComponent<AccurateEuler>().J3pos % 360;
        j4old = AccurateEulerContainer.GetComponent<AccurateEuler>().J4pos % 360;
        j5old = AccurateEulerContainer.GetComponent<AccurateEuler>().J5pos % 360;
        j6old = AccurateEulerContainer.GetComponent<AccurateEuler>().J6pos % 360;
    }

    public void Update()
    {

        j1new = AccurateEulerContainer.GetComponent<AccurateEuler>().J1pos % 360;
        j2new = AccurateEulerContainer.GetComponent<AccurateEuler>().J2pos % 360;
        j3new = AccurateEulerContainer.GetComponent<AccurateEuler>().J3pos % 360;
        j4new = AccurateEulerContainer.GetComponent<AccurateEuler>().J4pos % 360;
        j5new = AccurateEulerContainer.GetComponent<AccurateEuler>().J5pos % 360;
        j6new = AccurateEulerContainer.GetComponent<AccurateEuler>().J6pos % 360;

       StartCoroutine(Wait5Frames());

        j1dif = (j1new - j1old);
        j1vel = Mathf.Abs(j1dif / Time.deltaTime);

        j2dif = (j2new - j2old);
        j2vel = Mathf.Abs(j2dif / Time.deltaTime);

        j3dif = (j3new - j3old);
        j3vel = Mathf.Abs(j3dif / Time.deltaTime);

        if (j1dif < 0)
        {
            j1neg = false;
        }

        else { 
            j1neg = true;
        }

        if (j2dif < 0)
        {
            j2neg = false;
        }

        else
        {
            j2neg = true;
        }

        if (j3dif < 0)
        {
            j3neg = false;
        }

        else
        {
            j3neg = true;
        }

    }

    IEnumerator Wait5Frames()
    {

        yield return new WaitForSeconds(1);

        j1old = AccurateEulerContainer.GetComponent<AccurateEuler>().J1pos % 360;
        j2old = AccurateEulerContainer.GetComponent<AccurateEuler>().J2pos % 360;
        j3old = AccurateEulerContainer.GetComponent<AccurateEuler>().J3pos % 360;
        j4old = AccurateEulerContainer.GetComponent<AccurateEuler>().J4pos % 360;
        j5old = AccurateEulerContainer.GetComponent<AccurateEuler>().J5pos % 360;
        j6old = AccurateEulerContainer.GetComponent<AccurateEuler>().J6pos % 360;

    }
}
