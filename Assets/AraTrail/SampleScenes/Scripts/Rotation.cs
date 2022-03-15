using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AraSamples{
public class Rotation : MonoBehaviour {

    public float speed = 10;
    public Vector3 axis;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(axis,speed*Time.deltaTime);
	}
}
}