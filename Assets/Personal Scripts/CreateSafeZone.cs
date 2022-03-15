using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

public class CreateSafeZone : MonoBehaviour
{
    public GameObject zone, Coordinate_instanced, CoordinateTop_instanced, ShadowCoordinate_instanced, AddCoordinate_instanced, Vertice_instanced, Wall_instanced;
    private GameObject newzone;
    private GameObject BOT_Handle, TOP_Handle, Center, Walls, Polygons, Vertices, AddC_Container, TopCoordinates_Container, Coordinates_Container, BotCoordinates_Container;
    private float angle, x, y, floor = -1.8f;
    public float radius = 0.25f, height = 0.5f;
    public bool createzonemode = false;
    private int n = 0;
    private float step;
    public float numberofedges;
    public Vector3 botcoordinatespos, topcoordinatespos, shadowcoordinatespos, zonepos;
    public string newedgebotname = "", newedgetopname = "", newedgeshadowname = "", newvertcoordinatename = "", newwallname = "", newaddCname = "";
    private MeasureLine botline, topline, shadowline, botlinevert, firstlinetop, firstline, firstlinebot, firstlinevert;
    private float zonex, zonez;
    private bool activeSelf;
    private GeneratePolygon generatescript;
    public GameObject AddCZone;
    public List<float> Coordinates_Container_x, Coordinates_Container_z;
    private GameObject BOT_Handle_stored, TOP_Handle_stored;
    private float BOT_y, TOP_y;
    public bool added, removed;

    private Component[] vertexscripts, addcscripts, removecornersbot, removecornerstop;

    public void CreateFromGestures()
    {

        foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        {

            if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
            {
                foreach (var p in source.Pointers)
                {
                    if (p is IMixedRealityNearPointer)
                    {

                        continue;
                    }
                    if (p.Result != null)
                    {
                        var startPoint = p.Position;

                        newzone = Instantiate(zone, zonepos, Quaternion.identity);

                        newzone.transform.position = startPoint;

                        Center = newzone.transform.Find("Center").gameObject;
                        Polygons = newzone.transform.Find("Polygons").gameObject;
                        Walls = newzone.transform.Find("Walls").gameObject;
                        Vertices = newzone.transform.Find("Vertices").gameObject;
                        AddC_Container = newzone.transform.Find("AddC_Container").gameObject;
                        TopCoordinates_Container = newzone.transform.Find("TopCoordinates_Container").gameObject;
                        Coordinates_Container = newzone.transform.Find("Coordinates_Container").gameObject;
                        BotCoordinates_Container = newzone.transform.Find("BotCoordinates_Container").gameObject;
                        Polygons = newzone.transform.Find("Polygons").gameObject;

                        BOT_Handle = newzone.transform.Find("BOT_Handle").gameObject;
                        TOP_Handle = newzone.transform.Find("TOP_Handle").gameObject;
                        BOT_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();
                        TOP_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();

                        generatescript = Polygons.GetComponent<GeneratePolygon>();
                        generatescript.storedvertices = numberofedges;

                        //  Center.GetComponent<SolverHandler>().TransformOverride = BOT_Handle.transform;
                        // Center.GetComponent<InBetween>().SecondTransformOverride = TOP_Handle.transform;
                        BotCoordinates_Container.transform.localPosition = new Vector3(0, newzone.transform.position.y * (-1), 0);

                        BOT_Handle.GetComponent<MeshRenderer>().enabled = true;
                        BOT_Handle.GetComponent<BoxCollider>().enabled = true;
                        BOT_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

                        TOP_Handle.GetComponent<MeshRenderer>().enabled = true;
                        TOP_Handle.GetComponent<BoxCollider>().enabled = true;
                        TOP_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

                        Center.GetComponent<MeshRenderer>().enabled = true;
                        Center.GetComponent<SphereCollider>().enabled = true;
                        Center.transform.Find("Blinker").GetComponent<MeshRenderer>().enabled = true;

                        n = 1;

                        while (n <= numberofedges)
                        {

                            x = newzone.transform.position.x + radius * Mathf.Cos(2 * Mathf.PI * n / numberofedges);
                            y = newzone.transform.position.z + radius * Mathf.Sin(2 * Mathf.PI * n / numberofedges);

                            botcoordinatespos = new Vector3(x, newzone.transform.position.y - 0.5f * height, y);
                            topcoordinatespos = new Vector3(x, newzone.transform.position.y + 0.5f * height, y);
                            shadowcoordinatespos = new Vector3(x, floor, y);

                            var newedgebot = Instantiate(Coordinate_instanced, botcoordinatespos, Quaternion.identity);
                            var newedgetop = Instantiate(CoordinateTop_instanced, topcoordinatespos, Quaternion.identity);
                            var newedgeshadow = Instantiate(ShadowCoordinate_instanced, shadowcoordinatespos, Quaternion.identity);
                            var newvertcoordinate = Instantiate(Vertice_instanced, zonepos, Quaternion.identity);
                            var newwall = Instantiate(Wall_instanced, zonepos, Quaternion.identity);
                            var newaddcoordinate = Instantiate(AddCoordinate_instanced, zonepos, Quaternion.identity);

                            newedgebot.GetComponent<MeshRenderer>().enabled = true;
                            newedgebot.GetComponent<SphereCollider>().enabled = true;
                            newedgebot.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
                            newedgebot.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;
                            newedgebot.transform.Find("Line_Vertical").gameObject.GetComponent<MeshRenderer>().enabled = true;
                           
                            newedgetop.GetComponent<MeshRenderer>().enabled = true;
                            newedgetop.GetComponent<SphereCollider>().enabled = true;
                            newedgetop.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
                            newedgetop.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;
                            
                            newvertcoordinate.GetComponent<MeshRenderer>().enabled = true;
                            newvertcoordinate.GetComponent<BoxCollider>().enabled = true;
                            newvertcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

                            newwall.GetComponent<MeshRenderer>().enabled = true;
                            newedgeshadow.GetComponent<MeshRenderer>().enabled = true;

                            newaddcoordinate.GetComponent<MeshRenderer>().enabled = true;
                            newaddcoordinate.GetComponent<SphereCollider>().enabled = true;
                            newaddcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

                            newedgebotname = "C" + n;
                            newedgetopname = "C" + n;
                            newedgeshadowname = "C" + n + "Bot";
                            newvertcoordinatename = "VertC" + n;
                            newwallname = "W" + n;
                            newaddCname = "AddC" + n;

                            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CTop = newedgetop;
                            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CMiddle = newedgebot;
                            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CBot = newedgeshadow;

                            newedgebot.name = (newedgebotname);
                            newedgetop.name = (newedgetopname);
                            newedgeshadow.name = (newedgeshadowname);
                            newvertcoordinate.name = (newvertcoordinatename);
                            newwall.name = (newwallname);
                            newaddcoordinate.name = (newaddCname);

                            newedgebot.transform.parent = Coordinates_Container.transform;
                            newedgetop.transform.parent = TopCoordinates_Container.transform;
                            newedgeshadow.transform.parent = BotCoordinates_Container.transform;
                            newvertcoordinate.transform.parent = Vertices.transform;
                            newwall.transform.parent = Walls.transform;
                            newwall.transform.localPosition = new Vector3(0, 0, 0);
                            newaddcoordinate.transform.parent = AddC_Container.transform;

                            //newwall.GetComponent<ModifySafetyZoneQuads>().ZoneisModified();

                            // newedgebot.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;
                            // newedgetop.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;

                            newvertcoordinate.GetComponent<SolverHandler>().TransformOverride = newedgebot.transform;
                            newvertcoordinate.GetComponent<InBetween>().SecondTransformOverride = newedgetop.transform;
                            n++;
                        }
                    }

                }

            }
        }
        CreateZoneMesh();
    }



    public void CreateZoneMesh()
    {

        vertexscripts = Vertices.GetComponentsInChildren<AttachParentVertexRuntime>();
        addcscripts = AddC_Container.GetComponentsInChildren<CreateNewVertice>();
        removecornersbot = Coordinates_Container.GetComponentsInChildren<RemoteZoneCorner>();
        removecornerstop = TopCoordinates_Container.GetComponentsInChildren<RemoteZoneCorner>();

        foreach (RemoteZoneCorner removecornerbot in removecornersbot)
        {
            removecornerbot.FillCoordinate();
        }

        /*   foreach (RemoteZoneCorner removecornertop in removecornerstop)
          {
              removecornertop.FillCoordinate();
          }*/

        foreach (CreateNewVertice verticescript in addcscripts)
        {
            verticescript.FillAddC();
        }

        foreach (AttachParentVertexRuntime script in vertexscripts)
        {
            script.FillVertex();
        }

        for (var i = 1; i < numberofedges; i++)
        {

            var wall1name = "W" + i;
            var wall1 = Walls.transform.Find(wall1name);

            var c1name = "C" + i;
            var c1 = Coordinates_Container.transform.Find(c1name);

            var c1nametop = "C" + i;
            var c1top = TopCoordinates_Container.transform.Find(c1nametop);

            var csecondname = "C" + (i + 1);
            var csecond = Coordinates_Container.transform.Find(csecondname);

            var csecondnametop = "C" + (i + 1);
            var csecondtop = TopCoordinates_Container.transform.Find(csecondnametop);

            var Vnamecurr = "VertC" + i;
            var Vcurr = Vertices.transform.Find(Vnamecurr);

            var Vname = "VertC" + (i + 1);
            var V = Vertices.transform.Find(Vname);

            var sname = "C" + i + "Bot";
            var s = BotCoordinates_Container.transform.Find(sname);

            var ssecondname = "C" + (i + 1) + "Bot";
            var ssecond = BotCoordinates_Container.transform.Find(ssecondname);

            var sline = s.GetComponent<MeasureLine>();

            MeasureLine.AddTarget(sline, ssecond.transform);

            var Line = "Line";
            var lineparent = c1.transform.Find(Line);
            var linetopparent = c1top.transform.Find(Line);
            var lineH = lineparent.GetComponent<MeasureLine>();
            var lineHtop = linetopparent.GetComponent<MeasureLine>();

            var LineVert = "Line_Vertical";
            var lineVparent = c1.transform.Find(LineVert);
            var lineV = lineVparent.GetComponent<MeasureLine>();

            var AddCname = "AddC" + i;
            var AddC = AddC_Container.transform.Find(AddCname);

            MeasureLine.AddTarget(lineV, c1top.transform);
            MeasureLine.AddTarget(lineH, csecond.transform);
            MeasureLine.AddTarget(lineHtop, csecondtop.transform);

            wall1.GetComponent<ModifySafetyZoneQuads>().C1 = c1.gameObject;
            wall1.GetComponent<ModifySafetyZoneQuads>().C2 = c1top.gameObject;
            wall1.GetComponent<ModifySafetyZoneQuads>().C3 = csecond.gameObject;
            wall1.GetComponent<ModifySafetyZoneQuads>().C4 = csecondtop.gameObject;

            AddC.GetComponent<SolverHandler>().TransformOverride = Vcurr.transform;
            AddC.GetComponent<InBetween>().SecondTransformOverride = V.transform;


        }

        var lastwallname = "W" + numberofedges;
        var lasttwall = Walls.transform.Find(lastwallname);

        var clastname = "C" + numberofedges;
        var clast = Coordinates_Container.transform.Find(clastname);

        var clastnametop = "C" + numberofedges;
        var clasttop = TopCoordinates_Container.transform.Find(clastnametop);

        var cfirstname = "C" + 1;
        var cfirst = Coordinates_Container.transform.Find(cfirstname);

        var cfirstnametop = "C" + 1;
        var cfirsttop = TopCoordinates_Container.transform.Find(cfirstnametop);

        var Vlastname = "VertC" + numberofedges;
        var Vlast = Vertices.transform.Find(Vlastname);

        var Vfirstname = "VertC" + 1;
        var Vfirst = Vertices.transform.Find(Vfirstname);

        lasttwall.GetComponent<ModifySafetyZoneQuads>().C1 = clast.gameObject;
        lasttwall.GetComponent<ModifySafetyZoneQuads>().C2 = clasttop.gameObject;
        lasttwall.GetComponent<ModifySafetyZoneQuads>().C3 = cfirst.gameObject;
        lasttwall.GetComponent<ModifySafetyZoneQuads>().C4 = cfirsttop.gameObject;

        var Linename = "Line";
        var LineVname = "Line_Vertical";

        var AddCfinalname = "AddC" + numberofedges;
        var AddCfinal = AddC_Container.transform.Find(AddCfinalname);

        AddCfinal.GetComponent<SolverHandler>().TransformOverride = Vfirst.transform;
        AddCfinal.GetComponent<InBetween>().SecondTransformOverride = Vlast.transform;

        var lineHORparent = clast.transform.Find(Linename);
        var lineHORparenttop = clasttop.transform.Find(Linename);
        var lineVERparent = clast.transform.Find(LineVname);

        var lastline = lineHORparent.GetComponent<MeasureLine>();
        MeasureLine.AddTarget(lastline, cfirst.transform);

        var lastlinetop = lineHORparenttop.GetComponent<MeasureLine>();
        MeasureLine.AddTarget(lastlinetop, cfirsttop.transform);

        var lastlineV = lineVERparent.GetComponent<MeasureLine>();
        MeasureLine.AddTarget(lastlineV, clasttop.transform);

        var snamefirst = "C" + 1 + "Bot";
        var sfirst = BotCoordinates_Container.transform.Find(snamefirst);

        var slastname = "C" + numberofedges + "Bot";
        var slast = BotCoordinates_Container.transform.Find(slastname);

        var slinelast = slast.GetComponent<MeasureLine>();

        MeasureLine.AddTarget(slinelast, sfirst.transform);

        generatescript.StartPolygon();

        //newzone.transform.parent = SafeZoneContainer.transform;
    }

    public void CreateFromAddC()
    {

        var startPoint = AddCZone.transform.position;

        newzone = Instantiate(zone, zonepos, Quaternion.identity);

        newzone.transform.position = startPoint;

        Center = newzone.transform.Find("Center").gameObject;
        Polygons = newzone.transform.Find("Polygons").gameObject;
        Walls = newzone.transform.Find("Walls").gameObject;
        Vertices = newzone.transform.Find("Vertices").gameObject;
        AddC_Container = newzone.transform.Find("AddC_Container").gameObject;
        TopCoordinates_Container = newzone.transform.Find("TopCoordinates_Container").gameObject;
        Coordinates_Container = newzone.transform.Find("Coordinates_Container").gameObject;
        BotCoordinates_Container = newzone.transform.Find("BotCoordinates_Container").gameObject;
        Polygons = newzone.transform.Find("Polygons").gameObject;

        BOT_Handle = newzone.transform.Find("BOT_Handle").gameObject;
        TOP_Handle = newzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();
        TOP_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();

        generatescript = Polygons.GetComponent<GeneratePolygon>();
        generatescript.storedvertices = numberofedges;

        //  Center.GetComponent<SolverHandler>().TransformOverride = BOT_Handle.transform;
        // Center.GetComponent<InBetween>().SecondTransformOverride = TOP_Handle.transform;

        BOT_Handle_stored = AddCZone.transform.Find("BOT_Handle").gameObject;
        TOP_Handle_stored = AddCZone.transform.Find("TOP_Handle").gameObject;

        BOT_y = BOT_Handle_stored.transform.position.y;
        TOP_y = TOP_Handle_stored.transform.position.y;

        BOT_Handle.transform.position = BOT_Handle_stored.transform.position;
        TOP_Handle.transform.position = TOP_Handle_stored.transform.position;

        Destroy(AddCZone);

        numberofedges = numberofedges + 1;
        generatescript.storedvertices = numberofedges;

        BOT_Handle.GetComponent<MeshRenderer>().enabled = true;
        BOT_Handle.GetComponent<BoxCollider>().enabled = true;
        BOT_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

        TOP_Handle.GetComponent<MeshRenderer>().enabled = true;
        TOP_Handle.GetComponent<BoxCollider>().enabled = true;
        TOP_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

        Center.GetComponent<MeshRenderer>().enabled = true;
        Center.GetComponent<SphereCollider>().enabled = true;
        Center.transform.Find("Blinker").GetComponent<MeshRenderer>().enabled = true;

        BotCoordinates_Container.transform.localPosition = new Vector3(0, newzone.transform.position.y * (-1), 0);

        n = 1;

        while (n <= numberofedges)
        {
            botcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], BOT_y, Coordinates_Container_z[n - 1]);
            topcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], TOP_y, Coordinates_Container_z[n - 1]);
            shadowcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], floor, Coordinates_Container_z[n - 1]);

            var newedgebot = Instantiate(Coordinate_instanced, botcoordinatespos, Quaternion.identity);
            var newedgetop = Instantiate(CoordinateTop_instanced, topcoordinatespos, Quaternion.identity);
            var newedgeshadow = Instantiate(ShadowCoordinate_instanced, shadowcoordinatespos, Quaternion.identity);
            var newvertcoordinate = Instantiate(Vertice_instanced, zonepos, Quaternion.identity);
            var newwall = Instantiate(Wall_instanced, zonepos, Quaternion.identity);
            var newaddcoordinate = Instantiate(AddCoordinate_instanced, zonepos, Quaternion.identity);

            newedgebot.GetComponent<MeshRenderer>().enabled = true;
            newedgebot.GetComponent<SphereCollider>().enabled = true;
            newedgebot.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            newedgebot.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;
            newedgebot.transform.Find("Line_Vertical").gameObject.GetComponent<MeshRenderer>().enabled = true;

            newedgetop.GetComponent<MeshRenderer>().enabled = true;
            newedgetop.GetComponent<SphereCollider>().enabled = true;
            newedgetop.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            newedgetop.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;

            newvertcoordinate.GetComponent<MeshRenderer>().enabled = true;
            newvertcoordinate.GetComponent<BoxCollider>().enabled = true;
            newvertcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

            newwall.GetComponent<MeshRenderer>().enabled = true;
            newedgeshadow.GetComponent<MeshRenderer>().enabled = true;

            newaddcoordinate.GetComponent<MeshRenderer>().enabled = true;
            newaddcoordinate.GetComponent<SphereCollider>().enabled = true;
            newaddcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

            newedgebotname = "C" + n;
            newedgetopname = "C" + n;
            newedgeshadowname = "C" + n + "Bot";
            newvertcoordinatename = "VertC" + n;
            newwallname = "W" + n;
            newaddCname = "AddC" + n;

            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CTop = newedgetop;
            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CMiddle = newedgebot;
            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CBot = newedgeshadow;

            newedgebot.name = (newedgebotname);
            newedgetop.name = (newedgetopname);
            newedgeshadow.name = (newedgeshadowname);
            newvertcoordinate.name = (newvertcoordinatename);
            newwall.name = (newwallname);
            newaddcoordinate.name = (newaddCname);

            newedgebot.transform.parent = Coordinates_Container.transform;
            newedgetop.transform.parent = TopCoordinates_Container.transform;
            newedgeshadow.transform.parent = BotCoordinates_Container.transform;
            newvertcoordinate.transform.parent = Vertices.transform;
            newwall.transform.parent = Walls.transform;
            newwall.transform.localPosition = new Vector3(0, 0, 0);
            newaddcoordinate.transform.parent = AddC_Container.transform;

            //newwall.GetComponent<ModifySafetyZoneQuads>().ZoneisModified();

            // newedgebot.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;
            // newedgetop.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;

            newvertcoordinate.GetComponent<SolverHandler>().TransformOverride = newedgebot.transform;
            newvertcoordinate.GetComponent<InBetween>().SecondTransformOverride = newedgetop.transform;
            n++;
        }

        CreateZoneMesh();
    }

    public void CreateFromRemoveC()
    {

        var startPoint = AddCZone.transform.position;

        newzone = Instantiate(zone, zonepos, Quaternion.identity);

        newzone.transform.position = startPoint;

        Center = newzone.transform.Find("Center").gameObject;
        Polygons = newzone.transform.Find("Polygons").gameObject;
        Walls = newzone.transform.Find("Walls").gameObject;
        Vertices = newzone.transform.Find("Vertices").gameObject;
        AddC_Container = newzone.transform.Find("AddC_Container").gameObject;
        TopCoordinates_Container = newzone.transform.Find("TopCoordinates_Container").gameObject;
        Coordinates_Container = newzone.transform.Find("Coordinates_Container").gameObject;
        BotCoordinates_Container = newzone.transform.Find("BotCoordinates_Container").gameObject;
        Polygons = newzone.transform.Find("Polygons").gameObject;

        BOT_Handle = newzone.transform.Find("BOT_Handle").gameObject;
        TOP_Handle = newzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();
        TOP_Handle.GetComponent<AttachPolygontoHandle>().FillHandles();

        generatescript = Polygons.GetComponent<GeneratePolygon>();
        generatescript.storedvertices = numberofedges;

        //  Center.GetComponent<SolverHandler>().TransformOverride = BOT_Handle.transform;
        // Center.GetComponent<InBetween>().SecondTransformOverride = TOP_Handle.transform;

        BOT_Handle_stored = AddCZone.transform.Find("BOT_Handle").gameObject;
        TOP_Handle_stored = AddCZone.transform.Find("TOP_Handle").gameObject;

        BOT_y = BOT_Handle_stored.transform.position.y;
        TOP_y = TOP_Handle_stored.transform.position.y;

        BOT_Handle.transform.position = BOT_Handle_stored.transform.position;
        TOP_Handle.transform.position = TOP_Handle_stored.transform.position;

        Destroy(AddCZone);

        numberofedges = numberofedges - 1;
        generatescript.storedvertices = numberofedges;

        BOT_Handle.GetComponent<MeshRenderer>().enabled = true;
        BOT_Handle.GetComponent<BoxCollider>().enabled = true;
        BOT_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

        TOP_Handle.GetComponent<MeshRenderer>().enabled = true;
        TOP_Handle.GetComponent<BoxCollider>().enabled = true;
        TOP_Handle.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

        Center.GetComponent<MeshRenderer>().enabled = true;
        Center.GetComponent<SphereCollider>().enabled = true;
        Center.transform.Find("Blinker").GetComponent<MeshRenderer>().enabled = true;

        BotCoordinates_Container.transform.localPosition = new Vector3(0, newzone.transform.position.y * (-1), 0);

        n = 1;

        while (n <= numberofedges)
        {
            botcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], BOT_y, Coordinates_Container_z[n - 1]);
            topcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], TOP_y, Coordinates_Container_z[n - 1]);
            shadowcoordinatespos = new Vector3(Coordinates_Container_x[n - 1], floor, Coordinates_Container_z[n - 1]);

            var newedgebot = Instantiate(Coordinate_instanced, botcoordinatespos, Quaternion.identity);
            var newedgetop = Instantiate(CoordinateTop_instanced, topcoordinatespos, Quaternion.identity);
            var newedgeshadow = Instantiate(ShadowCoordinate_instanced, shadowcoordinatespos, Quaternion.identity);
            var newvertcoordinate = Instantiate(Vertice_instanced, zonepos, Quaternion.identity);
            var newwall = Instantiate(Wall_instanced, zonepos, Quaternion.identity);
            var newaddcoordinate = Instantiate(AddCoordinate_instanced, zonepos, Quaternion.identity);

            newedgebot.GetComponent<MeshRenderer>().enabled = true;
            newedgebot.GetComponent<SphereCollider>().enabled = true;
            newedgebot.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            newedgebot.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;
            newedgebot.transform.Find("Line_Vertical").gameObject.GetComponent<MeshRenderer>().enabled = true;

            newedgetop.GetComponent<MeshRenderer>().enabled = true;
            newedgetop.GetComponent<SphereCollider>().enabled = true;
            newedgetop.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            newedgetop.transform.Find("Line").gameObject.GetComponent<MeshRenderer>().enabled = true;

            newvertcoordinate.GetComponent<MeshRenderer>().enabled = true;
            newvertcoordinate.GetComponent<BoxCollider>().enabled = true;
            newvertcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

            newwall.GetComponent<MeshRenderer>().enabled = true;
            newedgeshadow.GetComponent<MeshRenderer>().enabled = true;

            newaddcoordinate.GetComponent<MeshRenderer>().enabled = true;
            newaddcoordinate.GetComponent<SphereCollider>().enabled = true;
            newaddcoordinate.transform.Find("Sprite").GetComponent<SpriteRenderer>().enabled = true;

            newedgebotname = "C" + n;
            newedgetopname = "C" + n;
            newedgeshadowname = "C" + n + "Bot";
            newvertcoordinatename = "VertC" + n;
            newwallname = "W" + n;
            newaddCname = "AddC" + n;

            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CTop = newedgetop;
            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CMiddle = newedgebot;
            newvertcoordinate.GetComponent<AttachParentVertexRuntime>().CBot = newedgeshadow;

            newedgebot.name = (newedgebotname);
            newedgetop.name = (newedgetopname);
            newedgeshadow.name = (newedgeshadowname);
            newvertcoordinate.name = (newvertcoordinatename);
            newwall.name = (newwallname);
            newaddcoordinate.name = (newaddCname);

            newedgebot.transform.parent = Coordinates_Container.transform;
            newedgetop.transform.parent = TopCoordinates_Container.transform;
            newedgeshadow.transform.parent = BotCoordinates_Container.transform;
            newvertcoordinate.transform.parent = Vertices.transform;
            newwall.transform.parent = Walls.transform;
            newwall.transform.localPosition = new Vector3(0, 0, 0);
            newaddcoordinate.transform.parent = AddC_Container.transform;

            //newwall.GetComponent<ModifySafetyZoneQuads>().ZoneisModified();

            // newedgebot.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;
            // newedgetop.GetComponent<ToggleZoneExpand>().centerofzone = ZONE_Center;

            newvertcoordinate.GetComponent<SolverHandler>().TransformOverride = newedgebot.transform;
            newvertcoordinate.GetComponent<InBetween>().SecondTransformOverride = newedgetop.transform;
            n++;
        }

        CreateZoneMesh();
    }
}


