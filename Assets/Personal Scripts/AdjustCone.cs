using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjustCone : MonoBehaviour
{
    public GetTool gettool;
    public TMP_InputField radius;
    public float radius_num;

    public void AdjustConeRadius()
    {
        radius_num = float.Parse(radius.text);
        gettool.storedcone.radius = radius_num / 600;
        gettool.storedcone.UpdateCone();
    }
}
