using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalParameters : MonoBehaviour
{
    public float sst_j1, sst_j2, sst_j3, sst_j4, sst_j5, sst_j6;

    public float apo_j1lower, apo_j2lower, apo_j3lower, apo_j4lower, apo_j5lower, apo_j6lower;
    public float apo_j1upper, apo_j2upper, apo_j3upper, apo_j4upper, apo_j5upper, apo_j6upper;

    public float asp_j1min, asp_j2min, asp_j3min, asp_j4min, asp_j5min, asp_j6min;
    public float asp_j1max, asp_j2max, asp_j3max, asp_j4max, asp_j5max, asp_j6max;

    public string invert, allow;

    public bool sst_on, tsp_on, asp_on, tor_on, apo_on, tpo_on;

    public FinalAxisValues final;

    public void PasstoFinal()
    { 
            final.apo_j1lower = apo_j1lower;
            final.apo_j2lower = apo_j2lower;
            final.apo_j3lower = apo_j3lower;
            final.apo_j4lower = apo_j4lower;
            final.apo_j5lower = apo_j5lower;
            final.apo_j6lower = apo_j6lower;

            final.apo_j1upper = apo_j1upper;
            final.apo_j2upper = apo_j2upper;
            final.apo_j3upper = apo_j3upper;
            final.apo_j4upper = apo_j4upper;
            final.apo_j5upper = apo_j5upper;
            final.apo_j6upper = apo_j6upper;

            final.invert = invert;
            final.allow = allow; 

            final.asp_j1min = asp_j1min;
            final.asp_j2min = asp_j2min;
            final.asp_j3min = asp_j3min;
            final.asp_j4min = asp_j4min;
            final.asp_j5min = asp_j5min;
            final.asp_j6min = asp_j6min;

            final.asp_j1max = asp_j1max;
            final.asp_j2max = asp_j2max;
            final.asp_j3max = asp_j3max;
            final.asp_j4max = asp_j4max;
            final.asp_j5max = asp_j5max;
            final.asp_j6max = asp_j6max;
       
            final.sst_j1 = sst_j1;
            final.sst_j2 = sst_j2;
            final.sst_j3 = sst_j3;
            final.sst_j4 = sst_j4;
            final.sst_j5 = sst_j5;
            final.sst_j6 = sst_j6;

       final.SetAPO();
       final.SetASP();
       final.SetSST();
    }

}
