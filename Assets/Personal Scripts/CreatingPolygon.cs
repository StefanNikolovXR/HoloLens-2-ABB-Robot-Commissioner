using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingPolygon : MonoBehaviour
{
    public GameObject Coordinate_instanced;

    public string newedgename = "";

    public GameObject center;
    public GameObject polygonsphere;
    public GameObject ZONE_Center, Polygons, Walls, Vertices, AddC_Container, Center_Container, TopCoordinates_Container, Coordinates_Container, BotCoordinates_Container;
    private float angle, x, y;
    public float radius;
    private int n;
    private float step;
    public int numberofedges;
    public Vector3 edgecoordinates;
    private MeasureLine botline, topline;

    void Start()
    {
        ZONE_Center = center.transform.Find("ZONE_Center").gameObject;
        Polygons = center.transform.Find("Polygons").gameObject;
        Walls = center.transform.Find("Walls").gameObject;
        Vertices = center.transform.Find("Vertices").gameObject;
        AddC_Container = center.transform.Find("AddC_Container").gameObject;
        Center_Container = center.transform.Find("Center_Container").gameObject;
        TopCoordinates_Container = center.transform.Find("TopCoordinates_Container").gameObject;
        Coordinates_Container = center.transform.Find("Coordinates_Container").gameObject;
        BotCoordinates_Container = center.transform.Find("BotCoordinates_Container").gameObject;
    }

    public void CreateZone()
    {
        angle = 360 / numberofedges * (Mathf.PI * 2) / 360;
        step = angle;

        for (n = 1; n <= numberofedges; n++)
        {
            x = x + Mathf.Cos(angle);
            y = y + Mathf.Sin(angle);
            angle += step;

            edgecoordinates = new Vector3(x, 0, y);

            var newedge = Instantiate(Coordinate_instanced, edgecoordinates, Quaternion.identity);
            newedgename = "C" + n;
            newedge.name = (newedgename);
            newedge.transform.parent = Coordinates_Container.transform;

            //  CTop.transform.parent = CTopContainer.transform;

            // gameobject.transform.Find("ChildName")
        }


}

}
