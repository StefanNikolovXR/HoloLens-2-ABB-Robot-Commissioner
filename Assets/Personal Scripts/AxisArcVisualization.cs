using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AxisArcVisualization : MonoBehaviour
{
    public Shaper2D Base1_LowerBound_Normal, Base1_UpperBound_Normal, Base1_LowerBound_Inverted, Base1_UpperBound_Inverted;
    public Shaper2D Arm2_LowerBound_Normal, Arm2_UpperBound_Normal, Arm2_LowerBound_Inverted, Arm2_UpperBound_Inverted;
    public Shaper2D Arm3_LowerBound_Normal, Arm3_UpperBound_Normal, Arm3_LowerBound_Inverted, Arm3_UpperBound_Inverted;
    public Shaper2D Wrist4_LowerBound_Normal, Wrist4_UpperBound_Normal, Wrist4_LowerBound_Inverted, Wrist4_UpperBound_Inverted;
    public Shaper2D Bend5_LowerBound_Normal, Bend5_UpperBound_Normal, Bend5_LowerBound_Inverted, Bend5_UpperBound_Inverted;
    public Shaper2D Turn6_LowerBound_Inner_Normal, Turn6_UpperBound_Inner_Normal, Turn6_LowerBound_Normal, Turn6_UpperBound_Normal, Turn6_LowerBound_Inverted, Turn6_UpperBound_Inverted, Turn6_UpperBound_Outer_Normal, Turn6_LowerBound_Outer_Normal, Turn6_LowerBound_Outer_Inverted, Turn6_UpperBound_Outer_Inverted, Turn6_LowerBound_Inner_Inverted, Turn6_UpperBound_Inner_Inverted;

    public MeshRenderer Base1_LowerBound_Normal_mesh, Base1_UpperBound_Normal_mesh, Base1_LowerBound_Inverted_mesh, Base1_UpperBound_Inverted_mesh;
    public MeshRenderer Arm2_LowerBound_Normal_mesh, Arm2_UpperBound_Normal_mesh, Arm2_LowerBound_Inverted_mesh, Arm2_UpperBound_Inverted_mesh;
    public MeshRenderer Arm3_LowerBound_Normal_mesh, Arm3_UpperBound_Normal_mesh, Arm3_LowerBound_Inverted_mesh, Arm3_UpperBound_Inverted_mesh;
    public MeshRenderer Wrist4_LowerBound_Normal_mesh, Wrist4_UpperBound_Normal_mesh, Wrist4_LowerBound_Inverted_mesh, Wrist4_UpperBound_Inverted_mesh;
    public MeshRenderer Bend5_LowerBound_Normal_mesh, Bend5_UpperBound_Normal_mesh, Bend5_LowerBound_Inverted_mesh, Bend5_UpperBound_Inverted_mesh;
    public MeshRenderer Turn6_LowerBound_Inner_Normal_mesh, Turn6_UpperBound_Inner_Normal_mesh, Turn6_LowerBound_Normal_mesh, Turn6_UpperBound_Normal_mesh, Turn6_LowerBound_Inverted_mesh, Turn6_UpperBound_Inverted_mesh, Turn6_UpperBound_Outer_Normal_mesh, Turn6_LowerBound_Outer_Normal_mesh, Turn6_LowerBound_Outer_Inverted_mesh, Turn6_UpperBound_Outer_Inverted_mesh, Turn6_LowerBound_Inner_Inverted_mesh, Turn6_UpperBound_Inner_Inverted_mesh;

    public MeshRenderer Base1_FactoryLimit, Arm2_FactoryLimit, Arm3_FactoryLimit, Wrist4_FactoryLimit, Bend5_FactoryLimit, Turn6_FactoryLimit;

    public Color whitecolor = new Color32(255, 255, 255, 255);
    public Color redcolor = new Color32(192, 29, 0, 255);
    public Color tealcolor = new Color32(0, 192, 255, 255);

    public float rot1_lowerbound_num, rot1_upperbound_num, arm2_lowerbound_num, arm2_upperbound_num, arm3_lowerbound_num, arm3_upperbound_num, wrist4_lowerbound_num, wrist4_upperbound_num, bend5_lowerbound_num, bend5_upperbound_num, turn6_lowerbound_num, turn6_upperbound_num;

    public string rot1_lowerbound_text, rot1_upperbound_text, arm2_lowerbound_text, arm2_upperbound_text, arm3_lowerbound_text, arm3_upperbound_text, wrist4_lowerbound_text, wrist4_upperbound_text, bend5_lowerbound_text, bend5_upperbound_text, turn6_lowerbound_text, turn6_upperbound_text;

    public string inverttext, allowtext;

    public bool allowinside, invert;

    public int rot1_arcstatus = 0, arm2_arcstatus = 0, arm3_arcstatus = 0, wrist4_arcstatus = 0, bend5_arcstatus = 0, turn6_arcstatus = 0;

    public MasterSliderData masterscript;

    public FinalAxisValues final;

    public void ProcessfromFinal()
    {
        rot1_lowerbound_num = final.apo_j1lower;
        arm2_lowerbound_num = final.apo_j2lower;
        arm3_lowerbound_num = final.apo_j3lower;
        wrist4_lowerbound_num = final.apo_j4lower;
        bend5_lowerbound_num = final.apo_j5lower;
        turn6_lowerbound_num = final.apo_j6lower;

        rot1_upperbound_num = final.apo_j1upper;
        arm2_upperbound_num = final.apo_j2upper;
        arm3_upperbound_num = final.apo_j3upper;
        wrist4_upperbound_num = final.apo_j4upper;
        bend5_upperbound_num = final.apo_j5upper;
        turn6_upperbound_num = final.apo_j6upper;

        inverttext = final.invert;
        allowtext = final.allow;

        LabelAllAxes();
        ProcessAllAxes();
    }

    public void VisualizeAllLimits()
    {
        VisualizeAxisLimits();
        VisualizeFactoryLimits();
    }

    public void HideAllLimits()
    {
        HideAxisLimits();
        HideFactoryLimits();
    }

    public void ProcessAllAxes()
    {
        ProcessAxisDataJ1();
        ProcessAxisDataJ2();
        ProcessAxisDataJ3();
        ProcessAxisDataJ4();
        ProcessAxisDataJ5();
        ProcessAxisDataJ6();
    }

    public void VisualizeAxisLimits()
    {
        Base1_LowerBound_Normal_mesh.enabled = true;
        Base1_UpperBound_Normal_mesh.enabled = true;
        Base1_LowerBound_Inverted_mesh.enabled = true;
        Base1_UpperBound_Inverted_mesh.enabled = true;

        Arm2_LowerBound_Normal_mesh.enabled = true;
        Arm2_UpperBound_Normal_mesh.enabled = true;
        Arm2_LowerBound_Inverted_mesh.enabled = true;
        Arm2_UpperBound_Inverted_mesh.enabled = true;

        Arm3_LowerBound_Normal_mesh.enabled = true;
        Arm3_UpperBound_Normal_mesh.enabled = true;
        Arm3_LowerBound_Inverted_mesh.enabled = true;
        Arm3_UpperBound_Inverted_mesh.enabled = true;

        Wrist4_LowerBound_Normal_mesh.enabled = true;
        Wrist4_UpperBound_Normal_mesh.enabled = true;
        Wrist4_LowerBound_Inverted_mesh.enabled = true;
        Wrist4_UpperBound_Inverted_mesh.enabled = true;

        Bend5_LowerBound_Normal_mesh.enabled = true;
        Bend5_UpperBound_Normal_mesh.enabled = true;
        Bend5_LowerBound_Inverted_mesh.enabled = true;
        Bend5_UpperBound_Inverted_mesh.enabled = true;

        Turn6_LowerBound_Inner_Normal_mesh.enabled = true;
        Turn6_UpperBound_Inner_Normal_mesh.enabled = true;

        Turn6_LowerBound_Inner_Normal_mesh.enabled = true;
        Turn6_UpperBound_Inner_Normal_mesh.enabled = true;

        Turn6_LowerBound_Normal_mesh.enabled = true;
        Turn6_UpperBound_Normal_mesh.enabled = true;

        Turn6_LowerBound_Outer_Normal_mesh.enabled = true;
        Turn6_UpperBound_Outer_Normal_mesh.enabled = true;

        Turn6_LowerBound_Inverted_mesh.enabled = true;
        Turn6_UpperBound_Inverted_mesh.enabled = true;

        Turn6_LowerBound_Outer_Inverted_mesh.enabled = true;
        Turn6_UpperBound_Outer_Inverted_mesh.enabled = true;

        Turn6_LowerBound_Inner_Inverted_mesh.enabled = true;
        Turn6_UpperBound_Inner_Inverted_mesh.enabled = true;
    }

    public void HideAxisLimits()
    {
        Base1_LowerBound_Normal_mesh.enabled = false;
        Base1_UpperBound_Normal_mesh.enabled = false;
        Base1_LowerBound_Inverted_mesh.enabled = false;
        Base1_UpperBound_Inverted_mesh.enabled = false;

        Arm2_LowerBound_Normal_mesh.enabled = false;
        Arm2_UpperBound_Normal_mesh.enabled = false;
        Arm2_LowerBound_Inverted_mesh.enabled = false;
        Arm2_UpperBound_Inverted_mesh.enabled = false;

        Arm3_LowerBound_Normal_mesh.enabled = false;
        Arm3_UpperBound_Normal_mesh.enabled = false;
        Arm3_LowerBound_Inverted_mesh.enabled = false;
        Arm3_UpperBound_Inverted_mesh.enabled = false;

        Wrist4_LowerBound_Normal_mesh.enabled = false;
        Wrist4_UpperBound_Normal_mesh.enabled = false;
        Wrist4_LowerBound_Inverted_mesh.enabled = false;
        Wrist4_UpperBound_Inverted_mesh.enabled = false;

        Bend5_LowerBound_Normal_mesh.enabled = false;
        Bend5_UpperBound_Normal_mesh.enabled = false;
        Bend5_LowerBound_Inverted_mesh.enabled = false;
        Bend5_UpperBound_Inverted_mesh.enabled = false;

        Turn6_LowerBound_Inner_Normal_mesh.enabled = false;
        Turn6_UpperBound_Inner_Normal_mesh.enabled = false;

        Turn6_LowerBound_Inner_Normal_mesh.enabled = false;
        Turn6_UpperBound_Inner_Normal_mesh.enabled = false;

        Turn6_LowerBound_Normal_mesh.enabled = false;
        Turn6_UpperBound_Normal_mesh.enabled = false;

        Turn6_LowerBound_Outer_Normal_mesh.enabled = false;
        Turn6_UpperBound_Outer_Normal_mesh.enabled = false;

        Turn6_LowerBound_Inverted_mesh.enabled = false;
        Turn6_UpperBound_Inverted_mesh.enabled = false;

        Turn6_LowerBound_Outer_Inverted_mesh.enabled = false;
        Turn6_UpperBound_Outer_Inverted_mesh.enabled = false;

        Turn6_LowerBound_Inner_Inverted_mesh.enabled = false;
        Turn6_UpperBound_Inner_Inverted_mesh.enabled = false;
    }

    public void VisualizeFactoryLimits()
    {
        Base1_FactoryLimit.enabled = true;
        Arm2_FactoryLimit.enabled = true;
        Arm3_FactoryLimit.enabled = true;
        Wrist4_FactoryLimit.enabled = true;
        Bend5_FactoryLimit.enabled = true;
        Turn6_FactoryLimit.enabled = true;

    }

    public void HideFactoryLimits()
    {
        Base1_FactoryLimit.enabled = false;
        Arm2_FactoryLimit.enabled = false;
        Arm3_FactoryLimit.enabled = false;
        Wrist4_FactoryLimit.enabled = false;
        Bend5_FactoryLimit.enabled = false;
        Turn6_FactoryLimit.enabled = false;
   
    }

    public void ProcessAxisDataJ1()
    {

        switch (rot1_arcstatus) {

            case 1:

                Base1_LowerBound_Normal.arcDegrees = Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Normal.arcDegrees = Mathf.Abs(rot1_upperbound_num);

                Base1_LowerBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_upperbound_num);

                J1Status1Colors();
                break;

            case 2:

                Base1_LowerBound_Normal.arcDegrees = Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Normal.arcDegrees = Mathf.Abs(rot1_upperbound_num);

                Base1_LowerBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_lowerbound_num);

                J1Status2Colors();
                break;

            case 3:

                Base1_LowerBound_Normal.arcDegrees = Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Normal.arcDegrees = Mathf.Abs(rot1_upperbound_num);

                Base1_LowerBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_upperbound_num);

                J1Status3Colors();
                break;

            case 4:

                Base1_LowerBound_Normal.arcDegrees = Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Normal.arcDegrees = Mathf.Abs(rot1_upperbound_num);

                Base1_LowerBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_lowerbound_num);
                Base1_UpperBound_Inverted.arcDegrees = 165 - Mathf.Abs(rot1_upperbound_num);

                J1Status4Colors();
                break;

            default:
                break;
                            }
    }


public void ProcessAxisDataJ2()
    {

        switch (arm2_arcstatus)
        {

            case 1:

                Arm2_LowerBound_Normal.arcDegrees = Mathf.Abs(arm2_upperbound_num);
                Arm2_UpperBound_Normal.arcDegrees = Mathf.Abs(arm2_lowerbound_num);

                Arm2_LowerBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_upperbound_num);
                Arm2_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_lowerbound_num);

                J2Status1Colors();
                break;

            case 2:

                Arm2_LowerBound_Normal.arcDegrees = Mathf.Abs(arm2_upperbound_num);
                Arm2_UpperBound_Normal.arcDegrees = Mathf.Abs(arm2_lowerbound_num);

                Arm2_LowerBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_upperbound_num);
                Arm2_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_lowerbound_num);

                J2Status2Colors();
                break;

            case 3:

                Arm2_LowerBound_Normal.arcDegrees = Mathf.Abs(arm2_lowerbound_num);
                Arm2_UpperBound_Normal.arcDegrees = Mathf.Abs(arm2_upperbound_num);

                Arm2_LowerBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_lowerbound_num);
                Arm2_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_upperbound_num);

                J2Status3Colors();
                break;

            case 4:

                Arm2_LowerBound_Normal.arcDegrees = Mathf.Abs(arm2_lowerbound_num);
                Arm2_UpperBound_Normal.arcDegrees = Mathf.Abs(arm2_upperbound_num);

                Arm2_LowerBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_lowerbound_num);
                Arm2_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm2_upperbound_num);

                J2Status4Colors();
                break;

            default:
                break;
        }
    }

    public void ProcessAxisDataJ3()
    {

        switch (arm3_arcstatus)
        {

            case 1:

                Arm3_LowerBound_Normal.arcDegrees = Mathf.Abs(arm3_upperbound_num);
                Arm3_UpperBound_Normal.arcDegrees = Mathf.Abs(arm3_lowerbound_num);

                Arm3_LowerBound_Inverted.arcDegrees = 70 - Mathf.Abs(arm3_upperbound_num);
                Arm3_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm3_lowerbound_num);

                J3Status1Colors();
                break;

            case 2:

                Arm3_LowerBound_Normal.arcDegrees = Mathf.Abs(arm3_upperbound_num);
                Arm3_UpperBound_Normal.arcDegrees = Mathf.Abs(arm3_lowerbound_num);

                Arm3_LowerBound_Inverted.arcDegrees = 70 - Mathf.Abs(arm3_upperbound_num);
                Arm3_UpperBound_Inverted.arcDegrees = 110 - Mathf.Abs(arm3_lowerbound_num); 

                J3Status2Colors();
                break;

            case 3:

                Arm3_LowerBound_Normal.arcDegrees = Mathf.Abs(arm3_lowerbound_num);
                Arm3_UpperBound_Normal.arcDegrees = Mathf.Abs(arm3_upperbound_num);

                Arm3_LowerBound_Inverted.arcDegrees = 100 - Mathf.Abs(arm3_lowerbound_num);
                Arm3_UpperBound_Inverted.arcDegrees = 80 - Mathf.Abs(arm3_upperbound_num);

                J3Status3Colors();
                break;

            case 4:

                Arm3_LowerBound_Normal.arcDegrees = Mathf.Abs(arm3_lowerbound_num);
                Arm3_UpperBound_Normal.arcDegrees = Mathf.Abs(arm3_upperbound_num);

                Arm3_LowerBound_Inverted.arcDegrees = 100 - Mathf.Abs(arm3_lowerbound_num);
                Arm3_UpperBound_Inverted.arcDegrees = 80 - Mathf.Abs(arm3_upperbound_num);

                J3Status4Colors();
                break;

            default:
                break;
        }
    }


    public void ProcessAxisDataJ4()
    {

        switch (wrist4_arcstatus)
        {

            case 1:

                Wrist4_LowerBound_Normal.arcDegrees = Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Normal.arcDegrees = Mathf.Abs(wrist4_upperbound_num);

                Wrist4_LowerBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_upperbound_num);

                J4Status1Colors();
                break;

            case 2:

                Wrist4_LowerBound_Normal.arcDegrees = Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Normal.arcDegrees = Mathf.Abs(wrist4_upperbound_num);

                Wrist4_LowerBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_upperbound_num);

                J4Status2Colors();
                break;

            case 3:

                Wrist4_LowerBound_Normal.arcDegrees = Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Normal.arcDegrees = Mathf.Abs(wrist4_upperbound_num);

                Wrist4_LowerBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_upperbound_num);

                J4Status3Colors();
                break;

            case 4:

                Wrist4_LowerBound_Normal.arcDegrees = Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Normal.arcDegrees = Mathf.Abs(wrist4_upperbound_num);

                Wrist4_LowerBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_lowerbound_num);
                Wrist4_UpperBound_Inverted.arcDegrees = 160 - Mathf.Abs(wrist4_upperbound_num);

                J4Status4Colors();
                break;

            default:
                break;
        }
    }


    public void ProcessAxisDataJ5()
    {

        switch (bend5_arcstatus)
        {

            case 1:

                Bend5_LowerBound_Normal.arcDegrees = Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Normal.arcDegrees = Mathf.Abs(bend5_upperbound_num);

                Bend5_LowerBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_upperbound_num);

                J5Status1Colors();
                break;

            case 2:

                Bend5_LowerBound_Normal.arcDegrees = Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Normal.arcDegrees = Mathf.Abs(bend5_upperbound_num);

                Bend5_LowerBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_upperbound_num);

                J5Status2Colors();
                break;

            case 3:

                Bend5_LowerBound_Normal.arcDegrees = Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Normal.arcDegrees = Mathf.Abs(bend5_upperbound_num);

                Bend5_LowerBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_upperbound_num);

                J5Status3Colors();
                break;

            case 4:

                Bend5_LowerBound_Normal.arcDegrees = Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Normal.arcDegrees = Mathf.Abs(bend5_upperbound_num);

                Bend5_LowerBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_lowerbound_num);
                Bend5_UpperBound_Inverted.arcDegrees = 120 - Mathf.Abs(bend5_upperbound_num);

                J5Status4Colors();
                break;

            default:
                break;
        }
    }

    public void ProcessAxisDataJ6()
    {
        switch (turn6_arcstatus)
        {

            case 1:

                if (turn6_lowerbound_num <= -360)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_LowerBound_Normal.arcDegrees = 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 180;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inverted.arcDegrees = 0;
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_upperbound_num >= 360)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_UpperBound_Normal.arcDegrees = 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 180;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_UpperBound_Inverted.arcDegrees = 0;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_lowerbound_num > -360 && turn6_lowerbound_num <= -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_upperbound_num < 360 && turn6_lowerbound_num >= 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = Mathf.Abs(turn6_upperbound_num) - 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_upperbound_num);
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_lowerbound_num > -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 180;

                    Turn6_LowerBound_Inner_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180 - Mathf.Abs(turn6_lowerbound_num);
                }

                if (turn6_upperbound_num < 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 180;

                    Turn6_UpperBound_Inner_Normal.arcDegrees = turn6_upperbound_num;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180 - turn6_upperbound_num;
                }
                J6Status1Colors();
                break;

            case 2:
                if (turn6_lowerbound_num <= -360)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_LowerBound_Normal.arcDegrees = 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 180;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inverted.arcDegrees = 0;
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_upperbound_num >= 360)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_UpperBound_Normal.arcDegrees = 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 180;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_UpperBound_Inverted.arcDegrees = 0;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_lowerbound_num > -360 && turn6_lowerbound_num <= -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_upperbound_num < 360 && turn6_lowerbound_num >= 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = Mathf.Abs(turn6_upperbound_num) - 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_upperbound_num);
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_lowerbound_num > -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 180;

                    Turn6_LowerBound_Inner_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180 - Mathf.Abs(turn6_lowerbound_num);
                }

                if (turn6_upperbound_num < 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 180;

                    Turn6_UpperBound_Inner_Normal.arcDegrees = turn6_upperbound_num;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180 - turn6_upperbound_num;
                }
                J6Status2Colors();
                break;

            case 3:

                if (turn6_lowerbound_num <= -360)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_LowerBound_Normal.arcDegrees = 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 180;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inverted.arcDegrees = 0;
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_upperbound_num >= 360)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_UpperBound_Normal.arcDegrees = 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 180;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_UpperBound_Inverted.arcDegrees = 0;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_lowerbound_num > -360 && turn6_lowerbound_num <= -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_upperbound_num < 360 && turn6_lowerbound_num >= 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = Mathf.Abs(turn6_upperbound_num) - 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_upperbound_num);
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_lowerbound_num > -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 180;

                    Turn6_LowerBound_Inner_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180 - Mathf.Abs(turn6_lowerbound_num);
                }

                if (turn6_upperbound_num < 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 180;

                    Turn6_UpperBound_Inner_Normal.arcDegrees = turn6_upperbound_num;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180 - turn6_upperbound_num;
                }
                J6Status3Colors();
                break;

            case 4:
                if (turn6_lowerbound_num <= -360)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_LowerBound_Normal.arcDegrees = 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 180;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inverted.arcDegrees = 0;
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_upperbound_num >= 360)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 360;
                    Turn6_UpperBound_Normal.arcDegrees = 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 180;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 400 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_UpperBound_Inverted.arcDegrees = 0;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 0;
                }

                if (turn6_lowerbound_num > -360 && turn6_lowerbound_num <= -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num) - 180;
                    Turn6_LowerBound_Inner_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_upperbound_num < 360 && turn6_lowerbound_num >= 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = Mathf.Abs(turn6_upperbound_num) - 180;
                    Turn6_UpperBound_Inner_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 360 - Mathf.Abs(turn6_upperbound_num);
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180;
                }

                if (turn6_lowerbound_num > -180)
                {
                    Turn6_LowerBound_Outer_Normal.arcDegrees = 0;
                    Turn6_LowerBound_Normal.arcDegrees = 0;

                    Turn6_LowerBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_LowerBound_Inverted.arcDegrees = 180;

                    Turn6_LowerBound_Inner_Normal.arcDegrees = Mathf.Abs(turn6_lowerbound_num);
                    Turn6_LowerBound_Inner_Inverted.arcDegrees = 180 - Mathf.Abs(turn6_lowerbound_num);
                }

                if (turn6_upperbound_num < 180)
                {
                    Turn6_UpperBound_Outer_Normal.arcDegrees = 0;
                    Turn6_UpperBound_Normal.arcDegrees = 0;

                    Turn6_UpperBound_Outer_Inverted.arcDegrees = 40;
                    Turn6_UpperBound_Inverted.arcDegrees = 180;

                    Turn6_UpperBound_Inner_Normal.arcDegrees = turn6_upperbound_num;
                    Turn6_UpperBound_Inner_Inverted.arcDegrees = 180 - turn6_upperbound_num;
                }
                J6Status4Colors();
                break;
        }
    }

    public void LabelAllAxes()
    {
        if(inverttext == "Normal")
        {
            invert = false;
        }

        else if (inverttext == "Inverted")
        {
            invert = true;
        }

        if (allowtext == "Allowed")
        {
            allowinside = true;
        }

        else if (allowtext == "Not Allowed")
        {
            allowinside = false;
        }

        if (allowinside & !invert) {
            rot1_arcstatus = 1;
            arm2_arcstatus = 1;
            arm3_arcstatus = 1;
            wrist4_arcstatus = 1;
            bend5_arcstatus = 1;
            turn6_arcstatus = 1;
        }

        if (allowinside & invert)
        {
            rot1_arcstatus = 2;
            arm2_arcstatus = 2;
            arm3_arcstatus = 2;
            wrist4_arcstatus = 2;
            bend5_arcstatus = 2;
            turn6_arcstatus = 2;
        }

        if (!allowinside & !invert)
        {
            rot1_arcstatus = 3;
            arm2_arcstatus = 3;
            arm3_arcstatus = 3;
            wrist4_arcstatus = 3;
            bend5_arcstatus = 3;
            turn6_arcstatus = 3;
        }

        if (!allowinside & invert)
        {
            rot1_arcstatus = 4;
            arm2_arcstatus = 4;
            arm3_arcstatus = 4;
            wrist4_arcstatus = 4;
            bend5_arcstatus = 4;
            turn6_arcstatus = 4;
        }
    }

    public void J1Status1Colors()
    {
        Base1_LowerBound_Normal.innerColor = whitecolor;
        Base1_UpperBound_Normal.innerColor = whitecolor;
        Base1_LowerBound_Normal.outerColor = whitecolor;
        Base1_UpperBound_Normal.outerColor = whitecolor;

        Base1_LowerBound_Inverted.innerColor = redcolor;
        Base1_UpperBound_Inverted.innerColor = redcolor;
        Base1_LowerBound_Inverted.outerColor = redcolor;
        Base1_UpperBound_Inverted.outerColor = redcolor;
    }

    public void J1Status2Colors()
    {
        Base1_LowerBound_Normal.innerColor = redcolor;
        Base1_UpperBound_Normal.innerColor = redcolor;
        Base1_LowerBound_Normal.outerColor = redcolor;
        Base1_UpperBound_Normal.outerColor = redcolor;

        Base1_LowerBound_Inverted.innerColor = whitecolor;
        Base1_UpperBound_Inverted.innerColor = whitecolor;
        Base1_LowerBound_Inverted.outerColor = whitecolor;
        Base1_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J1Status3Colors()
    {
        Base1_LowerBound_Normal.innerColor = tealcolor;
        Base1_UpperBound_Normal.innerColor = tealcolor;
        Base1_LowerBound_Normal.outerColor = tealcolor;
        Base1_UpperBound_Normal.outerColor = tealcolor;

        Base1_LowerBound_Inverted.innerColor = whitecolor;
        Base1_UpperBound_Inverted.innerColor = whitecolor;
        Base1_LowerBound_Inverted.outerColor = whitecolor;
        Base1_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J1Status4Colors()
    {
        Base1_LowerBound_Normal.innerColor = whitecolor;
        Base1_UpperBound_Normal.innerColor = whitecolor;
        Base1_LowerBound_Normal.outerColor = whitecolor;
        Base1_UpperBound_Normal.outerColor = whitecolor;

        Base1_LowerBound_Inverted.innerColor = tealcolor;
        Base1_UpperBound_Inverted.innerColor = tealcolor;
        Base1_LowerBound_Inverted.outerColor = tealcolor;
        Base1_UpperBound_Inverted.outerColor = tealcolor;
    }

    public void J2Status1Colors()
    {
        Arm2_LowerBound_Normal.innerColor = whitecolor;
        Arm2_UpperBound_Normal.innerColor = whitecolor;
        Arm2_LowerBound_Normal.outerColor = whitecolor;
        Arm2_UpperBound_Normal.outerColor = whitecolor;

        Arm2_LowerBound_Inverted.innerColor = redcolor;
        Arm2_UpperBound_Inverted.innerColor = redcolor;
        Arm2_LowerBound_Inverted.outerColor = redcolor;
        Arm2_UpperBound_Inverted.outerColor = redcolor;
    }

    public void J2Status2Colors()
    {
        Arm2_LowerBound_Normal.innerColor = redcolor;
        Arm2_UpperBound_Normal.innerColor = redcolor;
        Arm2_LowerBound_Normal.outerColor = redcolor;
        Arm2_UpperBound_Normal.outerColor = redcolor;

        Arm2_LowerBound_Inverted.innerColor = whitecolor;
        Arm2_UpperBound_Inverted.innerColor = whitecolor;
        Arm2_LowerBound_Inverted.outerColor = whitecolor;
        Arm2_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J2Status3Colors()
    {
        Arm2_LowerBound_Normal.innerColor = tealcolor;
        Arm2_UpperBound_Normal.innerColor = tealcolor;
        Arm2_LowerBound_Normal.outerColor = tealcolor;
        Arm2_UpperBound_Normal.outerColor = tealcolor;

        Arm2_LowerBound_Inverted.innerColor = whitecolor;
        Arm2_UpperBound_Inverted.innerColor = whitecolor;
        Arm2_LowerBound_Inverted.outerColor = whitecolor;
        Arm2_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J2Status4Colors()
    {
        Arm2_LowerBound_Normal.innerColor = whitecolor;
        Arm2_UpperBound_Normal.innerColor = whitecolor;
        Arm2_LowerBound_Normal.outerColor = whitecolor;
        Arm2_UpperBound_Normal.outerColor = whitecolor;

        Arm2_LowerBound_Inverted.innerColor = tealcolor;
        Arm2_UpperBound_Inverted.innerColor = tealcolor;
        Arm2_LowerBound_Inverted.outerColor = tealcolor;
        Arm2_UpperBound_Inverted.outerColor = tealcolor;
    }

    public void J3Status1Colors()
    {
        Arm3_LowerBound_Normal.innerColor = whitecolor;
        Arm3_UpperBound_Normal.innerColor = whitecolor;
        Arm3_LowerBound_Normal.outerColor = whitecolor;
        Arm3_UpperBound_Normal.outerColor = whitecolor;

        Arm3_LowerBound_Inverted.innerColor = redcolor;
        Arm3_UpperBound_Inverted.innerColor = redcolor;
        Arm3_LowerBound_Inverted.outerColor = redcolor;
        Arm3_UpperBound_Inverted.outerColor = redcolor;
    }

    public void J3Status2Colors()
    {
        Arm3_LowerBound_Normal.innerColor = redcolor;
        Arm3_UpperBound_Normal.innerColor = redcolor;
        Arm3_LowerBound_Normal.outerColor = redcolor;
        Arm3_UpperBound_Normal.outerColor = redcolor;

        Arm3_LowerBound_Inverted.innerColor = whitecolor;
        Arm3_UpperBound_Inverted.innerColor = whitecolor;
        Arm3_LowerBound_Inverted.outerColor = whitecolor;
        Arm3_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J3Status3Colors()
    {
        Arm3_LowerBound_Normal.innerColor = tealcolor;
        Arm3_UpperBound_Normal.innerColor = tealcolor;
        Arm3_LowerBound_Normal.outerColor = tealcolor;
        Arm3_UpperBound_Normal.outerColor = tealcolor;

        Arm3_LowerBound_Inverted.innerColor = whitecolor;
        Arm3_UpperBound_Inverted.innerColor = whitecolor;
        Arm3_LowerBound_Inverted.outerColor = whitecolor;
        Arm3_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J3Status4Colors()
    {
        Arm3_LowerBound_Normal.innerColor = whitecolor;
        Arm3_UpperBound_Normal.innerColor = whitecolor;
        Arm3_LowerBound_Normal.outerColor = whitecolor;
        Arm3_UpperBound_Normal.outerColor = whitecolor;

        Arm3_LowerBound_Inverted.innerColor = tealcolor;
        Arm3_UpperBound_Inverted.innerColor = tealcolor;
        Arm3_LowerBound_Inverted.outerColor = tealcolor;
        Arm3_UpperBound_Inverted.outerColor = tealcolor;
    }

    public void J4Status1Colors()
    {
        Wrist4_LowerBound_Normal.innerColor = whitecolor;
        Wrist4_UpperBound_Normal.innerColor = whitecolor;
        Wrist4_LowerBound_Normal.outerColor = whitecolor;
        Wrist4_UpperBound_Normal.outerColor = whitecolor;

        Wrist4_LowerBound_Inverted.innerColor = redcolor;
        Wrist4_UpperBound_Inverted.innerColor = redcolor;
        Wrist4_LowerBound_Inverted.outerColor = redcolor;
        Wrist4_UpperBound_Inverted.outerColor = redcolor;
    }

    public void J4Status2Colors()
    {
        Wrist4_LowerBound_Normal.innerColor = redcolor;
        Wrist4_UpperBound_Normal.innerColor = redcolor;
        Wrist4_LowerBound_Normal.outerColor = redcolor;
        Wrist4_UpperBound_Normal.outerColor = redcolor;

        Wrist4_LowerBound_Inverted.innerColor = whitecolor;
        Wrist4_UpperBound_Inverted.innerColor = whitecolor;
        Wrist4_LowerBound_Inverted.outerColor = whitecolor;
        Wrist4_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J4Status3Colors()
    {
        Wrist4_LowerBound_Normal.innerColor = tealcolor;
        Wrist4_UpperBound_Normal.innerColor = tealcolor;
        Wrist4_LowerBound_Normal.outerColor = tealcolor;
        Wrist4_UpperBound_Normal.outerColor = tealcolor;

        Wrist4_LowerBound_Inverted.innerColor = whitecolor;
        Wrist4_UpperBound_Inverted.innerColor = whitecolor;
        Wrist4_LowerBound_Inverted.outerColor = whitecolor;
        Wrist4_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J4Status4Colors()
    {
        Wrist4_LowerBound_Normal.innerColor = whitecolor;
        Wrist4_UpperBound_Normal.innerColor = whitecolor;
        Wrist4_LowerBound_Normal.outerColor = whitecolor;
        Wrist4_UpperBound_Normal.outerColor = whitecolor;

        Wrist4_LowerBound_Inverted.innerColor = tealcolor;
        Wrist4_UpperBound_Inverted.innerColor = tealcolor;
        Wrist4_LowerBound_Inverted.outerColor = tealcolor;
        Wrist4_UpperBound_Inverted.outerColor = tealcolor;
    }

    public void J5Status1Colors()
    {
        Bend5_LowerBound_Normal.innerColor = whitecolor;
        Bend5_UpperBound_Normal.innerColor = whitecolor;
        Bend5_LowerBound_Normal.outerColor = whitecolor;
        Bend5_UpperBound_Normal.outerColor = whitecolor;

        Bend5_LowerBound_Inverted.innerColor = redcolor;
        Bend5_UpperBound_Inverted.innerColor = redcolor;
        Bend5_LowerBound_Inverted.outerColor = redcolor;
        Bend5_UpperBound_Inverted.outerColor = redcolor;
    }

    public void J5Status2Colors()
    {
        Bend5_LowerBound_Normal.innerColor = redcolor;
        Bend5_UpperBound_Normal.innerColor = redcolor;
        Bend5_LowerBound_Normal.outerColor = redcolor;
        Bend5_UpperBound_Normal.outerColor = redcolor;

        Bend5_LowerBound_Inverted.innerColor = whitecolor;
        Bend5_UpperBound_Inverted.innerColor = whitecolor;
        Bend5_LowerBound_Inverted.outerColor = whitecolor;
        Bend5_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J5Status3Colors()
    {
        Bend5_LowerBound_Normal.innerColor = tealcolor;
        Bend5_UpperBound_Normal.innerColor = tealcolor;
        Bend5_LowerBound_Normal.outerColor = tealcolor;
        Bend5_UpperBound_Normal.outerColor = tealcolor;

        Bend5_LowerBound_Inverted.innerColor = whitecolor;
        Bend5_UpperBound_Inverted.innerColor = whitecolor;
        Bend5_LowerBound_Inverted.outerColor = whitecolor;
        Bend5_UpperBound_Inverted.outerColor = whitecolor;
    }

    public void J5Status4Colors()
    {
        Bend5_LowerBound_Normal.innerColor = whitecolor;
        Bend5_UpperBound_Normal.innerColor = whitecolor;
        Bend5_LowerBound_Normal.outerColor = whitecolor;
        Bend5_UpperBound_Normal.outerColor = whitecolor;

        Bend5_LowerBound_Inverted.innerColor = tealcolor;
        Bend5_UpperBound_Inverted.innerColor = tealcolor;
        Bend5_LowerBound_Inverted.outerColor = tealcolor;
        Bend5_UpperBound_Inverted.outerColor = tealcolor;
    }

    public void J6Status1Colors()
    {
       Turn6_LowerBound_Inner_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Inner_Normal.outerColor = whitecolor;
        Turn6_UpperBound_Inner_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Inner_Normal.outerColor = whitecolor;

        Turn6_LowerBound_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Normal.outerColor = whitecolor;
        Turn6_UpperBound_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Normal.outerColor = whitecolor;

        Turn6_UpperBound_Outer_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Outer_Normal.outerColor = whitecolor;
        Turn6_LowerBound_Outer_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Outer_Normal.outerColor = whitecolor;

        Turn6_LowerBound_Inverted.innerColor = redcolor;
        Turn6_LowerBound_Inverted.outerColor = redcolor;
        Turn6_UpperBound_Inverted.innerColor = redcolor;
        Turn6_UpperBound_Inverted.outerColor = redcolor;

        Turn6_LowerBound_Outer_Inverted.innerColor = redcolor;
        Turn6_LowerBound_Outer_Inverted.outerColor = redcolor;
        Turn6_UpperBound_Outer_Inverted.innerColor = redcolor;
        Turn6_UpperBound_Outer_Inverted.outerColor = redcolor;

        Turn6_LowerBound_Inner_Inverted.innerColor = redcolor;
        Turn6_LowerBound_Inner_Inverted.outerColor = redcolor;
        Turn6_UpperBound_Inner_Inverted.innerColor = redcolor;
        Turn6_UpperBound_Inner_Inverted.outerColor = redcolor;
    }

    public void J6Status2Colors()
    {
        Turn6_LowerBound_Inner_Normal.innerColor = redcolor;
        Turn6_LowerBound_Inner_Normal.outerColor = redcolor;
        Turn6_UpperBound_Inner_Normal.innerColor = redcolor;
        Turn6_UpperBound_Inner_Normal.outerColor = redcolor;

        Turn6_LowerBound_Normal.innerColor = redcolor;
        Turn6_LowerBound_Normal.outerColor = redcolor;
        Turn6_UpperBound_Normal.innerColor = redcolor;
        Turn6_UpperBound_Normal.outerColor = redcolor;

        Turn6_UpperBound_Outer_Normal.innerColor = redcolor;
        Turn6_UpperBound_Outer_Normal.outerColor = redcolor;
        Turn6_LowerBound_Outer_Normal.innerColor = redcolor;
        Turn6_LowerBound_Outer_Normal.outerColor = redcolor;

        Turn6_LowerBound_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Inverted.outerColor = whitecolor;

        Turn6_LowerBound_Outer_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Outer_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Outer_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Outer_Inverted.outerColor = whitecolor;

        Turn6_LowerBound_Inner_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Inner_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Inner_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Inner_Inverted.outerColor = whitecolor;
    }

    public void J6Status3Colors()
    {
        Turn6_LowerBound_Inner_Normal.innerColor = tealcolor;
        Turn6_LowerBound_Inner_Normal.outerColor = tealcolor;
        Turn6_UpperBound_Inner_Normal.innerColor = tealcolor;
        Turn6_UpperBound_Inner_Normal.outerColor = tealcolor;

        Turn6_LowerBound_Normal.innerColor = tealcolor;
        Turn6_LowerBound_Normal.outerColor = tealcolor;
        Turn6_UpperBound_Normal.innerColor = tealcolor;
        Turn6_UpperBound_Normal.outerColor = tealcolor;

        Turn6_UpperBound_Outer_Normal.innerColor = tealcolor;
        Turn6_UpperBound_Outer_Normal.outerColor = tealcolor;
        Turn6_LowerBound_Outer_Normal.innerColor = tealcolor;
        Turn6_LowerBound_Outer_Normal.outerColor = tealcolor;

        Turn6_LowerBound_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Inverted.outerColor = whitecolor;

        Turn6_LowerBound_Outer_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Outer_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Outer_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Outer_Inverted.outerColor = whitecolor;

        Turn6_LowerBound_Inner_Inverted.innerColor = whitecolor;
        Turn6_LowerBound_Inner_Inverted.outerColor = whitecolor;
        Turn6_UpperBound_Inner_Inverted.innerColor = whitecolor;
        Turn6_UpperBound_Inner_Inverted.outerColor = whitecolor;
    }

    public void J6Status4Colors()
    {
        Turn6_LowerBound_Inner_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Inner_Normal.outerColor = whitecolor;
        Turn6_UpperBound_Inner_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Inner_Normal.outerColor = whitecolor;

        Turn6_LowerBound_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Normal.outerColor = whitecolor;
        Turn6_UpperBound_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Normal.outerColor = whitecolor;

        Turn6_UpperBound_Outer_Normal.innerColor = whitecolor;
        Turn6_UpperBound_Outer_Normal.outerColor = whitecolor;
        Turn6_LowerBound_Outer_Normal.innerColor = whitecolor;
        Turn6_LowerBound_Outer_Normal.outerColor = whitecolor;

        Turn6_LowerBound_Inverted.innerColor = tealcolor;
        Turn6_LowerBound_Inverted.outerColor = tealcolor;
        Turn6_UpperBound_Inverted.innerColor = tealcolor;
        Turn6_UpperBound_Inverted.outerColor = tealcolor;

        Turn6_LowerBound_Outer_Inverted.innerColor = tealcolor;
        Turn6_LowerBound_Outer_Inverted.outerColor = tealcolor;
        Turn6_UpperBound_Outer_Inverted.innerColor = tealcolor;
        Turn6_UpperBound_Outer_Inverted.outerColor = tealcolor;

        Turn6_LowerBound_Inner_Inverted.innerColor = tealcolor;
        Turn6_LowerBound_Inner_Inverted.outerColor = tealcolor;
        Turn6_UpperBound_Inner_Inverted.innerColor = tealcolor;
        Turn6_UpperBound_Inner_Inverted.outerColor = tealcolor;
    }

}

