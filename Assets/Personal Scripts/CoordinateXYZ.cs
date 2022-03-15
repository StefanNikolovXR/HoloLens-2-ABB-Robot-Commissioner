using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoordinateXYZ : MonoBehaviour
{
    public GameObject Coordinate;

    public TextMeshPro xz_box;

    private float x;
    private float z;

    void Update()
    {
            x = Coordinate.transform.position.x;
            z = Coordinate.transform.position.z;

        xz_box.text = "[" + $"{x:F2}" + "],[" + $"{z:F2}" + "]";
    }
}
