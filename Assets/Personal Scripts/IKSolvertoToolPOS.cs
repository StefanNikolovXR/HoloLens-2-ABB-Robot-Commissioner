using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSolvertoToolPOS : MonoBehaviour
{

    public GameObject IKSolver;
    public GameObject Tool;
    private Vector3 LocationofTool;
    public GameObject irb120;
    public float roty;

    public void MatchCoordinates()
    {
        float x1 = Tool.transform.position.x;
        float y1 = Tool.transform.position.y;
        float z1 = Tool.transform.position.z;

        float roty = irb120.transform.localEulerAngles.y;

        LocationofTool = new Vector3(x1, y1, z1);

        IKSolver.transform.position = LocationofTool;
        IKSolver.transform.localEulerAngles = new Vector3(0,roty,0);
    }

    public void MatchAnchor()
    {
        float x1 = Tool.transform.position.x;
        float y1 = Tool.transform.position.y;
        float z1 = Tool.transform.position.z;

        LocationofTool = new Vector3(x1, y1, z1);

        IKSolver.transform.position = LocationofTool;
    }
}
