using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class JogHandles : MonoBehaviour
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
    public MeshRenderer j1, j2, j3, j4, j5, tool;
    public SphereCollider j1col, j2col, j3col, j4col, j5col;
    public MeshCollider toolcol;
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

    public void ToggleJogHandles()
    {
        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality
            j1.enabled = false;
            j2.enabled = false;
            j3.enabled = false;
            j4.enabled = false;
            j5.enabled = false;

            j1col.enabled = false;
            j2col.enabled = false;
            j3col.enabled = false;
            j4col.enabled = false;
            j5col.enabled = false;

            tool.enabled = false;
            toolcol.enabled = false;

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality
            j1.enabled = true;
            j2.enabled = true;
            j3.enabled = true;
            j4.enabled = true;
            j5.enabled = true;

            j1col.enabled = true;
            j2col.enabled = true;
            j3col.enabled = true;
            j4col.enabled = true;
            j5col.enabled = true;

            tool.enabled = true;
            toolcol.enabled = true;
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
        focus.JogHandles();
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

