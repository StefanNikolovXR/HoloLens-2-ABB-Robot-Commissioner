using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class Projection : MonoBehaviour
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
    private GameObject parent, BotCoordinates_Container;
    public GameObject Shadow;

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

        parent = transform.root.gameObject;
        BotCoordinates_Container = transform.Find("BotCoordinates_Container").gameObject;

    }

    public void ToggleProjection()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            var poly = values.selectedzone.transform.Find("Polygons").gameObject;
            var shadow = poly.transform.Find("Bottom").gameObject;
            shadow.GetComponent<MeshRenderer>().enabled = false;

            var BotCoordinates_Container = values.selectedzone.transform.Find("BotCoordinates_Container").gameObject;

            foreach (Transform child in BotCoordinates_Container.transform)
            {
                child.GetComponent<MeasureLine>().enabled = false;
            }

           values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().floor = false;

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            var poly = values.selectedzone.transform.Find("Polygons").gameObject;
            var shadow = poly.transform.Find("Bottom").gameObject;
            shadow.GetComponent<MeshRenderer>().enabled = true;

            var BotCoordinates_Container = values.selectedzone.transform.Find("BotCoordinates_Container").gameObject;

            foreach (Transform child in BotCoordinates_Container.transform)
            {
                child.GetComponent<MeasureLine>().enabled = true;
            }

            values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().floor = true;
        }
}

    public void CollapseProjection()
    {
        var poly = values.selectedzone.transform.Find("Polygons").gameObject;
        var shadow = poly.transform.Find("Bottom").gameObject;
        shadow.GetComponent<MeshRenderer>().enabled = false;

        var BotCoordinates_Container = values.selectedzone.transform.Find("BotCoordinates_Container").gameObject;

        foreach (Transform child in BotCoordinates_Container.transform)
        {
            child.GetComponent<MeasureLine>().enabled = false;
        }

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().floor = false;
    }

    public void ExpandProjection()
    {
        var poly = values.selectedzone.transform.Find("Polygons").gameObject;
        var shadow = poly.transform.Find("Bottom").gameObject;
        shadow.GetComponent<MeshRenderer>().enabled = true;

        var BotCoordinates_Container = values.selectedzone.transform.Find("BotCoordinates_Container").gameObject;

        foreach (Transform child in BotCoordinates_Container.transform)
        {
            child.GetComponent<MeasureLine>().enabled = true;
        }

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().floor = true;
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

