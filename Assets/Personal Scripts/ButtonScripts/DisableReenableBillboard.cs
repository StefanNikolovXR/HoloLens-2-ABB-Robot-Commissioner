using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.UI;

public class DisableReenableBillboard : MonoBehaviour
{
    public Billboard billboard;
    public Sprite eyeopen, eyeclosed;
    public SpriteRenderer currsprite;
    public AudioClip togglesoundoff, togglesoundon;

    public void ToggleBillboard()
    {
        if (billboard.enabled)
        {
            currsprite.sprite = eyeclosed;
            billboard.enabled = false;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }

        else { 
        currsprite.sprite = eyeopen;
        billboard.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
