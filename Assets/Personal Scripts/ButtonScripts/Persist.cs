using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class Persist : MonoBehaviour
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

    public void TogglePersist()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

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

