using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroWallPositions : MonoBehaviour
{

    public Component[] wallscripts;

    private ModifySafetyZoneQuads script;
    private GameObject parent;
    public bool moving;
    public KeepShadowPolygonatFloor keeppolygon;
    public KeepShadowatFloor keepshadow;

    void Start()
    {
        parent = transform.root.gameObject;
        wallscripts = GetComponentsInChildren<ModifySafetyZoneQuads>();

        transform.localPosition = new Vector3(parent.transform.position.x * (-1), parent.transform.position.y * (-1), parent.transform.position.z * (-1));
    }

    public void Moving()
    {

        foreach (ModifySafetyZoneQuads script in wallscripts)

            script.moving = true;
        moving = true;
        keepshadow.ZoneMoving();
        keeppolygon.ZoneMoving();
    }

    public void Stopped()
    {
        foreach (ModifySafetyZoneQuads script in wallscripts)

            script.moving = false;
        moving = false;
        keepshadow.ZoneStopped();
        keeppolygon.ZoneStopped();
    }

    void Update()
    {
        if (moving)
        {
            transform.localPosition = new Vector3(parent.transform.position.x * (-1), parent.transform.position.y * (-1), parent.transform.position.z * (-1));
        }
    }
}

