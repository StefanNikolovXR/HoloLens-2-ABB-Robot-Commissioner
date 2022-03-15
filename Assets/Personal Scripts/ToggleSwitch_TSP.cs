using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch_TSP : MonoBehaviour
{
    public SafeZoneStoredData storeddata;
    public bool tsp_on;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleSwitch()
    {
        if (tsp_on)
        {
            tsp_on = false;
            storeddata.tsp_on = false;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }
        else
        {
            tsp_on = true;
            storeddata.tsp_on = true;
            GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
