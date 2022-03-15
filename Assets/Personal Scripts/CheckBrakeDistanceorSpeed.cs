using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBrakeDistanceorSpeed : MonoBehaviour
{
    public GameObject j1speed, j1brake, j2speed, j2brake, j3speed, j3brake, j4speed, j4brake, j5speed, j5brake, j6speed, j6brake;
    public bool activeSelf, j1activespeed, j2activespeed, j3activespeed, j4activespeed, j5activespeed, j6activespeed;

    public void CheckButtonStatusJ1()
    {
        if(j1speed.activeSelf == false)
        {
            j1speed.SetActive(true);
            j1brake.SetActive(false);
        }

        else if (j1speed.activeSelf == true)
        {
            j1speed.SetActive(false);
            j1brake.SetActive(true);
        }
    }

    public void CheckButtonStatusJ2()
    {
        if (j2speed.activeSelf == false)
        {
            j2speed.SetActive(true);
            j2brake.SetActive(false);
        }

        else if (j2speed.activeSelf == true)
        {
            j2speed.SetActive(false);
            j2brake.SetActive(true);
        }
    }

    public void CheckButtonStatusJ3()
    {
        if (j3speed.activeSelf == false)
        {
            j3speed.SetActive(true);
            j3brake.SetActive(false);
        }

        else if (j3speed.activeSelf == true)
        {
            j3speed.SetActive(false);
            j3brake.SetActive(true);
        }
    }

    public void CheckButtonStatusJ4()
    {
        if (j4speed.activeSelf == false)
        {
            j4speed.SetActive(true);
            j4brake.SetActive(false);
        }

        else if (j4speed.activeSelf == true)
        {
            j4speed.SetActive(false);
            j4brake.SetActive(true);
        }
    }

    public void CheckButtonStatusJ5()
    {
        if (j5speed.activeSelf == false)
        {
            j5speed.SetActive(true);
            j5brake.SetActive(false);
        }

        else if (j5speed.activeSelf == true)
        {
            j5speed.SetActive(false);
            j5brake.SetActive(true);
        }
    }

    public void CheckButtonStatusJ6()
    {
        if (j6speed.activeSelf == false)
        {
            j6speed.SetActive(true);
            j6brake.SetActive(false);
        }

        else if (j6speed.activeSelf == true)
        {
            j6speed.SetActive(false);
            j6brake.SetActive(true);
        }
    }
}
