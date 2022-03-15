using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePathMarker : MonoBehaviour
{

    public GameObject PathMarkerSphere;
    public GameObject ToolEndPoint;
    private Vector3 LocationofTool;

    public void InstantiateonTool()
    {
        float x = ToolEndPoint.transform.position.x;
        float y = ToolEndPoint.transform.position.y;
        float z = ToolEndPoint.transform.position.z;

        LocationofTool = new Vector3(x, y, z);

        Instantiate(PathMarkerSphere, LocationofTool, Quaternion.identity);

    }
}


