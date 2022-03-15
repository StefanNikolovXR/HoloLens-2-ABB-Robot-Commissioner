using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class ToggleTSPTable : MonoBehaviour
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
    public LeanEvent disappear, tsp_appear;
    public GameObject sst_graphics, asp_graphics, tsp_graphics, apo_graphics, tpo_graphics, tor_graphics;

    public ToggleSSTTable sst_table;
    public ToggleASPTable asp_table;
    public ToggleAPOTable apo_table;
    public ToggleTPOTable tpo_table;
    public ToggleTORTable tor_table;

    public LUISFocusAssist focus;

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

    public void ToggleTSP()
    {

        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            disappear.BeginThisTransition();

            sst_graphics.SetActive(false);
            asp_graphics.SetActive(false);
            tsp_graphics.SetActive(false);
            apo_graphics.SetActive(false);
            tpo_graphics.SetActive(false);
            tor_graphics.SetActive(false);

            asp_table.ForceCollapse();
            sst_table.ForceCollapse();
            apo_table.ForceCollapse();
            tpo_table.ForceCollapse();
            tor_table.ForceCollapse();
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            tsp_appear.BeginThisTransition();

            sst_graphics.SetActive(false);
            asp_graphics.SetActive(false);
            tsp_graphics.SetActive(true);
            apo_graphics.SetActive(false);
            tpo_graphics.SetActive(false);
            tor_graphics.SetActive(false);

            asp_table.ForceCollapse();
            sst_table.ForceCollapse();
            apo_table.ForceCollapse();
            tpo_table.ForceCollapse();
            tor_table.ForceCollapse();
        }
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
        focus.TSP();
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

