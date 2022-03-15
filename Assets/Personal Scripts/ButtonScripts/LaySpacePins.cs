using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.WorldLocking.Core;

public class LaySpacePins : MonoBehaviour
{
   public GameObject parent;

    public void ActivateSpacePins()
    {
        foreach (Transform child in parent.transform)
        {
            child.GetComponent<SpacePin>().enabled = true;
        }
    }
}
