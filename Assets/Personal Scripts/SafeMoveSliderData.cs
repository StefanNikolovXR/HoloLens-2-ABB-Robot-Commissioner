using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;

public class SafeMoveSliderData : MonoBehaviour
{
    public GameObject selectedjoint, selectedzone;
    public GameObject j1, j2, j3, j4, j5, j6;
    public GameObject JointLimitsContainer;
    public GameObject Slider;

    public Material selectedjointmat, defaultjointmat;

    public GameObject j1posarc, j1negarc, j1posarcinv, j1negarcinv;
    public GameObject j2posarc, j2negarc, j2posarcinv, j2negarcinv;
    public GameObject j3posarc, j3negarc, j3posarcinv, j3negarcinv;
    public GameObject j4posarc, j4negarc, j4posarcinv, j4negarcinv;
    public GameObject j5posarc, j5negarc, j5posarcinv, j5negarcinv;
    public GameObject j6posarc, j6negarc, j6posarcinv, j6negarcinv;

    public bool masterslideron = false, defaultmode = false, allowinsideglobal = true;

    public bool notinv_notallow = false, notinv_allow = false, inv_notallow = false, inv_allow = false;

    public bool sst_toggle = false, asp_toggle = false, tsp_toggle = false, apo_toggle = false, tpo_toggle = false, tor_toggle = false;

    public bool exclusiveon, invertedon, minangleon, maxangleon, jointlimits = false, leftsideactive=true, rightsideactive=false;
    public bool j1selected=false, j2selected = false, j3selected = false, j4selected = false, j5selected = false, j6selected = false;
    public bool j1canhover = true, j2canhover = true, j3canhover = true, j4canhover = true, j5canhover = true, j6canhover = true;

    public TextMeshPro defaultleftlimittext, defaultrightlimittext;
    public TextMeshPro axisposlefttext, axisposrighttext; 

    public float j1pos = 0, j1neg = 0;
    public Vector3 JointVectorPos, JointVectorNeg;

    private float rot1_lowerbound, rot1_upperbound;

    public TextMeshPro j1lowertext, j1uppertext, j2lowertext, j2uppertext, j3lowertext, j3uppertext, j4lowertext, j4uppertext, j5lowertext, j5uppertext, j6lowertext, j6uppertext;
    public TextMeshPro j1mintext, j1maxtext, j2mintext, j2maxtext, j3mintext, j3maxtext, j4mintext, j4maxtext, j5mintext, j5maxtext, j6mintext, j6maxtext;

    public TextMeshPro rot1_inv, arm2_inv, arm3_inv, wrist4_inv, bend5_inv, turn6_inv;

    public bool activeSelf;

    private float slidervalue;

    void Awake()
    {
        slidervalue = Slider.GetComponent<PinchSlider>().SliderValue;
    }

    public void SetSliderValue()
    {
        slidervalue = 0.5f;
        Slider.GetComponent<PinchSlider>().SliderValue = slidervalue;
    }

    public void ParseGlobalData() {

        float.TryParse(j1lowertext.GetParsedText(), out rot1_lowerbound);
        float.TryParse(j1uppertext.GetParsedText(), out rot1_upperbound);


    }

    public void GetDefaultJointAngle()
    {

    }

    public void DefaultModeLogic()
    {
        if (!sst_toggle && !asp_toggle && !tsp_toggle && !apo_toggle && !tpo_toggle && tor_toggle && selectedzone == null)
        {
            defaultmode = true;
        }

        else defaultmode = false;
    }

    public void AxisArcLogic()
    {
        if(selectedjoint == j1)
        {
            if(allowinsideglobal)
            {
                if(rot1_inv.text == "No")
                {
                   // defaultleftlimittext.text = rot1_lowerbound.text;
                  //  defaultrightlimittext.text = rot1_upperbound.text;

                    j1posarc.GetComponent<MeshRenderer>().enabled = true;
                    j1negarc.GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
    }

    public void SliderMotion(SliderEventData eventData)
    {
        if (masterslideron)
        {
            
            if (!sst_toggle && !asp_toggle && !tsp_toggle && !apo_toggle && !tpo_toggle && tor_toggle && selectedzone == null)
            {
                if (selectedjoint == j1)
                {
                j1pos = eventData.NewValue * 165;
                JointVectorPos = new Vector3(0, 0, j1pos);
                j1.transform.localEulerAngles = JointVectorPos;
                j1posarc.GetComponent<Shaper2D>().arcDegrees = j1pos;
                j1posarcinv.GetComponent<Shaper2D>().arcDegrees = 165 - j1pos;

                axisposlefttext.text = $"{j1pos:F2}" + "°";
                j1lowertext.text = axisposlefttext.text;
                }
            }

        }

    }

    public void JointMoveLeft(SliderEventData eventData)
    {
        if (selectedjoint == j1)
        {
            j1neg = eventData.NewValue * 165;
            JointVectorNeg = new Vector3(0, 0, j1neg * (-1));
            j1.transform.localEulerAngles = JointVectorNeg;
            axisposlefttext.text = "-" + $"{j1neg:F2}" + "°";

        }
    }

    public void SelectJ1()
    {
        
        if (masterslideron) {

            DefaultModeLogic();

            if (!j1selected)
            {
                j1selected = true;
                j1selected = false;
                j2selected = false;
                j3selected = false;
                j4selected = false;
                j5selected = false;
                j6selected = false;

                j1canhover = true;
                j2canhover = true;
                j3canhover = true;
                j4canhover = true;
                j5canhover = true;
                j6canhover = true;

                j1.GetComponent<MeshRenderer>().material = selectedjointmat;
                j2.GetComponent<MeshRenderer>().material = defaultjointmat;
                j3.GetComponent<MeshRenderer>().material = defaultjointmat;
                j4.GetComponent<MeshRenderer>().material = defaultjointmat;
                j5.GetComponent<MeshRenderer>().material = defaultjointmat;
                j6.GetComponent<MeshRenderer>().material = defaultjointmat;

                selectedjoint = j1;

                if (defaultmode)
                {
                    if(notinv_allow == true)
                    {

                    }
                }
            }


            else if (j1selected)

            {
                j1selected = false;
                j2selected = false;
                j3selected = false;
                j4selected = false;
                j5selected = false;
                j6selected = false;

                j1canhover = false;
                j2canhover = true;
                j3canhover = true;
                j4canhover = true;
                j5canhover = true;
                j6canhover = true;

                selectedjoint = null;

                j1.GetComponent<MeshRenderer>().material = defaultjointmat;
                j2.GetComponent<MeshRenderer>().material = defaultjointmat;
                j3.GetComponent<MeshRenderer>().material = defaultjointmat;
                j4.GetComponent<MeshRenderer>().material = defaultjointmat;
                j5.GetComponent<MeshRenderer>().material = defaultjointmat;
                j6.GetComponent<MeshRenderer>().material = defaultjointmat;
            }


            }
        }

    public void InvertON() {

        invertedon = true;
    }

    public void InvertOFF()
    {

        invertedon = false;
    }

    public void CheckInverted()
    {
        if (jointlimits)
        {
            if (invertedon)
            {
                if (selectedjoint == j1)

                {
                    j1posarc.GetComponent<MeshRenderer>().enabled = false;
                    j1negarc.GetComponent<MeshRenderer>().enabled = false;

                    j1posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j1negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }

                else if (selectedjoint == j2)
                {
                    j2posarc.GetComponent<MeshRenderer>().enabled = false;
                    j2negarc.GetComponent<MeshRenderer>().enabled = false;

                    j2posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j2negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }

                else if (selectedjoint == j3)
                {
                    j3posarc.GetComponent<MeshRenderer>().enabled = false;
                    j3negarc.GetComponent<MeshRenderer>().enabled = false;

                    j3posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j3negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }

                else if (selectedjoint == j4)
                {
                    j4posarc.GetComponent<MeshRenderer>().enabled = false;
                    j4negarc.GetComponent<MeshRenderer>().enabled = false;

                    j4posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j4negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }

                else if (selectedjoint == j5)
                {
                    j5posarc.GetComponent<MeshRenderer>().enabled = false;
                    j5negarc.GetComponent<MeshRenderer>().enabled = false;

                    j5posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j5negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }

                else if (selectedjoint == j6)
                {
                    j6posarc.GetComponent<MeshRenderer>().enabled = false;
                    j6negarc.GetComponent<MeshRenderer>().enabled = false;

                    j6posarcinv.GetComponent<MeshRenderer>().enabled = true;
                    j6negarcinv.GetComponent<MeshRenderer>().enabled = true;
                }
            }

            if (!invertedon)
            {
                if (selectedjoint == j1)

                {
                    j1posarc.GetComponent<MeshRenderer>().enabled = true;
                    j1negarc.GetComponent<MeshRenderer>().enabled = true;

                    j1posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j1negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }

                else if (selectedjoint == j2)
                {
                    j2posarc.GetComponent<MeshRenderer>().enabled = true;
                    j2negarc.GetComponent<MeshRenderer>().enabled = true;

                    j2posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j2negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }

                else if (selectedjoint == j3)
                {
                    j3posarc.GetComponent<MeshRenderer>().enabled = true;
                    j3negarc.GetComponent<MeshRenderer>().enabled = true;

                    j3posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j3negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }

                else if (selectedjoint == j4)
                {
                    j4posarc.GetComponent<MeshRenderer>().enabled = true;
                    j4negarc.GetComponent<MeshRenderer>().enabled = true;

                    j4posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j4negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }

                else if (selectedjoint == j5)
                {
                    j5posarc.GetComponent<MeshRenderer>().enabled = true;
                    j5negarc.GetComponent<MeshRenderer>().enabled = true;

                    j5posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j5negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }

                else if (selectedjoint == j6)
                {
                    j6posarc.GetComponent<MeshRenderer>().enabled = true;
                    j6negarc.GetComponent<MeshRenderer>().enabled = true;

                    j6posarcinv.GetComponent<MeshRenderer>().enabled = false;
                    j6negarcinv.GetComponent<MeshRenderer>().enabled = false;
                }
            }

        }
    }

    public void RightSideActive()
    {
        leftsideactive = false;
        rightsideactive = true;
    }

    public void LeftSideActive()
    {
        leftsideactive = true;
        rightsideactive = false;
    }

    public void J1HoverExit()
    {

        if (j1canhover)
        {
            j1.GetComponent<MeshRenderer>().material = defaultjointmat;
        }
        else j1.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void J2HoverExit()
    {

        if (j2canhover)
        {
            j2.GetComponent<MeshRenderer>().material = defaultjointmat;
        }
        else j2.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void J3HoverExit()
    {
        if (j3canhover)
        {
            j3.GetComponent<MeshRenderer>().material = defaultjointmat;
        }
        else j3.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void J4HoverExit()
    {
        if (j4canhover)
        {
            j4.GetComponent<MeshRenderer>().material = defaultjointmat;
        }

        else j4.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void J5HoverExit()
    {

        if (j5canhover)
        {
            j5.GetComponent<MeshRenderer>().material = defaultjointmat;
        }

        else j5.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void J6HoverExit()
    {

        if (j6canhover)
        {
            j6.GetComponent<MeshRenderer>().material = defaultjointmat;
        }

        else j6.GetComponent<MeshRenderer>().material = selectedjointmat;
    }

    public void ToggleMasterSlider()
    {
        if (!masterslideron)
        {
            masterslideron = true;
        }

        else
        {
            masterslideron = false;
        }
    }

}
