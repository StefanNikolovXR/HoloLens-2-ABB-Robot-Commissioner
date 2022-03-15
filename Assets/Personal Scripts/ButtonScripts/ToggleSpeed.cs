using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class ToggleSpeed : MonoBehaviour
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
    public TorqueSpeedRatioSlider torqueslider;
    public ToggleRot1Torque ToggleRot1Torque;
    public ToggleArm2Torque ToggleArm2Torque;
    public ToggleArm3Torque ToggleArm3Torque;
    public ToggleWrist4Torque ToggleWrist4Torque;
    public ToggleBend5Torque ToggleBend5Torque;
    public ToggleTurn6Torque ToggleTurn6Torque;
    //public ToggleTurn6Torque ToggleTurn6Torque;


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

    public void ForceCollapse()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, untoggledcolor);
        buttonname.color = toggledcolor;
    }

    public void ForceShow()
    {
        istoggled = true;
        buttonmaterial.SetColor(Property, toggledcolor);
        buttonname.color = untoggledcolor;
    }

    public void ToggleSpeedButton()
    {
        if (istoggled)
        {
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            ToggleRot1Torque.ForceShow();
            ToggleArm2Torque.ForceCollapse();
            ToggleArm3Torque.ForceCollapse();
            ToggleWrist4Torque.ForceCollapse();
            ToggleBend5Torque.ForceCollapse();
            ToggleTurn6Torque.ForceCollapse();

            torqueslider.sliderstatus = 1;
            torqueslider.SetupSlider();
        }

        else
        {
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            ToggleRot1Torque.ForceCollapse();
            ToggleArm2Torque.ForceCollapse();
            ToggleArm3Torque.ForceCollapse();
            ToggleWrist4Torque.ForceCollapse();
            ToggleBend5Torque.ForceCollapse();
            ToggleTurn6Torque.ForceCollapse();

            torqueslider.sliderstatus = 7;
            torqueslider.SetupSlider();
        }
    }

    public void FunctionOff()
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

