using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class Parallel : MonoBehaviour
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
    public GameObject Articulated_container, Collaborative_container, Parallel_container, SCARA_container, Paint_container, Positioners_container, Tracks_container;

    public Articulated articulated;
    public Collaborative collaborative;
    //public Parallel parallel;
    public SCARA scara;
    public Paint paint;
    public Positioners positioners;
    public Tracks tracks;

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

    public void ToggleParallel()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            Articulated_container.SetActive(false);
            Collaborative_container.SetActive(false);
            Parallel_container.SetActive(false);
            SCARA_container.SetActive(false);
            Paint_container.SetActive(false);
            Positioners_container.SetActive(false);
            Tracks_container.SetActive(false);
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            Articulated_container.SetActive(false);
            Collaborative_container.SetActive(false);
            Parallel_container.SetActive(true);
            SCARA_container.SetActive(false);
            Paint_container.SetActive(false);
            Positioners_container.SetActive(false);
            Tracks_container.SetActive(false);

            articulated.ForceCollapse();
            collaborative.ForceCollapse();
            //parallel.ForceCollapse();
            scara.ForceCollapse();
            paint.ForceCollapse();
            positioners.ForceCollapse();
            tracks.ForceCollapse();
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

