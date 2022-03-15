using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdjustRotation : MonoBehaviour
{
    public GameObject GroundCenter;
    public float xcurrentincreasing, xcurrentdecreasing;
    public float ycurrent, zcurrent;
    public Vector3 CurrentRingPositionIncreasing;
    public Vector3 CurrentRingPositionDecreasing;

    public void AdjustRobotModelRotationLeft()
    {
        xcurrentincreasing = GroundCenter.transform.localEulerAngles.x + 1;

        ycurrent = GroundCenter.transform.localEulerAngles.y;

        zcurrent = GroundCenter.transform.localEulerAngles.z;

        CurrentRingPositionIncreasing = new Vector3(xcurrentincreasing, ycurrent, zcurrent);

        GroundCenter.transform.localEulerAngles = CurrentRingPositionIncreasing;
    }

    public void AdjustRobotModelRotationRight()
    {

        xcurrentdecreasing = GroundCenter.transform.localEulerAngles.x - 1;

        ycurrent = GroundCenter.transform.localEulerAngles.y;

        zcurrent = GroundCenter.transform.localEulerAngles.z;

        CurrentRingPositionDecreasing = new Vector3(xcurrentdecreasing, ycurrent, zcurrent);

        GroundCenter.transform.localEulerAngles = CurrentRingPositionDecreasing;

    }


}
