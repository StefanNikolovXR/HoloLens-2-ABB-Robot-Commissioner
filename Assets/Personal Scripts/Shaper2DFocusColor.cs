using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaper2DFocusColor : MonoBehaviour
{
    public Shaper2D shape;
    public Color yellowcolor = new Color32(255, 220, 0, 255);
    public Color whitecolor = new Color32(255, 255, 255, 255);

    public void HoverEnter()
    {
        shape.innerColor = yellowcolor;
        shape.outerColor = yellowcolor;
    }

    public void HoverExit()
    {
        shape.innerColor = whitecolor;
        shape.outerColor = whitecolor;
    }
}
