using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TOPBOTHandlesYCoordinate : MonoBehaviour
{
    public GameObject Coordinate;

    public TextMeshPro y_box;

    private float y;

    void Update()
    {
        y = Coordinate.transform.position.y;

        y_box.text = "[" + $"{y:F2}" + "]";
    }
}
