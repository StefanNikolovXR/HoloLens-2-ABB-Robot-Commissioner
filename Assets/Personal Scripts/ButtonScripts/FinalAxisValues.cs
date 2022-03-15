using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;

public class FinalAxisValues : MonoBehaviour
{
    
    public float sst_j1, sst_j2, sst_j3, sst_j4, sst_j5, sst_j6;

    public float asp_j1min, asp_j2min, asp_j3min, asp_j4min, asp_j5min, asp_j6min;

    public float asp_j1max, asp_j2max, asp_j3max, asp_j4max, asp_j5max, asp_j6max;

    public float apo_j1lower, apo_j2lower, apo_j3lower, apo_j4lower, apo_j5lower, apo_j6lower;

    public float apo_j1upper, apo_j2upper, apo_j3upper, apo_j4upper, apo_j5upper, apo_j6upper;

    public bool sst, global_apo, global_asp, global_tor, global_tpo, global_tsp;

    public string invert, allow;

    public bool zone_apo, zone_asp, zone_tsp, zone_tor, zone_tpo;

    public LeanEvent slider_appear;

    public LeanEvent slider_disappear;

    public RPMAxisMonitoring rpm;
    public MinMaxSpeed minmax;
    public GlobalParameters global;
    public AxisArcVisualization axis;

    public Shaper2D sstj1_left, sstj1_right, sstj2_left, sstj2_right, sstj3_left, sstj3_right, sstj4_left, sstj4_right, sstj5_left, sstj5_right, sstj6_left, sstj6_right;

    void Start()
    {
        apo_j1lower = -165;
        apo_j2lower = -110;
        apo_j3lower = -110;
        apo_j4lower = -160;
        apo_j5lower = -120;
        apo_j6lower = -400;

        apo_j1upper = 165;
        apo_j2upper = 110;
        apo_j3upper = 70;
        apo_j4upper = 160;
        apo_j5upper = 120;
        apo_j6upper = 400;

        asp_j1min = 0;
        asp_j2min = 0;
        asp_j3min = 0;
        asp_j4min = 0;
        asp_j5min = 0;
        asp_j6min = 0;

        asp_j1max = 250;
        asp_j2max = 250;
        asp_j3max = 250;
        asp_j4max = 320;
        asp_j5max = 320;
        asp_j6max = 420;

        invert = "Normal";
        allow = "Allowed";

        minmax.AdjustSpeed();
        axis.ProcessfromFinal();
    }

    public void ExitZone()
    {
        zone_apo = false;
        zone_tsp = false;
        zone_tpo = false;
        zone_asp = false;
        zone_tor = false;
    }

    public void J1_CheckValues()
    {
       /* if (global_apo)
        {
            if (apo_j1lower == apo_j1upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j1lower == apo_j1upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void J2_CheckValues()
    {
       /* if (global_apo)
        {
            if (apo_j2lower == apo_j2upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j2lower == apo_j2upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void J3_CheckValues()
    {
       /* if (global_apo)
        {
            if (apo_j3lower == apo_j3upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j3lower == apo_j3upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void J4_CheckValues()
    {
       /* if (global_apo)
        {
            if (apo_j4lower == apo_j4upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j4lower == apo_j4upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void J5_CheckValues()
    {
       /* if (global_apo)
        {
            if (apo_j5lower == apo_j5upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j5lower == apo_j5upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void J6_CheckValues()
    {
      /*  if (global_apo)
        {
            if (apo_j6lower == apo_j6upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else if (zone_apo)
        {
            if (apo_j6lower == apo_j6upper)
            { slider_disappear.BeginAllTransitions(); }
            else slider_appear.BeginAllTransitions();
        }

        else slider_disappear.BeginAllTransitions();*/

    }

    public void FixSlider()
    {
        //slider_appear.BeginAllTransitions();
    }

    public void SetAPO()
    {
        axis.ProcessfromFinal();
    }

    public void SetSST()
    {
        sstj1_left.arcDegrees = sst_j1 / 2;
        sstj1_right.arcDegrees = sst_j1 / 2;

        sstj2_left.arcDegrees = sst_j2 / 2;
        sstj2_right.arcDegrees = sst_j2 / 2;

        sstj3_left.arcDegrees = sst_j3 / 2;
        sstj3_right.arcDegrees = sst_j3 / 2;

        sstj4_left.arcDegrees = sst_j4 / 2;
        sstj4_right.arcDegrees = sst_j4 / 2;

        sstj5_left.arcDegrees = sst_j5 / 2;
        sstj5_right.arcDegrees = sst_j5 / 2;

        sstj6_left.arcDegrees = sst_j6 / 2;
        sstj6_right.arcDegrees = sst_j6 / 2;

    }

    public void SetASP()
    {
        rpm.ParseMinMaxSpeeds();
        minmax.AdjustSpeed();

        /*if (zone_asp) { 

        rpm.ParseMinMaxSpeeds();
        minmax.AdjustSpeed();
        }

        else
        {
            global.PasstoFinal();
            rpm.ParseMinMaxSpeeds();
            minmax.AdjustSpeed();
        }*/

    }

    //  public float j1_min, j2_min, j2_min, j2_min, j2_min, j2_min;
}
