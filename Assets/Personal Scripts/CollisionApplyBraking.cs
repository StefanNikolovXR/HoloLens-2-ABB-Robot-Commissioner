using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionApplyBraking : MonoBehaviour
{
    public GameObject ToolApplyBraking;
    public GameObject Zone;
    public GameObject AttachmentGumball;
    public Collider ToolCollider, ZoneCollider;
    public bool activeSelf;

    void Start()
    {
        ToolCollider = ToolApplyBraking.GetComponent<SphereCollider>();
        ZoneCollider = Zone.GetComponent<BoxCollider>();

    }

    void Update()
    {
        if (ToolApplyBraking.activeSelf == true && Zone.activeSelf == true)
        {
            if (ToolCollider.bounds.Intersects(ZoneCollider.bounds))
            {
                ToolApplyBraking.GetComponent<TrailRenderer>().enabled = true;
                AttachmentGumball.GetComponent<TrailRenderer>().emitting = false;
            }
        }
    }
}
