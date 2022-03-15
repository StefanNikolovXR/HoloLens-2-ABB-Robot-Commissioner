using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centroid5Sided : MonoBehaviour
{
    public GameObject p1, p2, p3, p4, p5, CenteredObjectLower, CenteredObjectUpper, ZoneCenter;
    private float p1x, p1z, p2x, p2z, p3x, p3z, p4x, p4z, p5x, p5z, paveragex, paveragez, centeredylower, centeredyupper;

    public Vector3 CenteredVectorLower, CenteredVectorUpper;

    private bool modify = false;

    void Awake()
    {
        p1x = p1.transform.position.x;
        p2x = p2.transform.position.x;
        p3x = p3.transform.position.x;
        p4x = p4.transform.position.x;
        p5x = p5.transform.position.x;

        p1z = p1.transform.position.z;
        p2z = p2.transform.position.z;
        p3z = p3.transform.position.z;
        p4z = p4.transform.position.z;
        p5z = p5.transform.position.z;

        paveragex = (p1x + p2x + p3x + p4x + p5x) / 5;
        paveragez = (p1z + p2z + p3z + p4z + p5z) / 5;

        centeredylower = CenteredObjectLower.transform.position.y;
        centeredyupper = CenteredObjectUpper.transform.position.y;

        Vector3 CenteredVectorLower = new Vector3(paveragex, centeredylower, paveragez);

        CenteredObjectLower.transform.position = CenteredVectorLower;

        Vector3 CenteredVectorUpper = new Vector3(paveragex, centeredyupper, paveragez);

        CenteredObjectUpper.transform.position = CenteredVectorUpper;
    }

    public void ZoneisModified()
        {
            modify = true;
        }

    public void ZoneisStatic()
        {
            modify = false;
        }

    void Update()
        {

        if(ZoneCenter.active && modify == true)

        {

        p1x = p1.transform.position.x;
        p2x = p2.transform.position.x;
        p3x = p3.transform.position.x;
        p4x = p4.transform.position.x;
        p5x = p5.transform.position.x;

        p1z = p1.transform.position.z;
        p2z = p2.transform.position.z;
        p3z = p3.transform.position.z;
        p4z = p4.transform.position.z;
        p5z = p5.transform.position.z;

        paveragex = (p1x + p2x + p3x + p4x + p5x) / 5;
        paveragez = (p1z + p2z + p3z + p4z + p5z) / 5;

            centeredylower = CenteredObjectLower.transform.position.y;
            centeredyupper = CenteredObjectUpper.transform.position.y;

            Vector3 CenteredVectorLower = new Vector3(paveragex, centeredylower, paveragez);

            CenteredObjectLower.transform.position = CenteredVectorLower;

            Vector3 CenteredVectorUpper = new Vector3(paveragex, centeredyupper, paveragez);

            CenteredObjectUpper.transform.position = CenteredVectorUpper;

        }
    }
    

}
