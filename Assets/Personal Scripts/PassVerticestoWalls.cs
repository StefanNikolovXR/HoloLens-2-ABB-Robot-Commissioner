using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassVerticestoWalls : MonoBehaviour
{
    private GameObject parent, Polygons, Walls;

    public void FixVertices()
    {
        parent = transform.root.gameObject;
        Polygons = parent.transform.Find("Polygons").gameObject;
        Walls = parent.transform.Find("Walls").gameObject;
    }

    public void PasstoWalls()
    {
        Walls.GetComponent<ZeroWallPositions>().Moving();
    }

    public void StopWalls()
    {
        Walls.GetComponent<ZeroWallPositions>().Stopped();
    }
}
