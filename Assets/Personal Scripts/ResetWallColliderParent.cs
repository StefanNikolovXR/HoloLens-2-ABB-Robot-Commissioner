using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWallColliderParent : MonoBehaviour
{
    public GameObject Walls, Zone;

    public void Child()
    {
        Walls.transform.parent = Zone.transform;
    }
}
