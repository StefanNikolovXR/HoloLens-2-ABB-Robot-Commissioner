using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleActivation : MonoBehaviour
{
    public TextMeshPro activation_value, stop_value;

    public void ToggleActivationButton()
    {
        if(activation_value.text == "0")
        {
            activation_value.text = "1";
        }

        else if(activation_value.text == "1")
        {
            activation_value.text = "Permanent";
            stop_value.text = "NoStop";
        }

        else if(activation_value.text == "Permanent")
        {
            activation_value.text = "0";
        }
    }
}
