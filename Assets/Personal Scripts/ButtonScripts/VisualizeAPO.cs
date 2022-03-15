using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class VisualizeAPO : MonoBehaviour
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
    public MeshRenderer j1lowernormal, j1uppernormal, j1lowerinverted, j1upperinverted;
    public MeshRenderer j2lowernormal, j2uppernormal, j2lowerinverted, j2upperinverted;
    public MeshRenderer j3lowernormal, j3uppernormal, j3lowerinverted, j3upperinverted;
    public MeshRenderer j4lowernormal, j4uppernormal, j4lowerinverted, j4upperinverted;
    public MeshRenderer j5lowernormal, j5uppernormal, j5lowerinverted, j5upperinverted;
    public MeshRenderer j6lowernormalinner, j6uppernormalinner, j6lowernormal, j6uppernormal, j6lowernormalouter, j6uppernormalouter;
    public MeshRenderer j6lowerinvertedinner, j6upperinvertedinner, j6lowerinverted, j6upperinverted, j6lowerinvertedouter, j6upperinvertedouter;

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

    public void ToggleVisualizeAPO()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            j1lowernormal.enabled = false;
            j1uppernormal.enabled = false;

            j1lowerinverted.enabled = false;
            j1upperinverted.enabled = false;

            j2lowernormal.enabled = false;
            j2uppernormal.enabled = false;

            j2lowerinverted.enabled = false;
            j2upperinverted.enabled = false;

            j3lowernormal.enabled = false;
            j3uppernormal.enabled = false;

            j3lowerinverted.enabled = false;
            j3upperinverted.enabled = false;

            j4lowernormal.enabled = false;
            j4uppernormal.enabled = false;

            j4lowerinverted.enabled = false;
            j4upperinverted.enabled = false;

            j5lowernormal.enabled = false;
            j5uppernormal.enabled = false;

            j5lowerinverted.enabled = false;
            j5upperinverted.enabled = false;

            j6lowernormalinner.enabled = false;
            j6uppernormalinner.enabled = false;

            j6lowernormal.enabled = false;
            j6uppernormal.enabled = false;

            j6lowernormalouter.enabled = false;
            j6uppernormalouter.enabled = false;

            j6lowerinvertedinner.enabled = false;
            j6upperinvertedinner.enabled = false;

            j6lowerinverted.enabled = false;
            j6upperinverted.enabled = false;

            j6lowerinvertedouter.enabled = false;
            j6upperinvertedouter.enabled = false;

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            j1lowernormal.enabled = true;
            j1uppernormal.enabled = true;

            j1lowerinverted.enabled = true;
            j1upperinverted.enabled = true;

            j2lowernormal.enabled = true;
            j2uppernormal.enabled = true;

            j2lowerinverted.enabled = true;
            j2upperinverted.enabled = true;

            j3lowernormal.enabled = true;
            j3uppernormal.enabled = true;

            j3lowerinverted.enabled = true;
            j3upperinverted.enabled = true;

            j4lowernormal.enabled = true;
            j4uppernormal.enabled = true;

            j4lowerinverted.enabled = true;
            j4upperinverted.enabled = true;

            j5lowernormal.enabled = true;
            j5uppernormal.enabled = true;

            j5lowerinverted.enabled = true;
            j5upperinverted.enabled = true;

            j6lowernormalinner.enabled = true;
            j6uppernormalinner.enabled = true;

            j6lowernormal.enabled = true;
            j6uppernormal.enabled = true;

            j6lowernormalouter.enabled = true;
            j6uppernormalouter.enabled = true;

            j6lowerinvertedinner.enabled = true;
            j6upperinvertedinner.enabled = true;

            j6lowerinverted.enabled = true;
            j6upperinverted.enabled = true;

            j6lowerinvertedouter.enabled = true;
            j6upperinvertedouter.enabled = true;
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

