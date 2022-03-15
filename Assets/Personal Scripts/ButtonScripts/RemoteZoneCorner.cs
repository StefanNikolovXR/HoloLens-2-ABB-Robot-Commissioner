using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteZoneCorner : MonoBehaviour
{
    public CreateSafeZone createscript;
    public GameObject parent, Coordinates_Container;
    public List<float> Coordinates_Container_x = new List<float>();
    public List<float> Coordinates_Container_z = new List<float>();

    public string convertedname;
    public int convertednum;

    public void FillCoordinate()
    {
        Coordinates_Container_x = new List<float>();
        Coordinates_Container_z = new List<float>();

        parent = transform.root.gameObject;

        Coordinates_Container = parent.transform.Find("Coordinates_Container").gameObject;

        convertedname = transform.name.Replace("C", "");
        convertednum = int.Parse(convertedname);

        foreach (Transform child in Coordinates_Container.transform)
        {
            if (child.CompareTag("Point"))
            {
                var childx = child.transform.position.x;
                var childz = child.transform.position.z;
                Coordinates_Container_x.Add(childx);
                Coordinates_Container_z.Add(childz);
            }
        }
        Coordinates_Container_x.RemoveAt(convertednum - 1);
        Coordinates_Container_z.RemoveAt(convertednum - 1);
    }

    public void FillCoordinateTop()
    {

        Coordinates_Container_x = new List<float>();
        Coordinates_Container_z = new List<float>();

        parent = transform.root.gameObject;

        Coordinates_Container = parent.transform.Find("Coordinates_Container").gameObject;

        convertedname = transform.name.Replace("C", "");
        convertednum = int.Parse(convertedname);

        foreach (Transform child in Coordinates_Container.transform)
        {

            if (child.CompareTag("Point"))
            {
                var childx = child.transform.position.x;
                var childz = child.transform.position.z;
                Coordinates_Container_x.Add(childx);
                Coordinates_Container_z.Add(childz);
            }
        }

        Coordinates_Container_x.RemoveAt(convertednum - 1);
        Coordinates_Container_z.RemoveAt(convertednum - 1);
    }

    public void RemoveCorner()
    {
        createscript.added = false;
        createscript.AddCZone = parent;
        createscript.Coordinates_Container_x = Coordinates_Container_x;
        createscript.Coordinates_Container_z = Coordinates_Container_z;
        createscript.CreateFromRemoveC();
    }

}
