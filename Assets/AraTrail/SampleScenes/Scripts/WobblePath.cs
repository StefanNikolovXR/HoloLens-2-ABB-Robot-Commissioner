using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WobblePath : MonoBehaviour {

    public float speed = 10;
    public float amplitude = 1;
    public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = offset + transform.up * Mathf.Sin(Time.time * speed) * amplitude;
	}
}
