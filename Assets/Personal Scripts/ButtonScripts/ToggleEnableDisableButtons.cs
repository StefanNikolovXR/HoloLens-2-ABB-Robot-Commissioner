using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class ToggleEnableDisableButtons : MonoBehaviour
{

    //variables for toggling button functionality and visuals, same across most buttons
    public GameObject ButtonParent;
    public AudioClip togglesoundoff, togglesoundon;
    public Material untoggledmat, toggledmat, hoveredmat;
    public bool istoggled = false, ishovered = false;
    public GameObject Backplate, Text;
    public TextMeshPro buttonname;
    public string Property = "_Color";
    public GameObject Sprite;
    public SpriteRenderer buttonsprite;

    public Color toggledcolor;
    public Color untoggledcolor;

    //specific to the function of buttons
    public ZoneValues zonevalues;

    void Start()
    {
        Backplate = transform.Find("Backplate").gameObject;
        Sprite = transform.Find("Sprite").gameObject;
        Text = transform.Find("Text").gameObject;
        buttonname = Text.GetComponent<TextMeshPro>();
        untoggledcolor = new Color32(255, 255, 255, 255);
        toggledcolor = new Color32(64, 64, 64, 255);
        buttonsprite = Sprite.GetComponent<SpriteRenderer>();
    }

    public void ToggleASP()
    {

        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;

            zonevalues.asp_on = false;

        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            Backplate.GetComponent<MeshRenderer>().material = toggledmat;

            zonevalues.asp_on = true;
        }
    }

    public void ToggleTSP()
    {

       if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;

            zonevalues.tsp_on = false;
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            Backplate.GetComponent<MeshRenderer>().material = toggledmat;

            zonevalues.tsp_on = true;
        
        }
    }

    public void ToggleAPO()
    {

    if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;

            zonevalues.apo_on = false;
       
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            Backplate.GetComponent<MeshRenderer>().material = toggledmat;

            zonevalues.apo_on = true;
    
        }
    }

    public void ToggleTPO()
    {

        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;

            zonevalues.tpo_on = false;
    
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            Backplate.GetComponent<MeshRenderer>().material = toggledmat;

            zonevalues.tpo_on = true;
      
        }
    }


    public void ToggleTOR()
    {

        if (istoggled)
        {
            //generic visuals that repeat for every toggled button
            IsToggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundoff);

            //the button's toggled OFF functionality

            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;

            zonevalues.tor_on = false;
    
        }

        else
        {
            //generic visuals that repeat for every toggled button
            IsUntoggled();
            ButtonParent.GetComponent<AudioSource>().PlayOneShot(togglesoundon);

            //the button's toggled ON functionality

            Backplate.GetComponent<MeshRenderer>().material = toggledmat;

            zonevalues.tor_on = true;
       
        }
    }

    public void IsToggled()
    {
        istoggled = false;
        buttonname.color = untoggledcolor;
        Backplate.GetComponent<MeshRenderer>().material = untoggledmat;
        buttonsprite.color = toggledcolor;
    }

    public void IsUntoggled()
    {
        istoggled = true;
        buttonname.color = toggledcolor;
        Backplate.GetComponent<MeshRenderer>().material = toggledmat;
        buttonsprite.color = untoggledcolor;
    }

    public void HoverEnter()
    {
        ishovered = true;
        Backplate.GetComponent<MeshRenderer>().material = hoveredmat;
    }

    public void HoverExit()
    {
        if (istoggled)
        {
            ishovered = false;
            Backplate.GetComponent<MeshRenderer>().material = toggledmat;
        }

        else
        {
            ishovered = false;
            Backplate.GetComponent<MeshRenderer>().material = untoggledmat;
        }
    }
}

