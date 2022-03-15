using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;

public class SafeZoneVerticesSlider : MonoBehaviour
{
    public TextMeshPro vertices;
    public CreateSafeZone zonescript;

    public void OnSliderUpdated(SliderEventData eventData)
    {
        zonescript.numberofedges = eventData.NewValue * 10 + 4;
        vertices.text = $"{eventData.NewValue*10+4}";
    }
}
