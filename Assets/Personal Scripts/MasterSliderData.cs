using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using Lean.Transition;
using Lean.Transition.Method;

public class MasterSliderData : MonoBehaviour
{

    public GameObject irb, j1, j2, j3, j4, j5, j6;

    public bool j1_on, j2_on, j3_on, j4_on, j5_on, j6_on;

    public bool factory, apo, lower, upper, sst, custom;

    public int sliderstatus;

    public PinchSlider slider;

    private Quaternion currentRot, targetRot;

    private float j1rot, j2rot, j3rot, j4rot, j5rot, j6rot;

    public Rot1FactoryLimit factorylimit;

    public ToggleRot1 togglerot1;

    public FinalAxisValues final;

    public TextMeshPro minvalue, maxvalue, currvalue, currentrange;

    public TMP_InputField custommin, custommax;

    public LeanRotateJoints leanrotate;

    public GameObject base1_sst, arm2_sst, arm3_sst, wrist4_sst, bend5_sst, turn6_sst;

    private float storedj1, storedj2, storedj3, storedj4, storedj5, storedj6;

    public BoxCollider sliderbox;

    IEnumerator WaitToSetupSlider()
    {
        yield return new WaitForSeconds(2f);
        slider.SliderValue = 0;
        sliderbox.enabled = true;
    }

    public void SetupSlider()
    {
        switch (sliderstatus)
        {
            case 1:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-165, 165, j1.transform.localEulerAngles.y);
                minvalue.text = "-165°";
                maxvalue.text = "165°";
              
                currvalue.text = $"{Mathf.InverseLerp(-165, 165, j1.transform.localEulerAngles.y)*330 - 165:F2}" + "°";
                break;

            case 2:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-110, 110, j2.transform.localEulerAngles.z);
                minvalue.text = "-110°";
                maxvalue.text = "110°";
        
                currvalue.text = $"{Mathf.InverseLerp(-110, 110, j2.transform.localEulerAngles.z) * 220 - 110:F2}" + "°";
                break;

            case 3:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-110, 70, j3.transform.localEulerAngles.z);
                minvalue.text = "-110°";
                maxvalue.text = "70°";
                
                currvalue.text = $"{Mathf.InverseLerp(-110, 70, j3.transform.localEulerAngles.z) * 180 - 70:F2}" + "°";
                break;

            case 4:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-160, 160, j4.transform.localEulerAngles.x);
                minvalue.text = "-160°";
                maxvalue.text = "160°";
     
                currvalue.text = $"{Mathf.InverseLerp(-160, 160, j4.transform.localEulerAngles.x) * 320 - 160:F2}" + "°";
                break;

            case 5:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-120, 120, j5.transform.localEulerAngles.z);
                minvalue.text = "-120°";
                maxvalue.text = "120°";
              
                currvalue.text = $"{Mathf.InverseLerp(-120, 120, j5.transform.localEulerAngles.z) * 240 - 120:F2}" + "°";
                break;

            case 6:
                final.FixSlider();
                slider.SliderValue = Mathf.InverseLerp(-400, 400, j6.transform.localEulerAngles.x);
                minvalue.text = "-400°";
                maxvalue.text = "400°";
        
                currvalue.text = $"{Mathf.InverseLerp(-400, 400, j6.transform.localEulerAngles.x) - 400:F2}" + "°";
                break;

            case 7:
                final.J1_CheckValues();
                minvalue.text = $"{final.apo_j1lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j1upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ1(final.apo_j1lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j1lower:F2}" + "°";
                break;

            case 8:
                final.J2_CheckValues();
                minvalue.text = $"{final.apo_j2lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j2upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ2(final.apo_j2lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j2lower:F2}" + "°";
                break;

            case 9:
                final.J3_CheckValues();
                minvalue.text = $"{final.apo_j3lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j3upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ3(final.apo_j3lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j3lower:F2}" + "°";
                break;

            case 10:
                final.J4_CheckValues();
                minvalue.text = $"{final.apo_j4lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j4upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ4(final.apo_j4lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j4lower:F2}" + "°";
                break;

            case 11:
                final.J5_CheckValues();
                minvalue.text = $"{final.apo_j5lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j5upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ5(final.apo_j5lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j5lower:F2}" + "°";
                break;

            case 12:
                final.J6_CheckValues();
                minvalue.text = $"{final.apo_j6lower:F2}" + "°";
                maxvalue.text = $"{final.apo_j6upper:F2}" + "°";
                sliderbox.enabled = false;
                leanrotate.MoveJ6(final.apo_j6lower);
                StartCoroutine(WaitToSetupSlider());
                currvalue.text = $"{final.apo_j6lower:F2}" + "°";
                break;

            case 13:
                final.J1_CheckValues();
                minvalue.text = "-165°";
                maxvalue.text = $"{final.apo_j1lower:F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ1(-165);
                currvalue.text = "-165°";
                break;

            case 14:
                final.J2_CheckValues();
                minvalue.text = "-110°";
                maxvalue.text = $"{final.apo_j2lower:F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ2(-110);
                currvalue.text = "-110°";
                break;

            case 15:
                final.J3_CheckValues();
                minvalue.text = "-110°";
                maxvalue.text = $"{final.apo_j3lower:F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ3(-110);
                currvalue.text = "-110°";
                break;

            case 16:
                final.J4_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = "-160°";
                maxvalue.text = $"{final.apo_j4lower:F2}" + "°";
                leanrotate.MoveJ4(-160);
                currvalue.text = "-160°";
                break;

            case 17:
                final.J5_CheckValues();
                minvalue.text = "-120°";
                maxvalue.text = $"{final.apo_j5lower:F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ5(-120);
                currvalue.text = "-120°";
                break;

            case 18:
                final.J6_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = "-400°";
                maxvalue.text = $"{final.apo_j6lower:F2}" + "°";
                leanrotate.MoveJ6(-400);
                currvalue.text = "-400°";
                break;

            case 19:
                final.J1_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j1upper:F2}" + "°"; 
                maxvalue.text = "165°";
                leanrotate.MoveJ1(final.apo_j1upper);
                currvalue.text = $"{final.apo_j1upper:F2}" + "°";
                break;

            case 20:
                final.J2_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j2upper:F2}" + "°";
                maxvalue.text = "110°";
                leanrotate.MoveJ2(final.apo_j2upper);
                currvalue.text = $"{final.apo_j2upper:F2}" + "°";
                break;

            case 21:
                final.J3_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j3upper:F2}" + "°";
                maxvalue.text = "70°";
                leanrotate.MoveJ3(final.apo_j3upper);
                currvalue.text = $"{final.apo_j3upper:F2}" + "°";
                break;

            case 22:
                final.J4_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j4upper:F2}" + "°";
                maxvalue.text = "160°";
                leanrotate.MoveJ4(final.apo_j4upper);
                currvalue.text = $"{final.apo_j4upper:F2}" + "°";
                break;

            case 23:
                final.J5_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j5upper:F2}" + "°";
                maxvalue.text = "120°";
                leanrotate.MoveJ5(final.apo_j5upper);
                currvalue.text = $"{final.apo_j5upper:F2}" + "°";
                break;

            case 24:
                final.J6_CheckValues();
                StartCoroutine(WaitToSetupSlider());
                minvalue.text = $"{final.apo_j6upper:F2}" + "°";
                maxvalue.text = "400°";
                leanrotate.MoveJ6(final.apo_j6upper);
                currvalue.text = $"{final.apo_j6upper:F2}" + "°";
                break;

            case 25:
              
                storedj1 = j1.transform.localEulerAngles.y;
                minvalue.text = $"{(j1.transform.localEulerAngles.y - final.sst_j1 / 2):F2}" + "°";
                maxvalue.text = $"{(j1.transform.localEulerAngles.y + final.sst_j1 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ1(j1.transform.localEulerAngles.y - final.sst_j1 / 2);
                base1_sst.transform.parent = irb.transform;
                currvalue.text = $"{j1.transform.localEulerAngles.y - final.sst_j1 / 2:F2}" + "°";
                break;

            case 26:
              
                minvalue.text = $"{(j2.transform.localEulerAngles.z - final.sst_j2 / 2):F2}" + "°";
                maxvalue.text = $"{(j2.transform.localEulerAngles.z + final.sst_j2 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ2(j2.transform.localEulerAngles.z - final.sst_j2 / 2);
                arm2_sst.transform.parent = j1.transform;
                currvalue.text = $"{j2.transform.localEulerAngles.z - final.sst_j2 / 2:F2}" + "°";
                break;

            case 27:
                
                minvalue.text = $"{(j3.transform.localEulerAngles.z - final.sst_j3 / 2):F2}" + "°";
                maxvalue.text = $"{(j3.transform.localEulerAngles.z + final.sst_j3 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ3(j3.transform.localEulerAngles.z - final.sst_j3 / 2);
                currvalue.text = $"{j3.transform.localEulerAngles.z - final.sst_j3 / 2:F2}" + "°";
                arm3_sst.transform.parent = j2.transform;
                break;

            case 28:
                final.FixSlider();
                minvalue.text = $"{(j4.transform.localEulerAngles.x - final.sst_j4 / 2):F2}" + "°";
                maxvalue.text = $"{(j4.transform.localEulerAngles.x + final.sst_j4 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ4(j4.transform.localEulerAngles.x - final.sst_j4 / 2);
                currvalue.text = $"{j4.transform.localEulerAngles.x - final.sst_j4 / 2:F2}" + "°";
                wrist4_sst.transform.parent = j3.transform;
                break;

            case 29:
                
                minvalue.text = $"{(j5.transform.localEulerAngles.z - final.sst_j5 / 2):F2}" + "°";
                maxvalue.text = $"{(j5.transform.localEulerAngles.z + final.sst_j5 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ5(j5.transform.localEulerAngles.z - final.sst_j5 / 2);
                currvalue.text = $"{j5.transform.localEulerAngles.z - final.sst_j5 / 2:F2}" + "°";
                bend5_sst.transform.parent = j4.transform;
                break;

            case 30:
                final.FixSlider();
                minvalue.text = $"{(j6.transform.localEulerAngles.x - final.sst_j6 / 2):F2}" + "°";
                maxvalue.text = $"{(j6.transform.localEulerAngles.x + final.sst_j6 / 2):F2}" + "°";
                StartCoroutine(WaitToSetupSlider());
                leanrotate.MoveJ6(j6.transform.localEulerAngles.x - final.sst_j6 / 2);
                currvalue.text = $"{j6.transform.localEulerAngles.x - final.sst_j6 / 2:F2}" + "°";
                turn6_sst.transform.parent = j5.transform;
                break;

            case 31:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
            
                leanrotate.MoveJ1(float.Parse(custommin.text));
                break;

            case 32:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
            
                leanrotate.MoveJ2(float.Parse(custommin.text));
                break;

            case 33:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
            
                leanrotate.MoveJ3(float.Parse(custommin.text));
                break;

            case 34:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
         
                leanrotate.MoveJ4(float.Parse(custommin.text));
                break;

            case 35:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
       
                leanrotate.MoveJ5(float.Parse(custommin.text));
                break;

            case 36:
                final.FixSlider();
                minvalue.text = $"{(float.Parse(custommin.text)):F2}" + "°";
                maxvalue.text = $"{(float.Parse(custommax.text)):F2}" + "°";
           
                leanrotate.MoveJ6(float.Parse(custommin.text));
                break;

            default:
                break;
        }
    }

    public void SliderMotion(SliderEventData eventData)
    {
        switch (sliderstatus)
        {
            case 1:
                j1rot = ((-165) + eventData.NewValue * 330);
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 2:
                j2rot = ((-110) + eventData.NewValue * 220);
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 3:
                j3rot = ((-110) + eventData.NewValue * 180);
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 4:
                j4rot = ((-160) + eventData.NewValue * 320);
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 5:
                j5rot = ((-120) + eventData.NewValue * 240);
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 6:
                j6rot = ((-400) + eventData.NewValue * 800);
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            case 7:
                j1rot = (final.apo_j1lower + eventData.NewValue * (Mathf.Abs(final.apo_j1lower) + final.apo_j1upper));
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 8:
                j2rot = (final.apo_j2lower + eventData.NewValue * (Mathf.Abs(final.apo_j2lower) + final.apo_j2upper));
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 9:
                j3rot = (final.apo_j3lower + eventData.NewValue * (Mathf.Abs(final.apo_j3lower) + final.apo_j3upper));
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 10:
                j4rot = (final.apo_j4lower + eventData.NewValue * (Mathf.Abs(final.apo_j4lower) + final.apo_j4upper));
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 11:
                j5rot = (final.apo_j5lower + eventData.NewValue * (Mathf.Abs(final.apo_j5lower) + final.apo_j5upper));
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 12:
                j6rot = (final.apo_j6lower + eventData.NewValue * (Mathf.Abs(final.apo_j6lower) + final.apo_j6upper));
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            case 13:
                j1rot = ((-165) + eventData.NewValue * (165 + final.apo_j1lower));
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 14:
                j2rot = ((-110) + eventData.NewValue * (110 + final.apo_j2lower));
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 15:
                j3rot = ((-110) + eventData.NewValue * (110 + final.apo_j3lower));
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 16:
                j4rot = ((-160) + eventData.NewValue * (160 + final.apo_j4lower));
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 17:
                j5rot = ((-120) + eventData.NewValue * (120 + final.apo_j5lower));
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 18:
                j6rot = ((-400) + eventData.NewValue * (400 + final.apo_j6lower));
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            case 19:
                j1rot = (final.apo_j1upper + eventData.NewValue * (165 - final.apo_j1upper));
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 20:
                j2rot = (final.apo_j2upper + eventData.NewValue * (110 - final.apo_j2upper));
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 21:
                j3rot = (final.apo_j3upper + eventData.NewValue * (70 - final.apo_j3upper));
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 22:
                j4rot = (final.apo_j4upper + eventData.NewValue * (160 - final.apo_j4upper));
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 23:
                j5rot = ((-120) + eventData.NewValue * (120 - final.apo_j5upper));
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 24:
                j6rot = ((-400) + eventData.NewValue * (400 - final.apo_j6upper));
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            case 25:
                j1rot = (storedj1 + (eventData.NewValue * final.sst_j1) - (final.sst_j1 / 2));
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 26:
                j2rot = (j2.transform.localEulerAngles.z + (eventData.NewValue * final.sst_j2) - (final.sst_j2 / 2));
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 27:
                j3rot = ((final.sst_j3 / 2) + eventData.NewValue * (final.sst_j3 / 2));
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 28:
                j4rot = ((final.sst_j4 / 2) + eventData.NewValue * (final.sst_j4 / 2));
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 29:
                j5rot = ((final.sst_j5 / 2) + eventData.NewValue * (final.sst_j5 / 2));
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 30:
                j6rot = ((final.sst_j6 / 2) + eventData.NewValue * (final.sst_j6 / 2));
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            case 31:
                j1rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j1.transform.localEulerAngles = new Vector3(0, j1rot, 0);
                currvalue.text = $"{j1rot:F2}" + "°";
                break;

            case 32:
                j2rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j2.transform.localEulerAngles = new Vector3(0, 0, j2rot);
                currvalue.text = $"{j2rot:F2}" + "°";
                break;

            case 33:
                j3rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j3.transform.localEulerAngles = new Vector3(0, 0, j3rot);
                currvalue.text = $"{j3rot:F2}" + "°";
                break;

            case 34:
                j4rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j4.transform.localEulerAngles = new Vector3(j4rot, 0, 0);
                currvalue.text = $"{j4rot:F2}" + "°";
                break;

            case 35:
                j5rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j5.transform.localEulerAngles = new Vector3(0, 0, j5rot);
                currvalue.text = $"{j5rot:F2}" + "°";
                break;

            case 36:
                j6rot = (float.Parse(custommin.text) + eventData.NewValue * (float.Parse(custommax.text) - float.Parse(custommin.text)));
                j6.transform.localEulerAngles = new Vector3(j6rot, 0, 0);
                currvalue.text = $"{j6rot:F2}" + "°";
                break;

            default:
                break;
        }
    }

public void FinalizeSlider(SliderEventData eventData)
    {
        base1_sst.transform.parent = j1.transform;
        arm2_sst.transform.parent = j2.transform;
        arm3_sst.transform.parent = j3.transform;
        wrist4_sst.transform.parent = j4.transform;
        bend5_sst.transform.parent = j5.transform;
        turn6_sst.transform.parent = j6.transform;

        base1_sst.transform.localEulerAngles = new Vector3(0, 0, 0);
        arm2_sst.transform.localEulerAngles = new Vector3(0, 0, 0);
        arm3_sst.transform.localEulerAngles = new Vector3(0, 0, 0);
        wrist4_sst.transform.localEulerAngles = new Vector3(0, 0, 0);
        bend5_sst.transform.localEulerAngles = new Vector3(0, 0, 0);
        turn6_sst.transform.localEulerAngles = new Vector3(0, 0, 0);

    }

public void ProcessFactory()
    {

        if (j1_on)
        {
            sliderstatus = 1;
        }

        else if (j2_on)
        {
            sliderstatus = 2;
        }

        else if (j3_on)
        {
            sliderstatus = 3;
        }

        else if (j4_on)
        {
            sliderstatus = 4;
        }

        else if (j5_on)
        {
            sliderstatus = 5;
        }

        else if (j6_on)
        {
            sliderstatus = 6;
        }

        else
        {
            togglerot1.ForceShow();
            sliderstatus = 1;
        }
    }

    public void ProcessAPO()
    {

        if (j1_on)
        {
            sliderstatus = 7;
        }

        if (j2_on)
        {
            sliderstatus = 8;
        }

        if (j3_on)
        {
            sliderstatus = 9;
        }

        if (j4_on)
        {
            sliderstatus = 10;
        }

        if (j5_on)
        {
            sliderstatus = 11;
        }

        if (j6_on)
        {
            sliderstatus = 12;
        }

        else if(!j1_on && !j2_on && !j3_on && !j4_on && !j5_on && !j6_on)
        {
            togglerot1.ForceShow();
            sliderstatus = 7;
        }
    }

public void ProcessLower() {

        if (j1_on)
            {
                sliderstatus = 13;
        }

            if (j2_on)
            {
                sliderstatus = 14;
        }

            if (j3_on)
            {
                sliderstatus = 15;
        }

            if (j4_on)
            {
                sliderstatus = 16;
        }

            if (j5_on)
            {
                sliderstatus = 17;
        }

        if (j6_on)
        {
            sliderstatus = 18;
        }

        else if (!j1_on && !j2_on && !j3_on && !j4_on && !j5_on && !j6_on)
        {
            togglerot1.ForceShow();
            sliderstatus = 13;
        }
    }

public void ProcessUpper()
    {

     if (j1_on)
            {
                sliderstatus = 19;
            }

           if (j2_on)
            {
                sliderstatus = 20;
            }

            if (j3_on)
            {
                sliderstatus = 21;
            }

            if (j4_on)
            {
                sliderstatus = 22;
            }

            if (j5_on)
            {
                sliderstatus = 23;
            }

        if (j6_on)
        {
            sliderstatus = 24;
        }

        else if (!j1_on && !j2_on && !j3_on && !j4_on && !j5_on && !j6_on)
        {
            togglerot1.ForceShow();
            sliderstatus = 19;
        }

    }

public void ProcessStandStill() {

            if (j1_on)
            {
                sliderstatus = 25;
            }

            if (j2_on)
            {
                sliderstatus = 26;
            }

            if (j3_on)
            {
                sliderstatus = 27;
            }

            if (j4_on)
            {
                sliderstatus = 28;
            }

            if (j5_on)
            {
                sliderstatus = 29;
            }

        if (j6_on)
        {
            sliderstatus = 30;
        }

        else if (!j1_on && !j2_on && !j3_on && !j4_on && !j5_on && !j6_on)
        {
            togglerot1.ForceShow();
            sliderstatus = 25;
        }
    }

    public void ProcessCustom()
    {
        if (j1_on)
        {
            sliderstatus = 31;
        }

        if (j2_on)
        {
            sliderstatus = 32;
        }

        if (j3_on)
        {
            sliderstatus = 33;
        }

        if (j4_on)
        {
            sliderstatus = 34;
        }

       if (j5_on)
        {
            sliderstatus = 35;
        }

        if (j6_on)
        {
            sliderstatus = 36;
        }

        else if (!j1_on && !j2_on && !j3_on && !j4_on && !j5_on && !j6_on)
        {
            togglerot1.ForceShow();
            sliderstatus = 31;
        }
    }

    public void ProcessJ1()
    {

        if (factory)
        {
            sliderstatus = 1;
        }

        if (apo)
        {
            sliderstatus = 7;
        }

        if (lower)
        {
            sliderstatus = 13;
        }

       if (upper)
        {
            sliderstatus = 19;
        }

        if (sst)
        {
            sliderstatus = 25;
        }

        if (custom)
        {
            sliderstatus = 31;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 1;
        }
    }

    public void ProcessJ2()
    {

        if (factory)
        {
            sliderstatus = 2;
        }

        else if (apo)
        {
            sliderstatus = 8;
        }

        else if (lower)
        {
            sliderstatus = 14;
        }

        else if (upper)
        {
            sliderstatus = 20;
        }

        else if (sst)
        {
            sliderstatus = 26;
        }

        else if (custom)
        {
            sliderstatus = 32;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 2;
        }

}

    public void ProcessJ3()
    {

        if (factory)
        {
            sliderstatus = 3;
        }

        if (apo)
        {
            sliderstatus = 9;
        }

        if (lower)
        {
            sliderstatus = 15;
        }

        if (upper)
        {
            sliderstatus = 21;
        }

        if (sst)
        {
            sliderstatus = 27;
        }

        if (custom)
        {
            sliderstatus = 33;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 3;
        }
    }

    public void ProcessJ4()
    {
     

        if (factory)
        {
            sliderstatus = 4;
        }

        if (apo)
        {
            sliderstatus = 10;
        }

        if (lower)
        {
            sliderstatus = 16;
        }

        if (upper)
        {
            sliderstatus = 22;
        }

       if (sst)
        {
            sliderstatus = 28;
        }

        if (custom)
        {
            sliderstatus = 34;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 4;
        }
    }

    public void ProcessJ5()
    {
  

        if (factory)
        {
            sliderstatus = 5;
        }

        if (apo)
        {
            sliderstatus = 11;
        }

        if (lower)
        {
            sliderstatus = 17;
        }

        if (upper)
        {
            sliderstatus = 23;
        }

        if (sst)
        {
            sliderstatus = 29;
        }

        if (custom)
        {
            sliderstatus = 35;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 5;
        }
    }

    public void ProcessJ6()
    {
      

        if (factory)
        {
            sliderstatus = 6;
        }

        if (apo)
        {
            sliderstatus = 12;
        }

       if (lower)
        {
            sliderstatus = 18;
        }

        if (upper)
        {
            sliderstatus = 24;
        }

       if (sst)
        {
            sliderstatus = 30;
        }

        if (custom)
        {
            sliderstatus = 36;
        }

        else if (!factory && !apo && !lower && !upper && !sst && !custom)
        {
            factorylimit.ForceShow();
            sliderstatus = 6;
        }
    }

}