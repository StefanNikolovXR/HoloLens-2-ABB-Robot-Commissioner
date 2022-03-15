using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMesh : MonoBehaviour
{
    public GameObject parent, Polygons, Walls;
    public GeneratePolygon generatepolygon;
    public bool moving;
    public Component[] wallscripts;

    public void FixMeshUpdate()
    {
        parent = transform.root.gameObject;
        Polygons = parent.transform.Find("Polygons").gameObject;
        wallscripts = Walls.GetComponentsInChildren<ModifySafetyZoneQuads>();
    }

    void Update()
    {
        if (moving) {
            generatepolygon.moving = true;
            Walls.GetComponent<ZeroWallPositions>().Moving();
        }
    }

    public void StopChange()
    {
        Walls.GetComponent<ZeroWallPositions>().Stopped();
        generatepolygon.moving = false;
    }
}
