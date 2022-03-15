using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformSizeFunctionality : MonoBehaviour
{

    public GameObject maincam;

    public float dist;

    public Vector3 objscale;
    
    void Update()
    {
            dist = Vector3.Distance(transform.position, maincam.transform.position);

            objscale = new Vector3(dist, dist, dist);

            transform.localScale = objscale;
   
    }
}
