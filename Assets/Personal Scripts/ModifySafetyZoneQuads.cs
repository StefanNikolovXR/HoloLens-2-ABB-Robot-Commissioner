using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ModifySafetyZoneQuads : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public GameObject C1, C2, C3, C4, Wall;

    private float x_C1, y_C1, z_C1, x_C2, y_C2, z_C2, x_C3, y_C3, z_C3, x_C4, y_C4, z_C4;
    private Vector3 UpdatedPosition;
    public bool moving = false;

    void Start()
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

        vertices = new Vector3[] { new Vector3(x_C1, y_C1, z_C1), new Vector3(x_C2, y_C2, z_C2), new Vector3(x_C3, y_C3, z_C3), new Vector3(x_C4, y_C4, z_C4) };
        triangles = new int[] { 0, 1, 2, 2, 1, 3 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

    }

    void Update()
    {
        if (moving) { 
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

        vertices = new Vector3[] { new Vector3(x_C1, y_C1, z_C1), new Vector3(x_C2, y_C2, z_C2), new Vector3(x_C3, y_C3, z_C3), new Vector3(x_C4, y_C4, z_C4) };
            triangles = new int[] { 0, 1, 2, 2, 1, 3 };

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }

    }

    public void CleanMeshData()
    {
        mesh.Clear();
    }

}

