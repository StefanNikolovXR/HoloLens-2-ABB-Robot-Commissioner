using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneValues : MonoBehaviour
{
    public TMP_InputField asp_j1min_tmp, asp_j2min_tmp, asp_j3min_tmp, asp_j4min_tmp, asp_j5min_tmp, asp_j6min_tmp;
    public TMP_InputField asp_j1max_tmp, asp_j2max_tmp, asp_j3max_tmp, asp_j4max_tmp, asp_j5max_tmp, asp_j6max_tmp;

    public TMP_InputField apo_j1lower_tmp, apo_j2lower_tmp, apo_j3lower_tmp, apo_j4lower_tmp, apo_j5lower_tmp, apo_j6lower_tmp;
    public TMP_InputField apo_j1upper_tmp, apo_j2upper_tmp, apo_j3upper_tmp, apo_j4upper_tmp, apo_j5upper_tmp, apo_j6upper_tmp;

    public TMP_InputField sst_j1_tmp, sst_j2_tmp, sst_j3_tmp, sst_j4_tmp, sst_j5_tmp, sst_j6_tmp;

    public float asp_j1min_num, asp_j2min_num, asp_j3min_num, asp_j4min_num, asp_j5min_num, asp_j6min_num;
    public float asp_j1max_num, asp_j2max_num, asp_j3max_num, asp_j4max_num, asp_j5max_num, asp_j6max_num;

    public float apo_j1lower_num, apo_j2lower_num, apo_j3lower_num, apo_j4lower_num, apo_j5lower_num, apo_j6lower_num;
    public float apo_j1upper_num, apo_j2upper_num, apo_j3upper_num, apo_j4upper_num, apo_j5upper_num, apo_j6upper_num;

    public float sst_j1_num, sst_j2_num, sst_j3_num, sst_j4_num, sst_j5_num, sst_j6_num;

    public TextMeshPro inverted_tmp, allowed_tmp;

    public string inverted_str, allowed_str;

    public bool asp_on, tsp_on, apo_on, tpo_on, tor_on, sst_on;

    public GameObject selectedzone;

    public SafeZoneStoredData storeddata;

    public FinalAxisValues final;

    public GlobalParameters global;

    public GameObject datacontainer;

    public TextMeshPro zonetext;

    void Start()
    {
        asp_j1min_num = float.Parse(asp_j1min_tmp.text);
        asp_j2min_num = float.Parse(asp_j2min_tmp.text);
        asp_j3min_num = float.Parse(asp_j3min_tmp.text);
        asp_j4min_num = float.Parse(asp_j4min_tmp.text);
        asp_j5min_num = float.Parse(asp_j5min_tmp.text);
        asp_j6min_num = float.Parse(asp_j6min_tmp.text);

        asp_j1max_num = float.Parse(asp_j1max_tmp.text);
        asp_j2max_num = float.Parse(asp_j2max_tmp.text);
        asp_j3max_num = float.Parse(asp_j3max_tmp.text);
        asp_j4max_num = float.Parse(asp_j4max_tmp.text);
        asp_j5max_num = float.Parse(asp_j5max_tmp.text);
        asp_j6max_num = float.Parse(asp_j6max_tmp.text);

        sst_j1_num = float.Parse(sst_j1_tmp.text);
        sst_j2_num = float.Parse(sst_j2_tmp.text);
        sst_j3_num = float.Parse(sst_j3_tmp.text);
        sst_j4_num = float.Parse(sst_j4_tmp.text);
        sst_j5_num = float.Parse(sst_j5_tmp.text);
        sst_j6_num = float.Parse(sst_j6_tmp.text);

        apo_j1lower_num = float.Parse(apo_j1lower_tmp.text);
        apo_j2lower_num = float.Parse(apo_j2lower_tmp.text);
        apo_j3lower_num = float.Parse(apo_j3lower_tmp.text);
        apo_j4lower_num = float.Parse(apo_j4lower_tmp.text);
        apo_j5lower_num = float.Parse(apo_j5lower_tmp.text);
        apo_j6lower_num = float.Parse(apo_j6lower_tmp.text);

        apo_j1upper_num = float.Parse(apo_j1upper_tmp.text);
        apo_j2upper_num = float.Parse(apo_j2upper_tmp.text);
        apo_j3upper_num = float.Parse(apo_j3upper_tmp.text);
        apo_j4upper_num = float.Parse(apo_j4upper_tmp.text);
        apo_j5upper_num = float.Parse(apo_j5upper_tmp.text);
        apo_j6upper_num = float.Parse(apo_j6upper_tmp.text);

        inverted_str = inverted_tmp.text;
        allowed_str = allowed_tmp.text;
    }

    public void DataChanged()
    {
        asp_j1min_num = float.Parse(asp_j1min_tmp.text);
        asp_j2min_num = float.Parse(asp_j2min_tmp.text);
        asp_j3min_num = float.Parse(asp_j3min_tmp.text);
        asp_j4min_num = float.Parse(asp_j4min_tmp.text);
        asp_j5min_num = float.Parse(asp_j5min_tmp.text);
        asp_j6min_num = float.Parse(asp_j6min_tmp.text);

        asp_j1max_num = float.Parse(asp_j1max_tmp.text);
        asp_j2max_num = float.Parse(asp_j2max_tmp.text);
        asp_j3max_num = float.Parse(asp_j3max_tmp.text);
        asp_j4max_num = float.Parse(asp_j4max_tmp.text);
        asp_j5max_num = float.Parse(asp_j5max_tmp.text);
        asp_j6max_num = float.Parse(asp_j6max_tmp.text);

        sst_j1_num = float.Parse(sst_j1_tmp.text);
        sst_j2_num = float.Parse(sst_j2_tmp.text);
        sst_j3_num = float.Parse(sst_j3_tmp.text);
        sst_j4_num = float.Parse(sst_j4_tmp.text);
        sst_j5_num = float.Parse(sst_j5_tmp.text);
        sst_j6_num = float.Parse(sst_j6_tmp.text);

        apo_j1lower_num = float.Parse(apo_j1lower_tmp.text);
        apo_j2lower_num = float.Parse(apo_j2lower_tmp.text);
        apo_j3lower_num = float.Parse(apo_j3lower_tmp.text);
        apo_j4lower_num = float.Parse(apo_j4lower_tmp.text);
        apo_j5lower_num = float.Parse(apo_j5lower_tmp.text);
        apo_j6lower_num = float.Parse(apo_j6lower_tmp.text);

        apo_j1upper_num = float.Parse(apo_j1upper_tmp.text);
        apo_j2upper_num = float.Parse(apo_j2upper_tmp.text);
        apo_j3upper_num = float.Parse(apo_j3upper_tmp.text);
        apo_j4upper_num = float.Parse(apo_j4upper_tmp.text);
        apo_j5upper_num = float.Parse(apo_j5upper_tmp.text);
        apo_j6upper_num = float.Parse(apo_j6upper_tmp.text);

        inverted_str = inverted_tmp.text;
        allowed_str = allowed_tmp.text;

        if(zonetext.text == "Global Tools")
        {
            global.asp_j1min = asp_j1min_num;
            global.asp_j2min = asp_j2min_num;
            global.asp_j3min = asp_j3min_num;
            global.asp_j4min = asp_j4min_num;
            global.asp_j5min = asp_j5min_num;
            global.asp_j6min = asp_j6min_num;

            global.asp_j1max = asp_j1max_num;
            global.asp_j2max = asp_j2max_num;
            global.asp_j3max = asp_j3max_num;
            global.asp_j4max = asp_j4max_num;
            global.asp_j5max = asp_j5max_num;
            global.asp_j6max = asp_j6max_num;

            global.invert = inverted_str;
            global.allow = allowed_str;

            global.apo_j1lower = apo_j1lower_num;
            global.apo_j2lower = apo_j2lower_num;
            global.apo_j3lower = apo_j3lower_num;
            global.apo_j4lower = apo_j4lower_num;
            global.apo_j5lower = apo_j5lower_num;
            global.apo_j6lower = apo_j6lower_num;

            global.apo_j1upper = apo_j1upper_num;
            global.apo_j2upper = apo_j2upper_num;
            global.apo_j3upper = apo_j3upper_num;
            global.apo_j4upper = apo_j4upper_num;
            global.apo_j5upper = apo_j5upper_num;
            global.apo_j6upper = apo_j6upper_num;

            global.sst_j1 = sst_j1_num;
            global.sst_j2 = sst_j2_num;
            global.sst_j3 = sst_j3_num;
            global.sst_j4 = sst_j4_num;
            global.sst_j5 = sst_j5_num;
            global.sst_j6 = sst_j6_num;

            global.asp_on = asp_on;
            global.tsp_on = tsp_on;
            global.apo_on = apo_on;
            global.tpo_on = tpo_on;
            global.tor_on = tor_on;
            global.sst_on = sst_on;

            global.PasstoFinal();
        }

        else if (zonetext.text == "Zone Tools")
        {
            datacontainer = selectedzone.transform.Find("Stored_Data").transform.gameObject;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j1min = asp_j1min_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j2min = asp_j2min_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j3min = asp_j3min_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j4min = asp_j4min_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j5min = asp_j5min_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j6min = asp_j6min_num;

            datacontainer.GetComponent<SafeZoneStoredData>().asp_j1max = asp_j1max_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j2max = asp_j2max_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j3max = asp_j3max_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j4max = asp_j4max_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j5max = asp_j5max_num;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_j6max = asp_j6max_num;

            datacontainer.GetComponent<SafeZoneStoredData>().apo_j1lower = apo_j1lower_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j2lower = apo_j2lower_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j3lower = apo_j3lower_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j4lower = apo_j4lower_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j5lower = apo_j5lower_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j6lower = apo_j6lower_num;

            datacontainer.GetComponent<SafeZoneStoredData>().apo_j1upper = apo_j1upper_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j2upper = apo_j2upper_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j3upper = apo_j3upper_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j4upper = apo_j4upper_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j5upper = apo_j5upper_num;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_j6upper = apo_j6upper_num;

            datacontainer.GetComponent<SafeZoneStoredData>().tsp_on = tsp_on;
            datacontainer.GetComponent<SafeZoneStoredData>().asp_on = asp_on;
            datacontainer.GetComponent<SafeZoneStoredData>().apo_on = apo_on;
            datacontainer.GetComponent<SafeZoneStoredData>().tpo_on = tsp_on;
            datacontainer.GetComponent<SafeZoneStoredData>().tor_on = tsp_on;

            datacontainer.GetComponent<SafeZoneStoredData>().invert = inverted_str;
            datacontainer.GetComponent<SafeZoneStoredData>().allow = allowed_str;

            datacontainer.GetComponent<SafeZoneStoredData>().PasstoFinal();

            final.SetAPO();
            final.SetASP();
        }

       
    }

  
  
    }

