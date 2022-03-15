using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeZoneStoredData : MonoBehaviour
{
    public GameObject parent;

    public GameObject selecteddisk;

    public TMP_InputField asp_j1min_tmp, asp_j2min_tmp, asp_j3min_tmp, asp_j4min_tmp, asp_j5min_tmp, asp_j6min_tmp;
    public TMP_InputField asp_j1max_tmp, asp_j2max_tmp, asp_j3max_tmp, asp_j4max_tmp, asp_j5max_tmp, asp_j6max_tmp;

    public TMP_InputField apo_j1lower_tmp, apo_j2lower_tmp, apo_j3lower_tmp, apo_j4lower_tmp, apo_j5lower_tmp, apo_j6lower_tmp;
    public TMP_InputField apo_j1upper_tmp, apo_j2upper_tmp, apo_j3upper_tmp, apo_j4upper_tmp, apo_j5upper_tmp, apo_j6upper_tmp;

    public TextMeshPro inverted_tmp, allowed_tmp;

    public float apo_j1lower, apo_j2lower, apo_j3lower, apo_j4lower, apo_j5lower, apo_j6lower;
    public float apo_j1upper, apo_j2upper, apo_j3upper, apo_j4upper, apo_j5upper, apo_j6upper;

    public float asp_j1min, asp_j2min, asp_j3min, asp_j4min, asp_j5min, asp_j6min;
    public float asp_j1max, asp_j2max, asp_j3max, asp_j4max, asp_j5max, asp_j6max;

    public string invert, allow;

    public bool active, asp_on, tsp_on, apo_on, tpo_on, tor_on;

    public ZoneValues zonevalues;

    public GlobalParameters global;

    public TextMeshPro zonetext;

    public FinalAxisValues final;

    public EnableASP enable_asp;
    public EnableTSP enable_tsp;
    public EnableAPO enable_apo;
    public EnableTPO enable_tpo;
    public EnableTOR enable_tor;
    public EnableSST enable_sst;

    public Projection projection;
    public EdgeXYZ edgexyz;
    public EdgeLines edgelines;
    public FloorDistance wallstopbot;
    public EditHandles edithandles;
    public MoveZone movezone;
    public CollapseExpandZone collapseexpand;

    public bool floor, xyz, lines, walls, edit, move, expandactive;

    void Start()
    {
        floor = true;
        lines = true;
        walls = true;
        edit = true;
        move = false;
        xyz = false;
        expandactive = true;

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

        active = false;
        asp_on = false;
        tsp_on = false;
        apo_on = false;
        tpo_on = false;
        tor_on = false;

    }

    public void PressCenter()
    {
        if (active)
        {
            RevertData();
        }

        else 
            PassData();
    }

    public void PassData()
    {
       /* var allcenters = GameObject.FindGameObjectsWithTag("Center");

        foreach (GameObject center in allcenters)
        {
            center.GetComponent<SafeZoneStoredData>().RevertData();
        }*/

        selecteddisk.GetComponent<MeshRenderer>().enabled = true;
        zonetext.text = "Zone Tools";

        active = true;

        zonevalues.selectedzone = parent;

        apo_j1lower_tmp.text = $"{apo_j1lower:F2}";
        apo_j2lower_tmp.text = $"{apo_j2lower:F2}";
        apo_j3lower_tmp.text = $"{apo_j3lower:F2}";
        apo_j4lower_tmp.text = $"{apo_j4lower:F2}";
        apo_j5lower_tmp.text = $"{apo_j5lower:F2}";
        apo_j6lower_tmp.text = $"{apo_j6lower:F2}";

        apo_j1upper_tmp.text = $"{apo_j1upper:F2}";
        apo_j2upper_tmp.text = $"{apo_j2upper:F2}";
        apo_j3upper_tmp.text = $"{apo_j3upper:F2}";
        apo_j4upper_tmp.text = $"{apo_j4upper:F2}";
        apo_j5upper_tmp.text = $"{apo_j5upper:F2}";
        apo_j6upper_tmp.text = $"{apo_j6upper:F2}";

        asp_j1min_tmp.text = $"{asp_j1min:F2}";
        asp_j2min_tmp.text = $"{asp_j2min:F2}";
        asp_j3min_tmp.text = $"{asp_j3min:F2}";
        asp_j4min_tmp.text = $"{asp_j4min:F2}";
        asp_j5min_tmp.text = $"{asp_j5min:F2}";
        asp_j6min_tmp.text = $"{asp_j6min:F2}";

        asp_j1max_tmp.text = $"{asp_j1max:F2}";
        asp_j2max_tmp.text = $"{asp_j2max:F2}";
        asp_j3max_tmp.text = $"{asp_j3max:F2}";
        asp_j4max_tmp.text = $"{asp_j4max:F2}";
        asp_j5max_tmp.text = $"{asp_j5max:F2}";
        asp_j6max_tmp.text = $"{asp_j6max:F2}";

        inverted_tmp.text = invert;
        allowed_tmp.text = allow;

        zonevalues.asp_on = asp_on;
        zonevalues.tsp_on = tsp_on;
        zonevalues.apo_on = apo_on;
        zonevalues.tpo_on = tpo_on;
        zonevalues.tor_on = tor_on;

        zonevalues.storeddata = transform.gameObject.GetComponent<SafeZoneStoredData>();

        CheckEnableDisable();

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

        final.invert = invert;
        final.allow = allow;

        final.SetAPO();
        final.SetASP();
    }

    public void RevertData()
    {

        selecteddisk.GetComponent<MeshRenderer>().enabled = false;
        zonetext.text = "Global Tools";

        zonevalues.selectedzone = null;

        apo_j1lower_tmp.text = $"{global.apo_j1lower:F2}";
        apo_j2lower_tmp.text = $"{global.apo_j2lower:F2}";
        apo_j3lower_tmp.text = $"{global.apo_j3lower:F2}";
        apo_j4lower_tmp.text = $"{global.apo_j4lower:F2}";
        apo_j5lower_tmp.text = $"{global.apo_j5lower:F2}";
        apo_j6lower_tmp.text = $"{global.apo_j6lower:F2}";

        apo_j1upper_tmp.text = $"{global.apo_j1upper:F2}";
        apo_j2upper_tmp.text = $"{global.apo_j2upper:F2}";
        apo_j3upper_tmp.text = $"{global.apo_j3upper:F2}";
        apo_j4upper_tmp.text = $"{global.apo_j4upper:F2}";
        apo_j5upper_tmp.text = $"{global.apo_j5upper:F2}";
        apo_j6upper_tmp.text = $"{global.apo_j6upper:F2}";

        asp_j1min_tmp.text = $"{global.asp_j1min:F2}";
        asp_j2min_tmp.text = $"{global.asp_j2min:F2}";
        asp_j3min_tmp.text = $"{global.asp_j3min:F2}";
        asp_j4min_tmp.text = $"{global.asp_j4min:F2}";
        asp_j5min_tmp.text = $"{global.asp_j5min:F2}";
        asp_j6min_tmp.text = $"{global.asp_j6min:F2}";

        asp_j1max_tmp.text = $"{global.asp_j1max:F2}";
        asp_j2max_tmp.text = $"{global.asp_j2max:F2}";
        asp_j3max_tmp.text = $"{global.asp_j3max:F2}";
        asp_j4max_tmp.text = $"{global.asp_j4max:F2}";
        asp_j5max_tmp.text = $"{global.asp_j5max:F2}";
        asp_j6max_tmp.text = $"{global.asp_j6max:F2}";

        inverted_tmp.text = global.invert;
        allowed_tmp.text = global.allow;

        active = false;

        final.apo_j1lower = global.apo_j1lower;
        final.apo_j2lower = global.apo_j2lower;
        final.apo_j3lower = global.apo_j3lower;
        final.apo_j4lower = global.apo_j4lower;
        final.apo_j5lower = global.apo_j5lower;
        final.apo_j6lower = global.apo_j6lower;

        final.apo_j1upper = global.apo_j1upper;
        final.apo_j2upper = global.apo_j2upper;
        final.apo_j3upper = global.apo_j3upper;
        final.apo_j4upper = global.apo_j4upper;
        final.apo_j5upper = global.apo_j5upper;
        final.apo_j6upper = global.apo_j6upper;

        final.asp_j1min = global.asp_j1min;
        final.asp_j2min = global.asp_j2min;
        final.asp_j3min = global.asp_j3min;
        final.asp_j4min = global.asp_j4min;
        final.asp_j5min = global.asp_j5min;
        final.asp_j6min = global.asp_j6min;

        final.asp_j1max = global.asp_j1max;
        final.asp_j2max = global.asp_j2max;
        final.asp_j3max = global.asp_j3max;
        final.asp_j4max = global.asp_j4max;
        final.asp_j5max = global.asp_j5max;
        final.asp_j6max = global.asp_j6max;

        final.invert = global.invert;
        final.allow = global.allow;

        final.SetAPO();
        final.SetASP();

        GlobalCheckEnableDisable();
    }

    public void EnterZone()
    {
       
    }

    public void CheckEnableDisable()
    {
        if (asp_on)
        {
            enable_asp.ForceShow();
            zonevalues.asp_on = true;
        }

        else
        {
            enable_asp.ForceCollapse();
            zonevalues.asp_on = false;
        }

        if (tsp_on)
        {
            enable_tsp.ForceShow();
            zonevalues.tsp_on = true;
        }

        else
        {
            enable_tsp.ForceCollapse();
            zonevalues.tsp_on = false;
        }

        if (apo_on)
        {
            enable_apo.ForceShow();
            zonevalues.apo_on = true;
        }

        else
        {
            enable_apo.ForceCollapse();
            zonevalues.apo_on = false;
        }

        if (tpo_on)
        {
            enable_tpo.ForceShow();
            zonevalues.tpo_on = true;
        }

        else
        {
            enable_tpo.ForceCollapse();
            zonevalues.tpo_on = false;
        }

        if (tor_on)
        {
            enable_tor.ForceShow();
            zonevalues.tor_on = true;
        }

        else
        {
            enable_tor.ForceCollapse();
            zonevalues.tor_on = false;
        }

        if (floor)
        {
            projection.ForceShow();
        }

        else projection.ForceCollapse();

        if (xyz)
        {
            edgexyz.ForceShow();
        }

        else edgexyz.ForceCollapse();

        if (lines)
        {
            edgelines.ForceShow();
        }

        else edgelines.ForceCollapse();

        if (walls)
        {
            wallstopbot.ForceShow();
        }

        else wallstopbot.ForceCollapse();

        if (edit)
        {
            edithandles.ForceShow();
        }

        else edithandles.ForceCollapse();

        if (move)
        {
            movezone.ForceShow();
        }

        else movezone.ForceCollapse();

        if (expandactive)
        {
            collapseexpand.ForceShow();
        }
    }

public void GlobalCheckEnableDisable()
        {

            if (global.asp_on)
            {
                enable_asp.ForceShow();
                zonevalues.asp_on = true;
            }

            else
            {
                enable_asp.ForceCollapse();
                zonevalues.asp_on = false;
            }

            if (global.tsp_on)
            {
                enable_tsp.ForceShow();
                zonevalues.tsp_on = true;
            }

            else
            {
                enable_tsp.ForceCollapse();
                zonevalues.tsp_on = false;
            }

            if (global.apo_on)
            {
                enable_apo.ForceShow();
                zonevalues.apo_on = true;
            }

            else
            {
                enable_apo.ForceCollapse();
                zonevalues.apo_on = false;
            }

            if (global.tpo_on)
            {
                enable_tpo.ForceShow();
                zonevalues.tpo_on = true;
            }

            else
            {
                enable_tpo.ForceCollapse();
                zonevalues.tpo_on = false;
            }

            if (global.tor_on)
            {
                enable_tor.ForceShow();
                zonevalues.tor_on = true;
            }

            else
            {
                enable_tor.ForceCollapse();
                zonevalues.tor_on = false;
            }

        }

    public void PasstoFinal()
    {
        if (apo_on)
        {
            final.apo_j1lower = apo_j1lower;
            final.apo_j2lower = apo_j2lower;
            final.apo_j3lower = apo_j3lower;
            final.apo_j4lower = apo_j4lower;
            final.apo_j5lower = apo_j5lower;
            final.apo_j6lower = apo_j6lower;

            final.invert = invert;
            final.allow = allow;
        }

        if (asp_on)
        {
            final.asp_j1min = asp_j1min;
            final.asp_j2min = asp_j2min;
            final.asp_j3min = asp_j3min;
            final.asp_j4min = asp_j4min;
            final.asp_j5min = asp_j5min;
            final.asp_j6min = asp_j6min;
        }
    }

}
