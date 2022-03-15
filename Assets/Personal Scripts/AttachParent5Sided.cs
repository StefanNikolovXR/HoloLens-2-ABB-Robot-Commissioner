using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParent5Sided : MonoBehaviour
{

    public GameObject ZoneCenter, Coordinate1, Coordinate2, Coordinate3, Coordinate4, Coordinate5, CoordinateCenter;

    public void AttachtoSquare()
    {
        Coordinate1.transform.parent = CoordinateCenter.transform;
        Coordinate2.transform.parent = CoordinateCenter.transform;
        Coordinate3.transform.parent = CoordinateCenter.transform;
        Coordinate4.transform.parent = CoordinateCenter.transform;
        Coordinate5.transform.parent = CoordinateCenter.transform;
    }


    public void ResetParent()
    {
        Coordinate1.transform.parent = ZoneCenter.transform;
        Coordinate2.transform.parent = ZoneCenter.transform;
        Coordinate3.transform.parent = ZoneCenter.transform;
        Coordinate4.transform.parent = ZoneCenter.transform;
        Coordinate5.transform.parent = ZoneCenter.transform;
    }

}
