using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchFloorCoordinates : MonoBehaviour
{

    public GameObject FakeRobotHologram;
    public GameObject RealRobotHologram;
    private Vector3 LocationofFakeRobot;

    // Start is called before the first frame update
    
    // Update is called once per frame
    public void MatchCoordinates()
    {
        float x1 = FakeRobotHologram.transform.position.x;
        float y1 = FakeRobotHologram.transform.position.y;
        float z1 = FakeRobotHologram.transform.position.z;

        LocationofFakeRobot = new Vector3 (x1, y1, z1);

        RealRobotHologram.transform.position = LocationofFakeRobot;

    }
}
