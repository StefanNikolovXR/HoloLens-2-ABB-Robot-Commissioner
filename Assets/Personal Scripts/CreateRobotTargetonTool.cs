using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRobotTargetonTool : MonoBehaviour
{

    public GameObject PathMarkerSphere;
    public GameObject ToolEndPoint;
    private Vector3 LocationofTool;
    public GameObject container;
    private string currtargetname = "", prevtargetname = "";
    private int targetnum = 0, prevtargetnum=0;
    public GameObject currtarget, prevtarget;
    public Transform currtargettransform, prevtargettransform;
    private bool blocked = false, onsurface = false, ignoresurfacelinks = false;

    public MeasureLine measurelineobj;

    public void InstantiateonTool()
    {
        float x = ToolEndPoint.transform.position.x;
        float y = ToolEndPoint.transform.position.y;
        float z = ToolEndPoint.transform.position.z;

        LocationofTool = new Vector3(x, y, z);

        var newTarget = Instantiate(PathMarkerSphere, LocationofTool, Quaternion.identity);
        newTarget.SetActive(true);
        newTarget.transform.parent = container.transform;
        prevtargetnum = targetnum;
        prevtargetname = "target" + prevtargetnum;
        prevtarget = GameObject.Find(prevtargetname); 

        targetnum++;
        currtargetname = "target" + targetnum;
        newTarget.name = (currtargetname);
        currtarget = GameObject.Find(currtargetname);
        currtargettransform = currtarget.transform;
        prevtargettransform = prevtarget.transform;

        measurelineobj = currtarget.GetComponent<MeasureLine>();

        MeasureLine.AddTarget(measurelineobj, prevtargettransform);
    }

}
