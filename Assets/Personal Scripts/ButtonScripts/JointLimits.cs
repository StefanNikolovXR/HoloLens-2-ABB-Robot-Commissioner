using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class JointLimits : MonoBehaviour
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
    public GameObject base1arrow, arm2arrow, arm3arrow, wrist4arrow, bend5arrow, turn6arrow;

    public MeshRenderer j1factory, j2factory, j3factory, j4factory, j5factory, j6factory;
    public LUISFocusAssist focus;

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

    public void CheckJointToggle()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);
           // axisarcscript.GetComponent<AxisArcVisualization>().HideAllLimits();
            //the button's functionality

            base1arrow.SetActive(false);
            arm2arrow.SetActive(false);
            arm3arrow.SetActive(false);
            wrist4arrow.SetActive(false);
            bend5arrow.SetActive(false);
            turn6arrow.SetActive(false);

            j1factory.enabled = false;
            j2factory.enabled = false;
            j3factory.enabled = false;
            j4factory.enabled = false;
            j5factory.enabled = false;
            j6factory.enabled = false;
        }

        else 
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's functionality
           // axisarcscript.GetComponent<AxisArcVisualization>().ProcessAllLimits();

            base1arrow.SetActive(true);
            arm2arrow.SetActive(true);
            arm3arrow.SetActive(true);
            wrist4arrow.SetActive(true);
            bend5arrow.SetActive(true);
            turn6arrow.SetActive(true);

            j1factory.enabled = true;
            j2factory.enabled = true;
            j3factory.enabled = true;
            j4factory.enabled = true;
            j5factory.enabled = true;
            j6factory.enabled = true;
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
        focus.AxisArrows();
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

