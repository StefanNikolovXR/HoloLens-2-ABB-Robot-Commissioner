using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class CollapseExpandZone : MonoBehaviour
{

    //variables for toggling button functionality and visuals, same across most buttons
    public GameObject ButtonParent;
    public AudioClip togglesoundoff, togglesoundon;
    public Material buttonmaterial;
    public bool istoggled = false, ishovered = false;
    public GameObject Backplate, Sprite, Text, Leanhovered, Leanhovertoggled, Leanhoveruntoggled;
    public LeanMaterialColor hovered, hovertoggled, hoveruntoggled;
    public TextMeshPro buttonname;
    public Color untoggledcolor, hoveredcolor, toggledcolor;
    public SpriteRenderer buttonsprite;
    public string Property = "_Color";

    //specific to the function of buttons
    public GameObject Coordinates_Container, TopCoordinates_Container, Center;
    public ZoneValues values;

    public Projection projection;
    public EdgeXYZ edgexyz;
    public EdgeLines edgelines;
    public FloorDistance walls;
    public EditHandles edithandles;
    public MoveZone movezone;

    public SafeZoneStoredData storeddata;

    void Start()
    {
        Backplate = transform.Find("Backplate").gameObject;
        Sprite = transform.Find("Sprite").gameObject;
        Text = transform.Find("Text").gameObject;
        Leanhovered = transform.Find("Lean_HoveredMat").gameObject;
        Leanhovertoggled = transform.Find("Lean_ToggledMat").gameObject;
        Leanhoveruntoggled = transform.Find("Lean_UntoggledMat").gameObject;

        buttonmaterial = Backplate.GetComponent<Renderer>().sharedMaterial;
        buttonsprite = Sprite.GetComponent<SpriteRenderer>();
        buttonname = Text.GetComponent<TextMeshPro>();
        hovered = Leanhovered.GetComponent<LeanMaterialColor>();
        hovertoggled = Leanhovertoggled.GetComponent<LeanMaterialColor>();
        hoveruntoggled = Leanhoveruntoggled.GetComponent<LeanMaterialColor>();

        hoveredcolor = new Color32(0, 192, 255, 255);
        toggledcolor = new Color32(255, 255, 255, 255);
        untoggledcolor = new Color32(64, 64, 64, 255);
        buttonmaterial.SetColor(Property, untoggledcolor);

    }

    public void ForceCollapse()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, untoggledcolor);
        buttonname.color = toggledcolor;
        buttonsprite.color = toggledcolor;
    }

    public void ForceShow()
    {
        istoggled = true;
        buttonmaterial.SetColor(Property, toggledcolor);
        buttonname.color = untoggledcolor;
        buttonsprite.color = untoggledcolor;
    }

    IEnumerator HideLines()
    {
        yield return new WaitForSeconds(1f);
        edgelines.CollapseEdgeLines();
    }

    public void ToggleCollapseExpandZone() {

        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            Center = values.selectedzone.transform.Find("Center").gameObject;

            projection.CollapseProjection();
            edgexyz.CollapseXYZ();
            edgelines.CollapseEdgeLines();
            walls.CollapseWalls();
            edithandles.CollapseEditHandles();
            movezone.CollapseMoveZone();

            edgelines.ExpandEdgeLines();

            foreach (Transform child in Coordinates_Container.transform)
            {
                child.GetComponent<ToggleZoneExpand>().centerofzone = Center;
                child.GetComponent<ToggleZoneExpand>().SaveCoordinateLocation();
                child.GetComponent<ToggleZoneExpand>().CoordinatetoCenter();
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                child.GetComponent<ToggleZoneExpand>().centerofzone = Center;
                child.GetComponent<ToggleZoneExpand>().SaveCoordinateLocation();
                child.GetComponent<ToggleZoneExpand>().CoordinatetoCenter();
            }

            StartCoroutine(HideLines());
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            Center = values.selectedzone.transform.Find("Center").gameObject;

            edgelines.ExpandEdgeLines();

            foreach (Transform child in Coordinates_Container.transform)
            {
                child.GetComponent<ToggleZoneExpand>().centerofzone = Center;
                child.GetComponent<ToggleZoneExpand>().CoordinatefromCenter();
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                child.GetComponent<ToggleZoneExpand>().centerofzone = Center;
                child.GetComponent<ToggleZoneExpand>().CoordinatefromCenter();
            }

            storeddata = values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>();

            StartCoroutine(ShowElements());
        }
  
}

    IEnumerator ShowElements()
    {
        yield return new WaitForSeconds(1f);

        if (storeddata.floor)
        {
            projection.ExpandProjection();
        }

        if (storeddata.xyz)
        {
            edgexyz.ExpandXYZ();
        }

        if (!storeddata.lines) {

            edgelines.CollapseEdgeLines();
        }

        if (storeddata.walls)
        {
            walls.ExpandWalls();
        }

        if (storeddata.edit)
        {
            edithandles.ExpandEditHandles();
        }

        if (storeddata.move)
        {
            movezone.ExpandMoveZone();
        }

    }
 
    public void IsToggled()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, hoveredcolor);
        buttonsprite.color = toggledcolor;
        buttonname.color = toggledcolor;
    }

    public void IsUntoggled()
    {
        istoggled = true;
        buttonmaterial.SetColor(Property, hoveredcolor);
        buttonsprite.color = untoggledcolor;
        buttonname.color = untoggledcolor;
    }

    public void HoverEnter()
    {
        ishovered = true;
        hovered.BeginThisTransition();
    }

    public void HoverExit()
    {
        if (istoggled)
        {
            ishovered = false;
            hovertoggled.BeginThisTransition();
        }

        else
        {
            ishovered = false;
            hoveruntoggled.BeginThisTransition();
        }
    }
}

