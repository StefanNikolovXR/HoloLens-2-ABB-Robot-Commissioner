using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using Lean.Transition;
using Lean.Transition.Method;

public class SingleWorkCell : MonoBehaviour
{

    //variables for toggling button functionality and visuals, same across most buttons
    public GameObject ButtonParent;
    public AudioClip togglesoundoff, togglesoundon;
    public Material buttonmaterial;
    public bool istoggled = false, ishovered = false;
    public GameObject Backplate, Leanhovered, Leanhovertoggled, Leanhoveruntoggled;
    public LeanMaterialColor hovered, hovertoggled, hoveruntoggled;
    public Color untoggledcolor, hoveredcolor, toggledcolor;
    public string Property = "_Color";

    //specific to the function of buttons
    public LeanEvent expand, shrink;
    public TextMeshPro text;

    public StartMenu startmenu;
    public Follow follow;
    public SolverHandler solver;
    public GameObject anchor;
    public FocusHandler focus;

    public GameObject SelectRobot;
    public MeshRenderer robotbase, j1, j2, j3, j4, j5;

    public LeanEvent hidepanel, panelgone, hidestart, startgone;

    void Start()
    {
        Backplate = transform.Find("Backplate").gameObject;
        Leanhovered = transform.Find("Lean_HoveredMat").gameObject;
        Leanhovertoggled = transform.Find("Lean_ToggledMat").gameObject;
        Leanhoveruntoggled = transform.Find("Lean_UntoggledMat").gameObject;

        buttonmaterial = Backplate.GetComponent<Renderer>().sharedMaterial;
        hovered = Leanhovered.GetComponent<LeanMaterialColor>();
        hovertoggled = Leanhovertoggled.GetComponent<LeanMaterialColor>();
        hoveruntoggled = Leanhoveruntoggled.GetComponent<LeanMaterialColor>();

        hoveredcolor = new Color32(0, 192, 255, 255);
        toggledcolor = new Color32(255, 255, 255, 255);
        untoggledcolor = new Color32(64, 64, 64, 255);
        buttonmaterial.SetColor(Property, untoggledcolor);
    }

    public void TaptoSelectRobot()
    {
        SelectRobot.SetActive(true);
       
        ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);
    }

    public void TapSingleWorkCell()
    {
        follow.enabled = true;
        solver.enabled = true;
        anchor.SetActive(true);
        focus.enabled = false;
        ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);
        startmenu.ToggleStartMenu();
        robotbase.enabled = true;
        j1.enabled = true;
        j2.enabled = true;
        j3.enabled = true;
        j4.enabled = true;
        j5.enabled = true;

        hidepanel.BeginThisTransition();
        panelgone.BeginThisTransition();
        hidestart.BeginThisTransition();
        startgone.BeginThisTransition();
    }

    public void IsToggled()
    {
        istoggled = false;
        buttonmaterial.SetColor(Property, hoveredcolor);
    }

    public void IsUntoggled()
    {
        istoggled = true;
        buttonmaterial.SetColor(Property, hoveredcolor);
    }

    public void HoverEnter()
    {
        ishovered = true;
        hovered.BeginThisTransition();
        expand.BeginThisTransition();
        text.GetComponent<MeshRenderer>().enabled = true;
    }

    public void HoverExit()
    {
        if (istoggled)
        {
            ishovered = false;
            hovertoggled.BeginThisTransition();
            shrink.BeginThisTransition();
            text.GetComponent<MeshRenderer>().enabled = false;
        }

        else
        {
            ishovered = false;
            hoveruntoggled.BeginThisTransition();
            shrink.BeginThisTransition();
            text.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

