using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepShadowPolygonatFloor : MonoBehaviour
{
    public bool moving;
    public GameObject parent;
    public GameObject Polygons;

    public void ZoneMoving()
    {
        moving = true;
    }

    public void ZoneStopped()
    {
        moving = false;
    }

    void Update()
    {
        if (moving)
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
