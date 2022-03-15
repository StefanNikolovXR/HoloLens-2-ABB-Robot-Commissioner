using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncSilhouette : MonoBehaviour
{
    public GameObject armstartpoint, armendpoint, basestartpoint, baseendpoint, bendstartpoint, bendendpoint, wriststartpoint, wristendpoint;
    public float armstartpointx, armstartpointz, armendpointx, armendpointz, bendstartpointx, bendstartpointz, wriststartpointx, wriststartpointz;
    public Vector3 armstartpointvector, armendpointvector, bendendpointvector, wristendpointvector;

    void Start()
    {

    }

    void Update()

    {
        armstartpointx = armstartpoint.transform.position.x;
        armstartpointz = armstartpoint.transform.position.z;

        armendpointx = armendpoint.transform.position.x;
        armendpointz = armendpoint.transform.position.z;

        bendstartpointx = bendstartpoint.transform.position.x;
        bendstartpointz = bendstartpoint.transform.position.z;

        wriststartpointx = wriststartpoint.transform.position.x;
        wriststartpointz = wriststartpoint.transform.position.z;

        armstartpointvector = new Vector3(armstartpointx, 0, armstartpointz);
        armendpointvector = new Vector3(armendpointx, 0, armendpointz);
        bendendpointvector = new Vector3(bendstartpointx, 0, bendstartpointz);
        wristendpointvector = new Vector3(wriststartpointx, 0, wriststartpointz);

        basestartpoint.transform.position = armstartpointvector;
        baseendpoint.transform.position = armendpointvector;
        bendendpoint.transform.position = bendendpointvector;
        wristendpoint.transform.position = wristendpointvector;

        /*arm2rot = Arm2.transform.localEulerAngles.y;

        silyrot = (180 - arm2rot) * -1;
        arm2silx = (arm2rot / 2) * -1;

        silxscale = 9 + arm2rot / 5;


        silMOVE = new Vector3();
        silROT = new Vector3(0, sillyrot, 180);
        silSCALE = new Vector3(silxscale, 22.86f, 23.2f);

        Arm2silvectormove = new Vector3(arm2silx, 0, 124.2f);

        Arm2Silhouette.transform.localPosition = Arm2silvectormove;

        Arm2silvectorscale = new Vector3(
        Arm2Silhouette.transform.localScale = Arm2silvectorscale;**/


    }
}
