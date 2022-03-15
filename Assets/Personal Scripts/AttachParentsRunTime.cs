using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParentsRunTime : MonoBehaviour
{
    public GameObject ZoneCenter;
    public GameObject CoordinateTop;
    public GameObject CoordinateBottom;
    public GameObject CoordinateShadow;

    public void AttachtoTopCoordinate() {

        CoordinateBottom.transform.parent = CoordinateTop.transform;
        CoordinateShadow.transform.parent = CoordinateTop.transform;
    }

    public void AttachtoBottomCoordinate()
    {

        CoordinateTop.transform.parent = CoordinateBottom.transform;
        CoordinateShadow.transform.parent = CoordinateBottom.transform;
    }

    public void ResetParent ()
    {
        CoordinateShadow.transform.parent = ZoneCenter.transform;
        CoordinateTop.transform.parent = ZoneCenter.transform;
        CoordinateBottom.transform.parent = ZoneCenter.transform;
    }

}
