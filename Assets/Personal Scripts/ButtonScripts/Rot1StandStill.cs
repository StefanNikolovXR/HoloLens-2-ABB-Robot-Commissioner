using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class Rot1StandStill : MonoBehaviour
{

    //variables for toggling button functionality and visuals, same across most buttons
    public GameObject ButtonParent;
    public AudioClip togglesoundoff, togglesoundon;
    public Material buttonmaterial;
    public bool istoggled = false, ishovered = false;
    public GameObject Backplate, Text, Leanhovered, Leanhovertoggled, Leanhoveruntoggled;
    public LeanMaterialColor hovered, hovertoggled, hoveruntoggled;
    public TextMeshPro buttonname;
    public Color untoggledcolor, hoveredcolor, toggledcolor;
    public string Property = "_Color";

    //specific to the function of buttons

    public Rot1Custom custom;
    public Rot1APONormal apo;
    public Rot1InvertedLower lower;
    public Rot1InvertedUpper upper;
    public Rot1FactoryLimit factory;

    public MasterSliderData master;

    void Start()
    {
        Backplate = transform.Find("Backplate").gameObject;
        Text = transform.Find("Text").gameObject;
        Leanhovered = transform.Find("Lean_HoveredMat").gameObject;
        Leanhovertoggled = transform.Find("Lean_ToggledMat").gameObject;
        Leanhoveruntoggled = transform.Find("Lean_UntoggledMat").gameObject;

        buttonmaterial = Backplate.GetComponent<Renderer>().sharedMaterial;
        buttonname = Text.GetComponent<TextMeshPro>();
        hovered = Leanhovered.GetComponent<LeanMaterialColor>();
        hovertoggled = Leanhovertoggled.GetComponent<LeanMaterialColor>();
        hoveruntoggled = Leanhoveruntoggled.GetComponent<LeanMaterialColor>();

        hoveredcolor = new Color32(0, 192, 255, 255);
        toggledcolor = new Color32(255, 255, 255, 255);
        untoggledcolor = new Color32(64, 64, 64, 255);
        buttonmaterial.SetColor(Property, untoggledcolor);
    }

    public void ToggleRot1StandStill()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            factory.IsUntoggled();
            lower.ForceCollapse();
            apo.ForceCollapse();
            upper.ForceCollapse();
            custom.ForceCollapse();

            master.factory = true;
            master.sst = false;
            master.lower = false;
            master.upper = false;
            master.apo = false;
            master.custom = false;
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            factory.ForceCollapse();
            lower.ForceCollapse();
            apo.ForceCollapse();
            upper.ForceCollapse();
            custom.ForceCollapse();

            master.factory = false;
            master.sst = true;
            master.lower = false;
            master.upper = false;
            master.apo = false;
            master.custom = false;

            master.ProcessStandStill();
            master.SetupSlider();
        }
    }

    public void ForceCollapse()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, untoggledcolor);
        buttonname.color = toggledcolor;
    }

    public void IsToggled()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, hoveredcolor);
        buttonname.color = toggledcolor;
    }

    public void IsUntoggled()
    {
        istoggled = true;
        buttonmaterial.SetColor(Property, hoveredcolor);
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

