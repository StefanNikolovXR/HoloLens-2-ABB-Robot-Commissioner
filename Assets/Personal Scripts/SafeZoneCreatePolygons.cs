using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SafeZoneCreatePolygons : MonoBehaviour
{
    public GameObject Top, Middle, Bot;
    public GameObject TopParent, MiddleParent, BotParent;
    private Mesh mesh_top, mesh_mid, mesh_bot;
    public Transform[] TopCoordinates_Container, Coordinates_Container, BotCoordinates_Container;

    private List<Vector3> TopCoordinates_Container_Vectors = new List<Vector3>();
    private List<Vector3> Coordinates_Container_Vectors = new List<Vector3>();
    private List<Vector3> BotCoordinates_Container_Vectors = new List<Vector3>();
    private List<int> TrianglesTop_Container = new List<int>();

    private GameObject Walls, Vertices, AddC_Container;

    private MeshCollider meshcollider_top, meshcollider_mid;

    private bool moving = false, verticalmove = false;
    private float result;
    private Vector3[] vertices_top, vertices_mid, vertices_bot;
    private int[] triangles_top, triangles_mid, triangles_bot;
    private int i, j, k, x=0, y=1;

    void Start()
    {
        mesh_top = Top.GetComponent<MeshFilter>().mesh;
        mesh_mid = Middle.GetComponent<MeshFilter>().mesh;
        mesh_bot = Bot.GetComponent<MeshFilter>().mesh;
    }

    public void fillArray()
    {


        //TrianglesTop_Container.Add()

        for (i = 0; i < 18; i += 3)
        {
            triangles_top[i] = 0;
            triangles_mid[i] = 0;
            triangles_bot[i] = 0;
        }

        for (j = 1; j < 19; j += 3)
        {
            x++;
            triangles_top[j] = x;
        }

        for (k = 2; k < 20; k += 3)
        {
            y++;
            triangles_top[k] = y;
        }
    }

    public void CreatePolygons()
    {

        TopCoordinates_Container = TopParent.GetComponentsInChildren<Transform>();
        Coordinates_Container = MiddleParent.GetComponentsInChildren<Transform>();
        BotCoordinates_Container = BotParent.GetComponentsInChildren<Transform>();

        foreach (Transform child in TopCoordinates_Container)
        {
            TopCoordinates_Container_Vectors.Add(new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, child.transform.localPosition.z));
        }

        foreach (Transform child in Coordinates_Container)
        {
            Coordinates_Container_Vectors.Add(new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, child.transform.localPosition.z));
        }

        foreach (Transform child in BotCoordinates_Container)
        {
            BotCoordinates_Container_Vectors.Add(new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, child.transform.localPosition.z));
        }

        vertices_top = Coordinates_Container_Vectors.ToArray();


        for (i=0; i < 18; i += 3){ 
            triangles_top[i] = 0;
            triangles_mid[i] = 0;
            triangles_bot[i] = 0;
        }

        for (j = 1; j < 19; j += 3){ 
        x++;
        triangles_top[j] = x;
        }

        for (k = 2; k < 20; k += 3){
            y++;
            triangles_top[k] = y;
        }

        mesh_top.vertices = vertices_top;
        mesh_top.triangles = triangles_top;
        meshcollider_top.sharedMesh = mesh_top;

    }

    public void VerticalisModified()
    {
        verticalmove = true;
    }

    public void VerticalisStatic()
    {
        verticalmove = false;
    }

    public void ZoneisModified()
    {
        moving = true;
    }

    public void ZoneisStatic()
    {
        moving = false;
        meshcollider_top.sharedMesh = mesh_top;
    }

    private IEnumerator TimerUpdate()
    {
        moving = true;

        yield return new WaitForSeconds(1);

        moving = false;
    }

    public void ZoneisExpanded()
    {
        StartCoroutine(TimerUpdate());
    }

    public void CleanMeshData()
    {
        mesh_top.Clear();
    }

}

