using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class LockBoneWeight : MonoBehaviour
{
    public IKSolverCCD solver;
    public GameObject robot;
    public bool axislocking = false;
    public SpriteRenderer Base1Locked, Base1Unlocked, Arm2Locked, Arm2Unlocked, Arm3Locked, Arm3Unlocked, Wrist4Locked, Wrist4Unlocked, Bend5Locked, Bend5Unlocked;
    
    void Start()
    {
        solver = robot.GetComponent<CCDIK>().solver;
    }

    public void HideAllAxes()
    {
        Base1Locked.enabled = false;
        Base1Unlocked.enabled = false;

        Arm2Locked.enabled = false;
        Arm2Unlocked.enabled = false;

        Arm3Locked.enabled = false;
        Arm3Unlocked.enabled = false;

        Wrist4Locked.enabled = false;
        Wrist4Unlocked.enabled = false;

        Bend5Locked.enabled = false;
        Bend5Unlocked.enabled = false;
    }

    public void UnlockAllAxes()
    {
       solver.bones[0].weight = 1f;
        solver.bones[1].weight = 0.25f;
        solver.bones[2].weight = 0.1f;
        solver.bones[3].weight = 1f;
        solver.bones[4].weight = 0.1f;
        solver.bones[5].weight = 1f;

        Base1Locked.enabled = false;
        Base1Unlocked.enabled = true;

        Arm2Locked.enabled = false;
        Arm2Unlocked.enabled = true;

        Arm3Locked.enabled = false;
        Arm3Unlocked.enabled = true;

        Wrist4Locked.enabled = false;
        Wrist4Unlocked.enabled = true;

        Bend5Locked.enabled = false;
        Bend5Unlocked.enabled = true;

    }

    public void EnableAxisLocking()
    {
        axislocking = true;
    }

    public void DisableAxisLocking()
    {
        axislocking = false;
    }

    public void AxisLockingBase1()
    {
        if (axislocking) { 

            if(Base1Unlocked.enabled == true)
            {
                solver.bones[0].weight = 0f;
                Base1Unlocked.enabled = false;
                Base1Locked.enabled = true;
            }

            else if (Base1Unlocked.enabled == false)
            {
                solver.bones[0].weight = 1f;
                Base1Unlocked.enabled = true;
                Base1Locked.enabled = true;
            }
        
        }
    }

    public void AxisLockingArm2()
    {
        if (axislocking)
        {

            if (Arm2Unlocked.enabled == true)
            {
                solver.bones[1].weight = 0f;
                Arm2Unlocked.enabled = false;
                Arm2Locked.enabled = true;
            }

            else if (Arm2Unlocked.enabled == false)
            {
                solver.bones[1].weight = 0.25f;
                Arm2Unlocked.enabled = true;
                Arm2Locked.enabled = false;
            }

        }
    }

    public void AxisLockingArm3()
    {
        if (axislocking)
        {

            if (Arm3Unlocked.enabled == true)
            {
                solver.bones[2].weight = 0f;
                Arm3Unlocked.enabled = false;
                Arm3Locked.enabled = true;
            }

            else if (Arm3Unlocked.enabled == false)
            {
                solver.bones[2].weight = 0.1f;
                Arm3Unlocked.enabled = true;
                Arm3Locked.enabled = false;
            }

        }
    }

    public void AxisLockingWrist4()
    {
        if (axislocking)
        {

            if (Wrist4Unlocked.enabled == true)
            {
                solver.bones[3].weight = 0f;
                Wrist4Unlocked.enabled = false;
                Wrist4Locked.enabled = true;
            }

            else if (Wrist4Unlocked.enabled == false)
            {
                solver.bones[3].weight = 1f;
                Wrist4Unlocked.enabled = true;
                Wrist4Locked.enabled = false;
            }

        }
    }

    public void AxisLockingBend5()
    {
        if (axislocking)
        {

            if (Bend5Unlocked.enabled == true)
            {
                solver.bones[4].weight = 0f;
                Bend5Unlocked.enabled = false;
                Bend5Locked.enabled = true;
            }

            else if (Bend5Unlocked.enabled == false)
            {
                solver.bones[4].weight = 0.1f;
                Bend5Unlocked.enabled = true;
                Bend5Locked.enabled = false;
            }

        }
    }


}
