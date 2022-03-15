using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;


public class FineTuneJoints : MonoBehaviour
{
    [SerializeField]
    private Transform transformRobotJoints = null;

    public void OnSliderUpdatedJointRotationZ(SliderEventData eventData)
    {

        {
            transform.localEulerAngles = new Vector3(0, 0, 0 + eventData.NewValue * 360);
        }

    }

    public void OnSliderUpdatedIfJointRotationY(SliderEventData eventData)
        {

            {
                transform.localEulerAngles = new Vector3(0, 0 + eventData.NewValue * 360, 0);
            }
        }

    public void OnSliderUpdatedIfJointRotationX(SliderEventData eventData)
    {

        {
            transform.localEulerAngles = new Vector3(0 + eventData.NewValue * 360, 90, 90);
        }
    }

}

