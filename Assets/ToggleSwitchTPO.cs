using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitchTPO : MonoBehaviour
{
    public SafeZoneStoredData storeddata;
    public bool tpo_on;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleSwitch()
    {
        if (tpo_on)
        {
            tpo_on = false;
            storeddata.tpo_on = false;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }
        else
        {
            tpo_on = true;
            storeddata.tpo_on = true;
            GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
