using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleUpperArm : MonoBehaviour
{
    public TextMeshPro upperarm_value;

    public void ToggleUpperArmButton()
    {
        if (upperarm_value.text == "Include")
        {
            upperarm_value.text = "Tool Only";
        }

        else if (upperarm_value.text == "Tool Only")
        {
            upperarm_value.text = "Include";
        }
    }
}
