using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalParameterStorage : MonoBehaviour
{

    //SST
    public TextMeshPro rot1_tolerance, arm2_tolerance, arm3_tolerance, wrist4_tolerance, bend5_tolerance, turn6_tolerance, activation_sst, status_sst, stop_sst, signal_sst, manual_sst;
    public float rot1_tolerance_num, arm2_tolerance_num, arm3_tolerance_num, wrist4_tolerance_num, bend5_tolerance_num, turn6_tolerance_num;

    //ASP
    public TextMeshPro rot1_minspeed, arm2_minspeed, arm3_minspeed, wrist4_minspeed, bend5_minspeed, turn6_minspeed, rot1_maxspeed, arm2_maxspeed, arm3_maxspeed, wrist4_maxspeed, bend5_maxspeed, turn6_maxspeed, activation_asp, status_asp, stop_asp, signal_asp;
    public float rot1_minspeed_num, arm2_minspeed_num, arm3_minspeed_num, wrist4_minspeed_num, bend5_minspeed_num, turn6_minspeed_num, rot1_maxspeed_num, arm2_maxspeed_num, arm3_maxspeed_num, wrist4_maxspeed_num, bend5_maxspeed_num, turn6_maxspeed_num;

    //TSP
    public TextMeshPro minspeed_tsp, maxspeed_tsp, activation_tsp, status_tsp, stopcat_tsp, signal_tsp;
    public float minspeed_tsp_num, maxspeed_tsp_num;

    //APO
    public TextMeshPro rot1_lowerbound, arm2_lowerbound, arm3_lowerbound, wrist4_lowerbound, bend5_lowerbound, turn6_lowerbound, rot1_upperbound, arm2_upperbound, arm3_upperbound, wrist4_upperbound, bend5_upperbound, turn6_upperbound, invert_apo, activation_apo, status_apo, inside_apo, stop_apo, signal_apo;
    public float rot1_lowerbound_num, arm2_lowerbound_num, arm3_lowerbound_num, wrist4_lowerbound_num, bend5_lowerbound_num, turn6_lowerbound_num, rot1_upperbound_num, arm2_upperbound_num, arm3_upperbound_num, wrist4_upperbound_num, bend5_upperbound_num, turn6_upperbound_num;

    //TPO
    public TextMeshPro activation_tpo, status_tpo, stopcat_tpo, signal_tpo, upperarm_tpo, inside_tpo;

    //TOR
    public TextMeshPro xvectorenabled_tor, xvectorx_tor, xvectory_tor, xvectorz_tor, xvectortolerance_tor, zvectorenabled_tor, zvectorx_tor, zvectory_tor, zvectorz_tor, zvectortolerance_tor, activation_tor, status_tor, stopcat_tor, signal_tor;
    public float xvectorx_tor_num, xvectory_tor_num, xvectorz_tor_num, xvectortolerance_tor_num, zvectorx_tor_num, zvectory_tor_num, zvectorz_tor_num, zvectortolerance_tor_num;

    public void UpdateParameters()
    {
        rot1_tolerance.text = $"{rot1_tolerance_num:F2}" + "°";
        arm2_tolerance.text = $"{arm2_tolerance_num:F2}" + "°";
        arm3_tolerance.text = $"{arm3_tolerance_num:F2}" + "°";
        wrist4_tolerance.text = $"{wrist4_tolerance_num:F2}" + "°";
        bend5_tolerance.text = $"{bend5_tolerance_num:F2}" + "°";
        turn6_tolerance.text = $"{turn6_tolerance_num:F2}" + "°";

        rot1_minspeed.text = $"{rot1_minspeed_num:F2}" + "°/s";
        arm2_minspeed.text = $"{arm2_minspeed_num:F2}" + "°/s";
        arm3_minspeed.text = $"{arm3_minspeed_num:F2}" + "°/s";
        wrist4_minspeed.text = $"{wrist4_minspeed_num:F2}" + "°/s";
        bend5_minspeed.text = $"{bend5_minspeed_num:F2}" + "°/s";
        turn6_minspeed.text = $"{turn6_minspeed_num:F2}" + "°/s";

        rot1_maxspeed.text = $"{rot1_maxspeed_num:F2}" + "°/s";
        arm2_maxspeed.text = $"{arm2_maxspeed_num:F2}" + "°/s";
        arm3_maxspeed.text = $"{arm3_maxspeed_num:F2}" + "°/s";
        wrist4_maxspeed.text = $"{wrist4_maxspeed_num:F2}" + "°/s";
        bend5_maxspeed.text = $"{bend5_maxspeed_num:F2}" + "°/s";
        turn6_maxspeed.text = $"{turn6_maxspeed_num:F2}" + "°/s";

        minspeed_tsp.text = $"{minspeed_tsp_num:F2}" + "mm/s";
        maxspeed_tsp.text = $"{maxspeed_tsp_num:F2}" + "mm/s";

        rot1_lowerbound.text = $"{rot1_lowerbound_num:F2}" + "°";
        arm2_lowerbound.text = $"{arm2_lowerbound_num:F2}" + "°";
        arm3_lowerbound.text = $"{arm3_lowerbound_num:F2}" + "°";
        wrist4_lowerbound.text = $"{wrist4_lowerbound_num:F2}" + "°";
        bend5_lowerbound.text = $"{bend5_lowerbound_num:F2}" + "°";
        turn6_lowerbound.text = $"{turn6_lowerbound_num:F2}" + "°";

        rot1_upperbound.text = $"{rot1_upperbound_num:F2}" + "°";
        arm2_upperbound.text = $"{arm2_upperbound_num:F2}" + "°";
        arm3_upperbound.text = $"{arm3_upperbound_num:F2}" + "°";
        wrist4_upperbound.text = $"{wrist4_upperbound_num:F2}" + "°";
        bend5_upperbound.text = $"{bend5_upperbound_num:F2}" + "°";
        turn6_upperbound.text = $"{turn6_upperbound_num:F2}" + "°";

        xvectorx_tor.text = $"{xvectorx_tor_num:F2}" + "mm";
        xvectory_tor.text = $"{xvectory_tor_num:F2}" + "mm";
        xvectorz_tor.text = $"{xvectorz_tor_num:F2}" + "mm";
        xvectortolerance_tor.text = $"{xvectortolerance_tor_num:F2}" + "mm";

        zvectorx_tor.text = $"{zvectorx_tor_num:F2}" + "mm";
        zvectory_tor.text = $"{zvectory_tor_num:F2}" + "mm";
        zvectorz_tor.text = $"{zvectorz_tor_num:F2}" + "mm";
        zvectortolerance_tor.text = $"{zvectortolerance_tor_num:F2}" + "mm";

    }
}
