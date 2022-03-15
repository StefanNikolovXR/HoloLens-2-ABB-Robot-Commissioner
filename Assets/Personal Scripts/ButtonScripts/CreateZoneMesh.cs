using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZoneMesh : MonoBehaviour
{
    public GameObject Top, Middle;
    public GameObject Walls, Polygons;
    public MeshCombiner meshcombiner;
    public MeshCollider zonecollider;
    public MeshFilter zonemesh;

    public void CreateMesh()
    {
        Top.transform.parent = Walls.transform;
        Middle.transform.parent = Walls.transform;
        meshcombiner.CombineMeshes(true);
        zonecollider.sharedMesh = zonemesh.mesh;
        ReturnPolygons();
    }

    public void ReturnPolygons()
    {
        Top.transform.parent = Polygons.transform;
        Middle.transform.parent = Polygons.transform;
    }
}
