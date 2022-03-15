using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewVertice : MonoBehaviour
{
    public CreateSafeZone createscript;
    public GameObject parent, Coordinates_Container;
    public List<float> Coordinates_Container_x = new List<float>();
    public List<float> Coordinates_Container_z = new List<float>();

    private string convertedname;
    public float convertednum;

    public void FillAddC() {

    Coordinates_Container_x = new List<float>();
    Coordinates_Container_z = new List<float>();

        parent = transform.root.gameObject;

        Coordinates_Container = parent.transform.Find("Coordinates_Container").gameObject;

        convertedname = transform.name.Replace("AddC", "");
        convertednum = float.Parse(convertedname);

        foreach (Transform child in Coordinates_Container.transform)
        {

            if (child.CompareTag("Point"))
            {
                var childx = child.transform.position.x;
                var childz = child.transform.position.z;

                Coordinates_Container_x.Add(childx);
                Coordinates_Container_z.Add(childz);

                if(Coordinates_Container_x.Count == convertednum)
                {
                    Coordinates_Container_x.Add(transform.position.x);
                    Coordinates_Container_z.Add(transform.position.z);
                }
            }
        }

    }

    public void CreateZonewithAdd()
    {
        createscript.added = true;
        createscript.AddCZone = parent;
        createscript.Coordinates_Container_x = Coordinates_Container_x;
        createscript.Coordinates_Container_z = Coordinates_Container_z;
        createscript.CreateFromAddC();
    }

}
