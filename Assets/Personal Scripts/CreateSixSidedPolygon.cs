using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CreateSixSidedPolygon : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    public Transform[] Coordinates_Container;

    public List<Vector3> Coordinates_Container_Vectors = new List<Vector3>();

    public GameObject Walls, Vertices, AddC_Container, TopCoordinates_Container, BotCoordinates_Container;

    public MeshCollider meshcollider;
    public GameObject botC, topC;
    public GameObject ZoneC, C1, C2, C3, C4, C5, C6, C1_Other, C2_Other, C3_Other, C4_Other, C5_Other, C6_Other;
    public GameObject AddC1, AddC2, AddC3, AddC4, AddC5, AddC6;
    public GameObject V1, V2, V3, V4, V5, V6;
    private float botcentery, topcentery, zoneheight;
    private float x_C1, y_C1, z_C1;
    private float x_C2, y_C2, z_C2;
    private float x_C3, y_C3, z_C3;
    private float x_C4, y_C4, z_C4;
    private float x_C5, y_C5, z_C5;
    private float x_C6, y_C6, z_C6;
    private float zonex, zoney, zonez;
    private bool moving = false, verticalmove = false;
    private float result;
    private Vector3 CVector, VVector, x1Vector;


    void CreateZone()
    {
        Coordinates_Container = GetComponentsInChildren<Transform>();

        foreach (Transform child in Coordinates_Container) {

            Coordinates_Container_Vectors.Add(new Vector3(child.transform.localPosition.x, child.transform.localPosition.y, child.transform.localPosition.z));
        }

            //Coordinates_Container_Vectors.Add

        }

    void Awake()
    {

        botcentery = botC.transform.localPosition.y;
        topcentery = topC.transform.localPosition.y;
        zoneheight = topcentery - botcentery;

        mesh = GetComponent<MeshFilter>().mesh;

      //  x1Vector = new Vector3(Coordinates[0].transform.localPosition.x, Coordinates[0].transform.localPosition.y, Coordinates[0].transform.localPosition.z);

        x_C1 = C1.transform.localPosition.x;
        y_C1 = C1.transform.localPosition.y;
        z_C1 = C1.transform.localPosition.z;

        x_C2 = C2.transform.localPosition.x;
        y_C2 = C2.transform.localPosition.y;
        z_C2 = C2.transform.localPosition.z;

        x_C3 = C3.transform.localPosition.x;
        y_C3 = C3.transform.localPosition.y;
        z_C3 = C3.transform.localPosition.z;

        x_C4 = C4.transform.localPosition.x;
        y_C4 = C4.transform.localPosition.y;
        z_C4 = C4.transform.localPosition.z;

        x_C5 = C5.transform.localPosition.x;
        y_C5 = C5.transform.localPosition.y;
        z_C5 = C5.transform.localPosition.z;

        x_C6 = C6.transform.localPosition.x;
        y_C6 = C6.transform.localPosition.y;
        z_C6 = C6.transform.localPosition.z;

        vertices = new Vector3[] { new Vector3(x_C1, y_C1, z_C1), new Vector3(x_C2, y_C2, z_C2), new Vector3(x_C3, y_C3, z_C3), new Vector3(x_C4, y_C4, z_C4), new Vector3(x_C5, y_C5, z_C5), new Vector3(x_C6, y_C6, z_C6) };
        
        triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        meshcollider.sharedMesh = mesh;
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
        meshcollider.sharedMesh = mesh;
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

    void Update()
    {
        if (ZoneC.active && moving == true)
        {
            mesh = GetComponent<MeshFilter>().mesh;

            x_C1 = C1.transform.position.x;
            y_C1 = C1.transform.position.y;
            z_C1 = C1.transform.position.z;

            x_C2 = C2.transform.position.x;
            y_C2 = C2.transform.position.y;
            z_C2 = C2.transform.position.z;

            x_C3 = C3.transform.position.x;
            y_C3 = C3.transform.position.y;
            z_C3 = C3.transform.position.z;

            x_C4 = C4.transform.position.x;
            y_C4 = C4.transform.position.y;
            z_C4 = C4.transform.position.z;

            x_C5 = C5.transform.position.x;
            y_C5 = C5.transform.position.y;
            z_C5 = C5.transform.position.z;

            x_C6 = C6.transform.position.x;
            y_C6 = C6.transform.position.y;
            z_C6 = C6.transform.position.z;

            zonex = ZoneC.transform.position.x;
            zoney = ZoneC.transform.position.y;
            zonez = ZoneC.transform.position.z;

            vertices = new Vector3[] { new Vector3(x_C1 - zonex, y_C1 - zoney, z_C1 - zonez), new Vector3(x_C2 - zonex, y_C2 - zoney, z_C2 - zonez), new Vector3(x_C3 - zonex, y_C3 - zoney, z_C3 - zonez), new Vector3(x_C4 - zonex, y_C4 - zoney, z_C4 - zonez), new Vector3(x_C5 - zonex, y_C5 - zoney, z_C5 - zonez), new Vector3(x_C6 - zonex, y_C6 - zoney, z_C6 - zonez) };
            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5 };

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            meshcollider.sharedMesh = mesh;

            if (moving) { 

            for (int p = 0; p < triangles.Length; p += 3)
            {
                result += (Vector3.Cross(vertices[triangles[p + 1]] - vertices[triangles[p]],
                            vertices[triangles[p + 2]] - vertices[triangles[p]])).magnitude;
            }
            result *= 0.4f;

                if(result<1 && result>0.5) { 

                CVector = new Vector3(result, result, result);

                C1.transform.localScale = CVector;
                C2.transform.localScale = CVector;
                C3.transform.localScale = CVector;
                C4.transform.localScale = CVector;
                C5.transform.localScale = CVector;
                C6.transform.localScale = CVector;
                C1_Other.transform.localScale = CVector;
                C2_Other.transform.localScale = CVector;
                C3_Other.transform.localScale = CVector;
                C4_Other.transform.localScale = CVector;
                C5_Other.transform.localScale = CVector;
                C6_Other.transform.localScale = CVector;

                AddC1.transform.localScale = CVector;
                AddC2.transform.localScale = CVector;
                AddC3.transform.localScale = CVector;
                AddC4.transform.localScale = CVector;
                AddC5.transform.localScale = CVector;
                AddC6.transform.localScale = CVector;
                
            if (verticalmove)
                {
                        zoneheight = topcentery - botcentery;
                        VVector = new Vector3(zoneheight, zoneheight, zoneheight);

                        if (zoneheight<0.5) { }

                }

                }
            }
        }
    }

    public void CleanMeshData()
    {
        mesh.Clear();
    }

}

