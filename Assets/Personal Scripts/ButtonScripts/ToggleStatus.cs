using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleStatus : MonoBehaviour
{
    public TextMeshPro activation_value;

    public void ToggleActivationButton()
    {
        if (activation_value.text == "0")
        {
            activation_value.text = "1";
        }

        else if (activation_value.text == "1")
        {
            activation_value.text = "No Signal";
        }

        else if (activation_value.text == "No Signal")
        {
            activation_value.text = "0";
        }
    }
}
