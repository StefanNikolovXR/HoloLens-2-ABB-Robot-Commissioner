using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CreateFiveSidePolly : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public GameObject ZoneCenter, Coordinate1, Coordinate2, Coordinate3, Coordinate4, Coordinate5;

    public float x_Coordinate1, y_Coordinate1, z_Coordinate1;
    public float x_Coordinate2, y_Coordinate2, z_Coordinate2;
    public float x_Coordinate3, y_Coordinate3, z_Coordinate3;
    public float x_Coordinate4, y_Coordinate4, z_Coordinate4;
    public float x_Coordinate5, y_Coordinate5, z_Coordinate5;
    private float zonex, zoney, zonez;
    private bool moving = false;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;

        x_Coordinate1 = Coordinate1.transform.localPosition.x;
        y_Coordinate1 = Coordinate1.transform.localPosition.y;
        z_Coordinate1 = Coordinate1.transform.localPosition.z;

        x_Coordinate2 = Coordinate2.transform.localPosition.x;
        y_Coordinate2 = Coordinate2.transform.localPosition.y;
        z_Coordinate2 = Coordinate2.transform.localPosition.z;

        x_Coordinate3 = Coordinate3.transform.localPosition.x;
        y_Coordinate3 = Coordinate3.transform.localPosition.y;
        z_Coordinate3 = Coordinate3.transform.localPosition.z;

        x_Coordinate4 = Coordinate4.transform.localPosition.x;
        y_Coordinate4 = Coordinate4.transform.localPosition.y;
        z_Coordinate4 = Coordinate4.transform.localPosition.z;

        x_Coordinate5 = Coordinate5.transform.localPosition.x;
        y_Coordinate5 = Coordinate5.transform.localPosition.y;
        z_Coordinate5 = Coordinate5.transform.localPosition.z;

        vertices = new Vector3[] { new Vector3(x_Coordinate1, y_Coordinate1, z_Coordinate1), new Vector3(x_Coordinate2, y_Coordinate2, z_Coordinate2), new Vector3(x_Coordinate3, y_Coordinate3, z_Coordinate3), new Vector3(x_Coordinate4, y_Coordinate4, z_Coordinate4), new Vector3(x_Coordinate5, y_Coordinate5, z_Coordinate5) };
        triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    public void ZoneisModified()
    {
        moving = true;
    }

    public void ZoneisStatic()
    {
        moving = false;
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
        if (ZoneCenter.active && moving == true)
        {
            mesh = GetComponent<MeshFilter>().mesh;

            x_Coordinate1 = Coordinate1.transform.position.x;
            y_Coordinate1 = Coordinate1.transform.position.y;
            z_Coordinate1 = Coordinate1.transform.position.z;

            x_Coordinate2 = Coordinate2.transform.position.x;
            y_Coordinate2 = Coordinate2.transform.position.y;
            z_Coordinate2 = Coordinate2.transform.position.z;

            x_Coordinate3 = Coordinate3.transform.position.x;
            y_Coordinate3 = Coordinate3.transform.position.y;
            z_Coordinate3 = Coordinate3.transform.position.z;

            x_Coordinate4 = Coordinate4.transform.position.x;
            y_Coordinate4 = Coordinate4.transform.position.y;
            z_Coordinate4 = Coordinate4.transform.position.z;

            x_Coordinate5 = Coordinate5.transform.position.x;
            y_Coordinate5 = Coordinate5.transform.position.y;
            z_Coordinate5 = Coordinate5.transform.position.z;

            zonex = ZoneCenter.transform.position.x;
            zoney = ZoneCenter.transform.position.y;
            zonez = ZoneCenter.transform.position.z;

            vertices = new Vector3[] { new Vector3(x_Coordinate1 - zonex, y_Coordinate1 - zoney, z_Coordinate1 - zonez), new Vector3(x_Coordinate2 - zonex, y_Coordinate2 - zoney, z_Coordinate2 - zonez), new Vector3(x_Coordinate3 - zonex, y_Coordinate3 - zoney, z_Coordinate3 - zonez), new Vector3(x_Coordinate4 - zonex, y_Coordinate4 - zoney, z_Coordinate4 - zonez), new Vector3(x_Coordinate5 - zonex, y_Coordinate5 - zoney, z_Coordinate5 - zonez) };
            triangles = new int[] { 0, 1, 2, 0, 2, 3, 0, 3, 4 };

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

