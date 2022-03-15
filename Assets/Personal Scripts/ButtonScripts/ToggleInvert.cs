using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleInvert : MonoBehaviour
{
    public TextMeshPro invert_value;

    public void ToggleInvertButton()
    {
        if (invert_value.text == "Normal")
        {
            invert_value.text = "Inverted";
        }

        else if (invert_value.text == "Inverted")
        {
            invert_value.text = "Normal";
        }
    }
}
