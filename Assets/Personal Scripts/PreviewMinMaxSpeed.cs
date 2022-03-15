using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewMinMaxSpeed : MonoBehaviour
{
    public Quaternion startQuaternion;
    public GameObject J1, J1ScriptContainer;
    public float j1negangles, j1posangles, j1minspeed = 50f, j1maxspeed;
    public bool speedsim;
    public float minspeed, maxspeed;

    void Update() { 
    
        if (speedsim)
        {
            minspeed = J1ScriptContainer.GetComponent<SlidertoSetSpeedLimits>().j1min;
            J1.transform.Rotate(Vector3.forward * minspeed * Time.deltaTime);
        }

    }

  /*  public void J1SpeedRotation(SliderEventData eventData)
    {

       j1negangles = J1ScriptContainer.GetComponent<SlidertoAxisSafeRange>().j1neg;
       j1posangles = J1ScriptContainer.GetComponent<SlidertoAxisSafeRange>().j1pos;

        if (J1.transform.rotation.z > j1negangles && J1.transform.rotation.z < 0) { 

        J1.transform.rotation.z = (J1.transform.rotation.z + J1minspeed * Time.deltaTime);

        }*/

    }

