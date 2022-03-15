using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAlong : MonoBehaviour {

	private Transform cameraTran;

	// Use this for initialization
	void Start () {
		cameraTran = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation (Vec3_ZeroY(transform.position - cameraTran.position));
	}

	Vector3 Vec3_ZeroY(Vector3 vec)
	{
		return new Vector3 (vec.x, 0, vec.z);
	}

}
