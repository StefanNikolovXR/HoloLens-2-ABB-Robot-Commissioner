using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class EdgeXYZ : MonoBehaviour
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
    private bool activeSelf;

    //specific to the function of buttons
    private GameObject Coordinates_Container, TopCoordinates_Container, Y_Container_BOT, Y_Container_TOP, BOT_Handle, TOP_Handle;

    public ZoneValues values;

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

    public void ToggleEdgeXYZ()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
            BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;
            Y_Container_BOT = BOT_Handle.transform.Find("Y_Container").gameObject;
            Y_Container_TOP = TOP_Handle.transform.Find("Y_Container").gameObject;

            foreach (Transform child in Coordinates_Container.transform)
            {
                var childxyz = child.transform.Find("XZ_Container").gameObject;
                childxyz.SetActive(false);
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                var childxyz = child.transform.Find("XZ_Container").gameObject;
                childxyz.SetActive(false);
            }

            Y_Container_BOT.SetActive(false);
            Y_Container_TOP.SetActive(false);

            values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().xyz = false;
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
            BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;
            Y_Container_BOT = BOT_Handle.transform.Find("Y_Container").gameObject;
            Y_Container_TOP = TOP_Handle.transform.Find("Y_Container").gameObject;

            foreach (Transform child in Coordinates_Container.transform)
            {
                var childxyz = child.transform.Find("XZ_Container").gameObject;
                childxyz.SetActive(true);
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                var childxyz = child.transform.Find("XZ_Container").gameObject;
                childxyz.SetActive(true);
            }

            Y_Container_BOT.SetActive(true);
            Y_Container_TOP.SetActive(true);

            values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().xyz = true;

        }
    }

    public void ExpandXYZ()
    {
        Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
        TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
        TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;
        Y_Container_BOT = BOT_Handle.transform.Find("Y_Container").gameObject;
        Y_Container_TOP = TOP_Handle.transform.Find("Y_Container").gameObject;

        foreach (Transform child in Coordinates_Container.transform)
        {
            var childxyz = child.transform.Find("XZ_Container").gameObject;
            childxyz.SetActive(true);
        }

        foreach (Transform child in TopCoordinates_Container.transform)
        {
            var childxyz = child.transform.Find("XZ_Container").gameObject;
            childxyz.SetActive(true);
        }

        Y_Container_BOT.SetActive(true);
        Y_Container_TOP.SetActive(true);

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().xyz = true;
    }

    public void CollapseXYZ()
    {
        Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
        TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
        TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;
        Y_Container_BOT = BOT_Handle.transform.Find("Y_Container").gameObject;
        Y_Container_TOP = TOP_Handle.transform.Find("Y_Container").gameObject;

        foreach (Transform child in Coordinates_Container.transform)
        {
            var childxyz = child.transform.Find("XZ_Container").gameObject;
            childxyz.SetActive(false);
        }

        foreach (Transform child in TopCoordinates_Container.transform)
        {
            var childxyz = child.transform.Find("XZ_Container").gameObject;
            childxyz.SetActive(false);
        }

        Y_Container_BOT.SetActive(false);
        Y_Container_TOP.SetActive(false);

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().xyz = false;
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

