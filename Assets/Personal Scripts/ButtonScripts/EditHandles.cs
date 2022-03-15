using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class EditHandles : MonoBehaviour
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
    private GameObject Coordinates_Container, TopCoordinates_Container, Vertices, AddC_Container, TOP_Handle, BOT_Handle;
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

    public void ToggleEditHandles()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            Vertices = values.selectedzone.transform.Find("Vertices").gameObject;
            AddC_Container = values.selectedzone.transform.Find("AddC_Container").gameObject;
            TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
            BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;

            foreach (Transform child in Coordinates_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (Transform child in Vertices.transform)
            {
                child.GetComponent<BoxCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = false;
            }

            foreach (Transform child in AddC_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = false;
                child.GetComponent<MeshRenderer>().enabled = false;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = false;
            }

            TOP_Handle.GetComponent<MeshRenderer>().enabled = false;
            TOP_Handle.GetComponent<BoxCollider>().enabled = false;
            TOP_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = false;

            BOT_Handle.GetComponent<MeshRenderer>().enabled = false;
            BOT_Handle.GetComponent<BoxCollider>().enabled = false;
            BOT_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = false;

            values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().edit = false;

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
            TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
            Vertices = values.selectedzone.transform.Find("Vertices").gameObject;
            AddC_Container = values.selectedzone.transform.Find("AddC_Container").gameObject;
            TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
            BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;

            foreach (Transform child in Coordinates_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = true;
                child.GetComponent<MeshRenderer>().enabled = true;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = true;
            }

            foreach (Transform child in TopCoordinates_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = true;
                child.GetComponent<MeshRenderer>().enabled = true;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = true;
            }

            foreach (Transform child in Vertices.transform)
            {
                child.GetComponent<BoxCollider>().enabled = true;
                child.GetComponent<MeshRenderer>().enabled = true;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = true;
            }

            foreach (Transform child in AddC_Container.transform)
            {
                child.GetComponent<SphereCollider>().enabled = true;
                child.GetComponent<MeshRenderer>().enabled = true;
                var childsprite = child.transform.Find("Sprite").gameObject;
                childsprite.GetComponent<SpriteRenderer>().enabled = true;
            }

            TOP_Handle.GetComponent<MeshRenderer>().enabled = true;
            TOP_Handle.GetComponent<BoxCollider>().enabled = true;
            TOP_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;

            BOT_Handle.GetComponent<MeshRenderer>().enabled = true;
            BOT_Handle.GetComponent<BoxCollider>().enabled = true;
            BOT_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;

            values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().edit = true;
        }
    }

    public void ExpandEditHandles()
    {
        Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
        TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
        Vertices = values.selectedzone.transform.Find("Vertices").gameObject;
        AddC_Container = values.selectedzone.transform.Find("AddC_Container").gameObject;
        TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;

        foreach (Transform child in Coordinates_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = true;
            child.GetComponent<MeshRenderer>().enabled = true;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = true;
        }

        foreach (Transform child in TopCoordinates_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = true;
            child.GetComponent<MeshRenderer>().enabled = true;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = true;
        }

        foreach (Transform child in Vertices.transform)
        {
            child.GetComponent<BoxCollider>().enabled = true;
            child.GetComponent<MeshRenderer>().enabled = true;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = true;
        }

        foreach (Transform child in AddC_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = true;
            child.GetComponent<MeshRenderer>().enabled = true;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = true;
        }

        TOP_Handle.GetComponent<MeshRenderer>().enabled = true;
        TOP_Handle.GetComponent<BoxCollider>().enabled = true;
        TOP_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;

        BOT_Handle.GetComponent<MeshRenderer>().enabled = true;
        BOT_Handle.GetComponent<BoxCollider>().enabled = true;
        BOT_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = true;

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().edit = true;
    }

    public void CollapseEditHandles()
    {
        Coordinates_Container = values.selectedzone.transform.Find("Coordinates_Container").gameObject;
        TopCoordinates_Container = values.selectedzone.transform.Find("TopCoordinates_Container").gameObject;
        Vertices = values.selectedzone.transform.Find("Vertices").gameObject;
        AddC_Container = values.selectedzone.transform.Find("AddC_Container").gameObject;
        TOP_Handle = values.selectedzone.transform.Find("TOP_Handle").gameObject;
        BOT_Handle = values.selectedzone.transform.Find("BOT_Handle").gameObject;

        foreach (Transform child in Coordinates_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = false;
            child.GetComponent<MeshRenderer>().enabled = false;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (Transform child in TopCoordinates_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = false;
            child.GetComponent<MeshRenderer>().enabled = false;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (Transform child in Vertices.transform)
        {
            child.GetComponent<BoxCollider>().enabled = false;
            child.GetComponent<MeshRenderer>().enabled = false;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = false;
        }

        foreach (Transform child in AddC_Container.transform)
        {
            child.GetComponent<SphereCollider>().enabled = false;
            child.GetComponent<MeshRenderer>().enabled = false;
            var childsprite = child.transform.Find("Sprite").gameObject;
            childsprite.GetComponent<SpriteRenderer>().enabled = false;
        }

        TOP_Handle.GetComponent<MeshRenderer>().enabled = false;
        TOP_Handle.GetComponent<BoxCollider>().enabled = false;
        TOP_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = false;

        BOT_Handle.GetComponent<MeshRenderer>().enabled = false;
        BOT_Handle.GetComponent<BoxCollider>().enabled = false;
        BOT_Handle.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().enabled = false;

        values.selectedzone.transform.Find("Stored_Data").gameObject.GetComponent<SafeZoneStoredData>().edit = false;
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

