using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleManual : MonoBehaviour
{
    public TextMeshPro activation_value;

    public void ToggleActivationButton()
    {
        if (activation_value.text == "Don't Allow")
        {
            activation_value.text = "Allow";
        }

        else if (activation_value.text == "Allow")
        {
            activation_value.text = "Don't Allow";
        }

    }
}
