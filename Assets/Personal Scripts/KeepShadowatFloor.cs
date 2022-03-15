using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepShadowatFloor : MonoBehaviour
{
    public bool moving;

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
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }
}
