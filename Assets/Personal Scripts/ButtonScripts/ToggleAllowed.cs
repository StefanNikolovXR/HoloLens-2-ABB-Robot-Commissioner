using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleAllowed : MonoBehaviour
{
    public TextMeshPro allow_value;

    public void ToggleAllowButton()
    {
        if (allow_value.text == "Allowed")
        {
            allow_value.text = "Not Allowed";
        }

        else if (allow_value.text == "Not Allowed")
        {
            allow_value.text = "Allowed";
        }
    }
}
