using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpdateCoordinates : MonoBehaviour
{
    [SerializeField]
    private Transform transformRobotModel = null;

    public void ButtonMinusX()
    {
        
            transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x - 0.009f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);
        
    }

    public void ButtonDoubleMinusX()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x - 0.027f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);

    }

    public void ButtonTripleMinusX()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x - 0.081f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);

    }

    public void ButtonMinusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y - 0.009f, transformRobotModel.localPosition.z);

    }

    public void ButtonDoubleMinusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y - 0.027f, transformRobotModel.localPosition.z);

    }

    public void ButtonTripleMinusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y - 0.081f, transformRobotModel.localPosition.z);

    }

    public void ButtonMinusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z - 0.009f);

    }

    public void ButtonDoubleMinusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z - 0.027f);

    }

    public void ButtonTripleMinusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z - 0.081f);

    }

    public void ButtonPlusX()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x + 0.009f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);

    }

    public void ButtonDoublePlusX()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x + 0.027f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);

    }

    public void ButtonTriplePlusX()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x + 0.081f, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z);

    }

    public void ButtonPlusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y + 0.009f, transformRobotModel.localPosition.z);

    }

    public void ButtonDoublePlusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y + 0.027f, transformRobotModel.localPosition.z);

    }

    public void ButtonTriplePlusY()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y + 0.081f, transformRobotModel.localPosition.z);

    }

    public void ButtonPlusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z + 0.009f);

    }

    public void ButtonDoublePlusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z + 0.027f);

    }

    public void ButtonTriplePlusZ()
    {

        transformRobotModel.localPosition = new Vector3(transformRobotModel.localPosition.x, transformRobotModel.localPosition.y, transformRobotModel.localPosition.z + 0.081f);

    }
}
