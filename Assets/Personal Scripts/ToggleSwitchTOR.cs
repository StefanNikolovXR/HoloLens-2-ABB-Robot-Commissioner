using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitchTOR : MonoBehaviour
{
    public SafeZoneStoredData storeddata;
    public bool tor_on;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleSwitch()
    {
        if (tor_on)
        {
            tor_on = false;
            storeddata.tor_on = false;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }
        else
        {
            tor_on = true;
            storeddata.tor_on = true;
            GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
