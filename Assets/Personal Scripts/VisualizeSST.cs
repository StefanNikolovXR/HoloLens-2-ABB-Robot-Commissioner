using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VisualizeSST : MonoBehaviour
{
    public TMP_InputField j1, j2, j3, j4, j5, j6;
    public Shaper2D j1arcleft, j2arcleft, j3arcleft, j4arcleft, j5arcleft, j6arcleft;
    public Shaper2D j1arcright, j2arcright, j3arcright, j4arcright, j5arcright, j6arcright;
    private float j1sst, j2sst, j3sst, j4sst, j5sst, j6sst;

    public void ProcessSST()
    {
        j1sst = int.Parse(j1.text);
        j2sst = int.Parse(j2.text);
        j3sst = int.Parse(j3.text);
        j4sst = int.Parse(j4.text);
        j5sst = int.Parse(j5.text);
        j6sst = int.Parse(j6.text);

        //final visualization
        j1arcleft.arcDegrees = j1sst;
        j1arcright.arcDegrees = j1sst;
        j2arcleft.arcDegrees = j2sst;
        j2arcright.arcDegrees = j2sst;
        j3arcleft.arcDegrees = j3sst;
        j3arcright.arcDegrees = j3sst;
        j4arcleft.arcDegrees = j4sst;
        j4arcright.arcDegrees = j4sst;
        j5arcleft.arcDegrees = j5sst;
        j5arcright.arcDegrees = j5sst;
        j6arcleft.arcDegrees = j6sst;
        j6arcright.arcDegrees = j6sst;

    }
}
