using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachParentVertexRuntime : MonoBehaviour
{
    public GameObject CTop, CMiddle, CBot;
    public bool moving;
    public GameObject parent, wallparent, polygonparent, centered;
    private Component[] wallscripts;
    private ModifySafetyZoneQuads script;
    public GeneratePolygon generate;
    private PolygonCentroid centeredscript;

    public void FillVertex()
    {
        parent = transform.root.gameObject;
        wallparent = parent.transform.Find("Walls").gameObject;
        polygonparent = parent.transform.Find("Polygons").gameObject;
        wallscripts = wallparent.GetComponentsInChildren<ModifySafetyZoneQuads>();
        generate = polygonparent.GetComponent<GeneratePolygon>();
        centered = parent.transform.Find("Center").gameObject;
        centeredscript = centered.GetComponent<PolygonCentroid>();
    }

    void Update()
    {
        if (moving)
        {
            CTop.transform.position = new Vector3(transform.position.x, CTop.transform.position.y, transform.position.z);
            CMiddle.transform.position = new Vector3(transform.position.x, CMiddle.transform.position.y, transform.position.z);
            CBot.transform.position = new Vector3(transform.position.x, CBot.transform.position.y, transform.position.z);
        }
    }

    public void VertexHandleMoving()
    {
        moving = true;
        generate.moving = true;
        wallparent.GetComponent<ZeroWallPositions>().Moving();
        centeredscript.centered = true;
        centeredscript.SaveHeight();
    }


    public void VertexHandleStopped()
    {
        moving = false;
        generate.moving = false;
        wallparent.GetComponent<ZeroWallPositions>().Stopped();
        centeredscript.centered = false;
        wallparent.GetComponent<CreateZoneMesh>().CreateMesh();
    }

}
