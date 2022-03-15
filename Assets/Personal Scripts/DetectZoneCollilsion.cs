using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectZoneCollilsion : MonoBehaviour
{
    public GameObject blinkerparent, blinker, blinkercenter, valuesparent;
    private Material blinkermat;
    private string Property = "_Color";
    private Color green = new Color32(6, 130, 0, 125);
    public FinalAxisValues final;
    public GlobalParameters global;
    public SafeZoneStoredData stored;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("ZoneCollision"))
        {
            blinkerparent = collision.gameObject.transform.root.gameObject;
            blinker = blinkerparent.gameObject.transform.Find("Center").gameObject;
            blinkercenter = blinker.gameObject.transform.Find("Blinker").gameObject;
            valuesparent = blinkerparent.gameObject.transform.Find("Stored_Data").gameObject;
            stored = valuesparent.GetComponent<SafeZoneStoredData>();

            final.zone_asp = stored.asp_on;
            final.zone_tsp = stored.tsp_on;
            final.zone_apo = stored.apo_on;
            final.zone_tpo = stored.tpo_on;
            final.zone_tor = stored.tor_on;

            final.apo_j1lower = stored.apo_j1lower;
            final.apo_j2lower = stored.apo_j2lower;
            final.apo_j3lower = stored.apo_j3lower;
            final.apo_j4lower = stored.apo_j4lower;
            final.apo_j5lower = stored.apo_j5lower;
            final.apo_j6lower = stored.apo_j6lower;

            final.apo_j1upper = stored.apo_j1upper;
            final.apo_j2upper = stored.apo_j2upper;
            final.apo_j3upper = stored.apo_j3upper;
            final.apo_j4upper = stored.apo_j4upper;
            final.apo_j5upper = stored.apo_j5upper;
            final.apo_j6upper = stored.apo_j6upper;

            final.asp_j1min = stored.asp_j1min;
            final.asp_j2min = stored.asp_j2min;
            final.asp_j3min = stored.asp_j3min;
            final.asp_j4min = stored.asp_j4min;
            final.asp_j5min = stored.asp_j5min;
            final.asp_j6min = stored.asp_j6min;

            final.asp_j1max = stored.asp_j1max;
            final.asp_j2max = stored.asp_j2max;
            final.asp_j3max = stored.asp_j3max;
            final.asp_j4max = stored.asp_j4max;
            final.asp_j5max = stored.asp_j5max;
            final.asp_j6max = stored.asp_j6max;

            final.SetASP();
            final.SetAPO();

            blinkercenter.GetComponent<ColorSwitcher>().enable = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("ZoneCollision"))
        {
            blinkerparent = collision.gameObject.transform.root.gameObject;
            blinker = blinkerparent.gameObject.transform.Find("Center").gameObject;
            blinkercenter = blinker.gameObject.transform.Find("Blinker").gameObject;
            blinkercenter.GetComponent<ColorSwitcher>().enable = false;
            blinkermat = blinkercenter.GetComponent<Renderer>().material;

            blinkermat.SetColor(Property, green);

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

            final.ExitZone();
            global.PasstoFinal();
            final.SetASP();
            final.SetAPO();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ZoneCollision"))
        {
            ContactPoint[] contacts = new ContactPoint[1];
            collision.GetContacts(contacts);

            var contactPoint = contacts[0].point;
            print(contactPoint);
        }
    }
}
