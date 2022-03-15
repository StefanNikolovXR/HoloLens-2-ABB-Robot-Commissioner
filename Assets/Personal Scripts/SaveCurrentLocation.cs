using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCurrentLocation : MonoBehaviour
{

    public GameObject Pivot;
    private float x1;
    private float y1;
    private float z1;
    private Vector3 PreviousLocation;

    public void SavePivotLocation ()
    {
        x1 = Pivot.transform.position.x;
        y1 = Pivot.transform.position.y;
        z1 = Pivot.transform.position.z;
    }

    public void RevertLocation ()
    {
        PreviousLocation = new Vector3(x1, y1, z1);
        Pivot.transform.position = PreviousLocation;
    }

}
