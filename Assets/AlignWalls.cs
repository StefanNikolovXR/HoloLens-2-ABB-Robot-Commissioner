using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWalls : MonoBehaviour
{
    public GameObject parent;
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
        {
            transform.position = new Vector3(parent.transform.position.x * (-1), parent.transform.position.y * (-1), parent.transform.position.z * (-1));
        }
    }
}
