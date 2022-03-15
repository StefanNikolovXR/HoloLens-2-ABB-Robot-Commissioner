using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderJointLimits : MonoBehaviour
{
    public MeshRenderer j1posarc, j1negarc, j1posarcinv, j1negarcinv;
    public MeshRenderer j2posarc, j2negarc, j2posarcinv, j2negarcinv;
    public MeshRenderer j3posarc, j3negarc, j3posarcinv, j3negarcinv;
    public MeshRenderer j4posarc, j4negarc, j4posarcinv, j4negarcinv;
    public MeshRenderer j5posarc, j5negarc, j5posarcinv, j5negarcinv;
    public MeshRenderer j6posarc, j6negarc, j6posarcinv, j6negarcinv;

    public MeshRenderer j1posdef, j1negdef;
    public MeshRenderer j2posdef, j2negdef;
    public MeshRenderer j3posdef, j3negdef;
    public MeshRenderer j4posdef, j4negdef;
    public MeshRenderer j5posdef, j5negdef;
    public MeshRenderer j6posdef, j6negdef;

    public GameObject DisableJointLimitsButton;
    public bool inputmodeon = false;
    public bool activeSelf;

    public void EnableJointLimits()
    {
        j1posarc.enabled = true;
        j1negarc.enabled = true;
        j2posarc.enabled = true;
        j2negarc.enabled = true;
        j3posarc.enabled = true;
        j3negarc.enabled = true;
        j4posarc.enabled = true;
        j4negarc.enabled = true;
        j5posarc.enabled = true;
        j5negarc.enabled = true;
        j6posarc.enabled = true;
        j6negarc.enabled = true;
        j1posdef.enabled = true;
        j1negdef.enabled = true;
        j2posdef.enabled = true;
        j2negdef.enabled = true;
        j3posdef.enabled = true;
        j3negdef.enabled = true;
        j4posdef.enabled = true;
        j4negdef.enabled = true;
        j5posdef.enabled = true;
        j5negdef.enabled = true;
        j6posdef.enabled = true;
        j6negdef.enabled = true;
    }

    public void DisableJointLimits()
    {
        DisableJointLimitsButton.SetActive(false);

        j1posarc.enabled = false;
        j1negarc.enabled = false;
        j2posarc.enabled = false;
        j2negarc.enabled = false;
        j3posarc.enabled = false;
        j3negarc.enabled = false;
        j4posarc.enabled = false;
        j4negarc.enabled = false;
        j5posarc.enabled = false;
        j5negarc.enabled = false;
        j6posarc.enabled = false;
        j6negarc.enabled = false;
        j1posdef.enabled = false;
        j1negdef.enabled = false;
        j2posdef.enabled = false;
        j2negdef.enabled = false;
        j3posdef.enabled = false;
        j3negdef.enabled = false;
        j4posdef.enabled = false;
        j4negdef.enabled = false;
        j5posdef.enabled = false;
        j5negdef.enabled = false;
        j6posdef.enabled = false;
        j6negdef.enabled = false;
    }

    public void J1Edited() {

        DisableJointLimits();

        j1posdef.enabled = true;
        j1negdef.enabled = true;
        
    }
}
