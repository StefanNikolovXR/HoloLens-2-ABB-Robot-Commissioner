using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimize : MonoBehaviour
{
    public GameObject motioncontrols;
    public Sprite minimized, expanded;
    public SpriteRenderer currsprite;
    public AudioClip togglesoundoff, togglesoundon;
    public bool activeSelf;

    public void ToggleMinimize()
    {
        if (motioncontrols.activeSelf)
        {
            motioncontrols.SetActive(false);
            currsprite.sprite = expanded;
            GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
        }

        else { 
        motioncontrols.SetActive(true);
        currsprite.sprite = minimized;
        GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        }
    }
}
