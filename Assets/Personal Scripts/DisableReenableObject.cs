using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableReenableObject : MonoBehaviour
{
    public GameObject targetedobject;
    public bool activeSelf;

    public void EnableDisableObject() {

        if (targetedobject.activeSelf == true)
        {
            targetedobject.SetActive(false);
        }
        else targetedobject.SetActive(true);
    }

}
