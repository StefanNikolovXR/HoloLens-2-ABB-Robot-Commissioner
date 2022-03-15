using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPolygontoHandle : MonoBehaviour
{
    private GameObject parent, TopCoordinates_Container, Coordinates_Container;

    public GeneratePolygon generatescript;

    public void FillHandles()
    {
        parent = transform.root.gameObject;
        TopCoordinates_Container = parent.transform.Find("TopCoordinates_Container").gameObject;
        Coordinates_Container = parent.transform.Find("Coordinates_Container").gameObject;
    }

   public void MovingTOP()
    {
        TopCoordinates_Container.transform.parent = transform;
        generatescript.moving = true;
    }

    public void MovingBOT() {
        Coordinates_Container.transform.parent = transform;
        generatescript.moving = true;
    }

    public void BOTStopped()
    {
        Coordinates_Container.transform.parent = parent.transform;
        generatescript.moving = false;
    }

        public void TopStopped()
    {
        TopCoordinates_Container.transform.parent = parent.transform;
        generatescript.moving = false;
    }
}
