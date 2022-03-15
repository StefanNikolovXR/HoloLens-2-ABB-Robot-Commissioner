using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MinorXYZAdjustments : MonoBehaviour
{
    public Vector3 CurrentPositionVector;
    public GameObject RobotModel;

    public void IncreaseXSlightly() {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x + 0.01f, RobotModel.transform.position.y, RobotModel.transform.position.z);

        RobotModel.transform.position = CurrentPositionVector;

            }

    public void IncreaseYSlightly()
    {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x, RobotModel.transform.position.y + 0.01f, RobotModel.transform.position.z);

        RobotModel.transform.position = CurrentPositionVector;

    }

    public void IncreaseZSlightly()
    {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x, RobotModel.transform.position.y, RobotModel.transform.position.z + 0.01f);

        RobotModel.transform.position = CurrentPositionVector;

    }

    public void DecreaseXSlightly()
    {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x - 0.01f, RobotModel.transform.position.y, RobotModel.transform.position.z);

        RobotModel.transform.position = CurrentPositionVector;

    }

    public void DecreaseYSlightly()
    {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x, RobotModel.transform.position.y - 0.01f, RobotModel.transform.position.z);

        RobotModel.transform.position = CurrentPositionVector;

    }

    public void DecreaseZSlightly()
    {

        CurrentPositionVector = new Vector3(RobotModel.transform.position.x, RobotModel.transform.position.y, RobotModel.transform.position.z - 0.01f);

        RobotModel.transform.position = CurrentPositionVector;

    }

}
