using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using System.Linq;

public class GeneratePolygon : MonoBehaviour
{

    public List<int> TrianglesTop_Container = new List<int>();
    public List<Vector3> Coordinates_Container_Vectors = new List<Vector3>();
    public List<Vector3> TopCoordinates_Container_Vectors = new List<Vector3>();
    public List<Vector3> BotCoordinates_Container_Vectors = new List<Vector3>();

    private Vector3[] botvectors, midvectors, topvectors;
    private int[] triangles;

    public GameObject TopCoordinates_Container, Coordinates_Container, BotCoordinates_Container, Walls;
    public GameObject parent;
    public float storedvertices;

    private GameObject Top, Middle, Bottom;

    private int y;
    private float i;

    private Mesh mesh_top, mesh_mid, mesh_bot;
    private MeshCollider meshcollider_top, meshcollider_mid, meshcollider_bot;
    public float cx, cy, cz;
    public Vector3 polygonspos;
    public bool moving;

    public void StartPolygon()
    {
        parent = transform.root.gameObject;
        Walls = parent.transform.Find("Walls").gameObject;
        TopCoordinates_Container = parent.transform.Find("TopCoordinates_Container").gameObject;
        Coordinates_Container = parent.transform.Find("Coordinates_Container").gameObject;
        BotCoordinates_Container = parent.transform.Find("BotCoordinates_Container").gameObject;
        Top = transform.Find("Top").gameObject;
        Middle = transform.Find("Middle").gameObject;
        Bottom = transform.Find("Bottom").gameObject;

        mesh_top = Top.GetComponent<MeshFilter>().mesh;
        mesh_mid = Middle.GetComponent<MeshFilter>().mesh;
        mesh_bot = Bottom.GetComponent<MeshFilter>().mesh;

        meshcollider_top = Top.GetComponent<MeshCollider>();
        meshcollider_mid = Middle.GetComponent<MeshCollider>();
        meshcollider_bot = Bottom.GetComponent<MeshCollider>();

        FillTriangles();
    }


    public void FillTriangles()
    {
        TrianglesTop_Container = new List<int>();

        i = storedvertices - 2;
        y = 2;

        for (var x = 1; x <= i; x++)
        {
            TrianglesTop_Container.Add(0);
            TrianglesTop_Container.Add(x);
            TrianglesTop_Container.Add(y);
            y++;
        }

       // adjustmeshscript.FixMeshUpdate();
        FillTopPoints();
    }

    public void FillTopPoints()
    {
        TopCoordinates_Container_Vectors.Clear();
        Coordinates_Container_Vectors.Clear();
        BotCoordinates_Container_Vectors.Clear();
        topvectors = new Vector3[0];
        midvectors = new Vector3[0];
        botvectors = new Vector3[0];

        cx = parent.transform.position.x * (-1);
        cy = parent.transform.position.y * (-1);
        cz = parent.transform.position.z * (-1);
        polygonspos = new Vector3(cx, cy, cz);

        foreach (Transform child in TopCoordinates_Container.transform)
        {
            if (child.CompareTag("PointTop"))
            {
                var childtop = child.transform;
                var childpos = new Vector3(childtop.transform.position.x, childtop.transform.position.y, childtop.transform.position.z);
                TopCoordinates_Container_Vectors.Add(childpos);
            }
        }
        FillPoints();
    }

    public void FillPoints()
    {
        foreach (Transform child in Coordinates_Container.transform)
        {
            if (child.CompareTag("Point"))
            {
                var childmid = child.transform;
                var childpos = new Vector3(childmid.transform.position.x, childmid.transform.position.y, childmid.transform.position.z);
                Coordinates_Container_Vectors.Add(childpos);
            }
        }
        FillBotPoints();
    }

    public void FillBotPoints()
    {
        foreach (Transform child in BotCoordinates_Container.transform)
        {
            if (child.CompareTag("PointBot"))
            {
                var childbot = child.transform;
                var childpos = new Vector3(childbot.transform.position.x, childbot.transform.position.y, childbot.transform.position.z);
                BotCoordinates_Container_Vectors.Add(childpos);
            }
        }
        CreateAllPolygons();    
    }

    public void CreateAllPolygons() {

        topvectors = TopCoordinates_Container_Vectors.ToArray();
        midvectors = Coordinates_Container_Vectors.ToArray();
        botvectors = BotCoordinates_Container_Vectors.ToArray();
        triangles = TrianglesTop_Container.ToArray();

        mesh_top.vertices = topvectors;
        mesh_top.triangles = triangles;
        meshcollider_top.sharedMesh = mesh_top;

        mesh_mid.vertices = midvectors;
        mesh_mid.triangles = triangles;
        meshcollider_mid.sharedMesh = mesh_mid;

        mesh_bot.vertices = botvectors;
        mesh_bot.triangles = triangles;
        meshcollider_bot.sharedMesh = mesh_bot;

        AdjustPolygonsPOS();
    }

    public void AdjustPolygonsPOS()
    {
        transform.localPosition = polygonspos;
        Walls.GetComponent<CreateZoneMesh>().CreateMesh();
    }


    public void Moving()
    {
        moving = true;
    }

    public void Stopped()
    {
        moving = false;
    }

    void Update()
    {
        if (moving)
        {
            FillTopPoints();
        }
    }
}


