using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsScript : MonoBehaviour
{
    public string[] TemplateArray = {"MoveJ", "MoveL", "MoveAbsJ", "MoveExtJ"};
    public string[] SpeedArray = {"v5", "v10", "v20", "v30", "v40", "v50", "v60", "v80", "v100", "v150", "v300", "v400", "v500", "v600", "v800", "v1000", "v1500", "v2000", "v2500", "v3000", "v4000", "v5000", "v6000", "v7000", "vlin10", "vlin20", "vlin50", "vlin100", "vlin200", "vlin500", "vlin1000", "vmax", "vrot1", "vrot2", "vrot5", "vrot10", "vrot20", "vrot50", "vrot100" };
    public string[] ZoneArray = { "fine", "z0", "z1", "z5", "z10", "z15", "z20", "z30", "z40", "z50", "z60", "z80", "z100", "z150", "z200" };

    private int i=0, s=0, z=0;

    public TextMeshPro template, speed, zone;

    public void ShiftTemplateLeft()
    {
        if (i == 0) { i = 3; template.text = TemplateArray[i]; }
        else { i--; template.text = TemplateArray[i]; }
    }

    public void ShiftTemplateRight()
    {
        if (i == 3) { i = 0; template.text = TemplateArray[i]; }
        else { i++; template.text = TemplateArray[i]; }
    }

    public void ShiftSpeedLeft()
    {
        if (s == 0) { s = 38; speed.text = SpeedArray[s]; }
        else { s--; speed.text = SpeedArray[s]; }
    }

    public void ShiftSpeedRight()
    {
        if (s == 38) { s = 0; speed.text = SpeedArray[s]; }
        else { s++; speed.text = SpeedArray[s]; }
    }

    public void ShiftZoneLeft()
    {
        if (z == 0) { z = 14; zone.text = ZoneArray[z]; }
        else { z--; zone.text = ZoneArray[z]; }
    }

    public void ShiftZoneRight()
    {
        if (z == 14) { z = 0; zone.text = ZoneArray[z]; }
        else { z++; zone.text = ZoneArray[z]; }
    }
}
