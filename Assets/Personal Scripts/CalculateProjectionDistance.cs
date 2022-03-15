using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalculateProjectionDistance : MonoBehaviour
{
    public GameObject toolline, bendline, wristline, armline;
    public GameObject baseend, wristend, bendend;

    private string toollinetoground = "Turn6_RaytracedLine_START_To_Base_RaytracedLine_END_line", bendlinetoground = "Bend5_RaytracedLine_START_To_Bend5_RaytracedLine_END_line";
    private string wristlinetoground = "Wrist4_RaytracedLine_START_To_Wrist4_RaytracedLine_END_line", baselinetotool = "Base_RaytracedLine_START_To_Base_RaytracedLine_END_line";

    private bool enableprojection = false;
    public bool activeSelf;

    private float y;

    public float toollinetogroundheight, wristlinetogroundheight, bendlinetogroundheight, armlinetogroundheight;
    public TextMeshPro toollinetogroundtext, bendlinetogroundtext, wristlinetogroundtext, armlinetogroundtext;

    public GameObject basecontainer, wristcontainer, bendcontainer, turncontainer;

    public SaveFloorHeight floorscript;

    public void ArmTracingON()
    {
        enableprojection = true;
        basecontainer.SetActive(true);
        wristcontainer.SetActive(true);
        bendcontainer.SetActive(true);
        turncontainer.SetActive(true);
        y = floorscript.floorheight;

    }

    public void ArmTracingOFF()
    {
        enableprojection = false;

        basecontainer.SetActive(false);
        wristcontainer.SetActive(false);
        bendcontainer.SetActive(false);
        turncontainer.SetActive(false);

    }

    void Update()
    {
        if (enableprojection)
            
        {
            toolline = GameObject.Find(toollinetoground);
            bendline = GameObject.Find(bendlinetoground);
            wristline = GameObject.Find(wristlinetoground);
            armline = GameObject.Find(baselinetotool);

            basecontainer.transform.position = new Vector3(basecontainer.transform.position.x, y, basecontainer.transform.position.z);
            baseend.transform.position = new Vector3(baseend.transform.position.x, y, baseend.transform.position.z);
            wristend.transform.position = new Vector3(wristend.transform.position.x, y, wristend.transform.position.z);
            bendend.transform.position = new Vector3(bendend.transform.position.x, y, bendend.transform.position.z);

            armlinetogroundheight = armline.transform.localScale.z * 100;
            armlinetogroundtext.text = $"{armlinetogroundheight:F2}" + "mm";

            wristlinetogroundheight = wristline.transform.localScale.z * 100;
            wristlinetogroundtext.text = $"{wristlinetogroundheight:F2}" + "mm";

            bendlinetogroundheight = bendline.transform.localScale.z * 100;
            bendlinetogroundtext.text = $"{bendlinetogroundheight:F2}" + "mm";

            toollinetogroundheight = toolline.transform.localScale.z * 100;
            toollinetogroundtext.text = $"{toollinetogroundheight:F2}" + "mm";

        }
    }
}
