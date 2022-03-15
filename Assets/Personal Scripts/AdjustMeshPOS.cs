using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMeshPOS : MonoBehaviour
{
    public GameObject SafeZone;
    public bool moving;

    void Update()
    {
        if (moving)
        {
            transform.localPosition = SafeZone.transform.position;
        }
    }
}
