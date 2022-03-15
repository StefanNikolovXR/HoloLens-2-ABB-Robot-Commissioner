using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition.Method;
using Lean.Transition;

public class ToggleZoneExpand : MonoBehaviour
{
 
    public GameObject centerofzone;
    public Vector3 coordinatelocation, centerlocation;
    public bool zoneshrink = false;
    private float xpoint, ypoint, zpoint;
    private float xcenter, ycenter, zcenter;

    void Start()
    {
        xpoint = transform.position.x;
        ypoint = transform.position.y;
        zpoint = transform.position.z;

        coordinatelocation = new Vector3(xpoint, ypoint, zpoint);

        centerlocation = new Vector3(0, 0, 0);
    }

    public void SaveCoordinateLocation()
    {
        xpoint = transform.position.x;
        ypoint = transform.position.y;
        zpoint = transform.position.z;

        coordinatelocation = new Vector3(xpoint, ypoint, zpoint);

        xcenter = centerofzone.transform.position.x;
        ycenter = centerofzone.transform.position.y;
        zcenter = centerofzone.transform.position.z;

        centerlocation = new Vector3(xcenter, ycenter, zcenter);

    }

    public void CoordinatetoCenter()
    {
        SaveCoordinateLocation();
        transform.positionTransition(centerlocation, 1f);
    }

    public void CoordinatefromCenter()
    {
        transform.positionTransition(coordinatelocation, 1f);
    }
}


