using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitchASP : MonoBehaviour
{
    public SafeZoneStoredData storeddata;
    public bool asp_on;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleSwitch()
    {
        if (asp_on) { 
            asp_on = false;
        storeddata.asp_on = false;
        GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }
        else
        {
            asp_on = true;
            storeddata.asp_on = true;
            GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
