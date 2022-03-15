using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonCentroid : MonoBehaviour
{

    public GameObject Coordinates_Container, BOT_Handle, TOP_Handle;

    public float centeredx = 0, centeredz = 0, childx, childz;

    public bool centered;

    public List<float> Coordinates_Container_x = new List<float>();

    public Vector3 BotVector, TopVector;

    private float bot, top;

    public void SaveHeight()
    {
        bot = BOT_Handle.transform.localPosition.y;
        top = TOP_Handle.transform.localPosition.y;
    }

    public void Center()
    {
        centeredx = 0;
        centeredz = 0;
        Coordinates_Container_x = new List<float>();

        foreach (Transform child in Coordinates_Container.transform)
        {
            if (child.CompareTag("Point"))
            {
                childx = child.transform.localPosition.x;
                childz = child.transform.localPosition.z;

                Coordinates_Container_x.Add(childx);
                centeredx += childx;
                centeredz += childz;
            }
        }
    }

    void Update()
    {
        if (centered)
        {
            Center();
            BotVector = new Vector3(centeredx / Coordinates_Container_x.Count, bot, centeredz / Coordinates_Container_x.Count);
            TopVector = new Vector3(centeredx / Coordinates_Container_x.Count, top, centeredz / Coordinates_Container_x.Count);

            BOT_Handle.transform.localPosition = BotVector;
            TOP_Handle.transform.localPosition = TopVector;
        }
    }
}
