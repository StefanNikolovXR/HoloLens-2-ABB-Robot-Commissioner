using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitchAPO : MonoBehaviour
{
    public SafeZoneStoredData storeddata;
    public bool apo_on;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleSwitch()
    {
        if (apo_on)
        {
            apo_on = false;
            storeddata.apo_on = false;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }
        else
        {
            apo_on = true;
            storeddata.apo_on = true;
            GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
