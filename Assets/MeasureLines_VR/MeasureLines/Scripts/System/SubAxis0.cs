using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAxis0 : MonoBehaviour {

	public bool enabled = false;
	private Plane planeXZ = new Plane();
	private Transform lower;
	private Transform higher;
	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}
	
	public void Init (Transform _lower, Transform _higher) 
	{
		lower = _lower;
		higher = _higher;
		planeXZ.SetNormalAndPosition(lower.up, lower.position);
		myTransform.position = higher.position + Vector3.down * planeXZ.GetDistanceToPoint(higher.position);
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (lower==null && higher==null) Destroy(gameObject);

		if (!enabled  || lower==null) return;

		planeXZ.SetNormalAndPosition(lower.up, lower.position);
		myTransform.position = higher.position + Vector3.down * planeXZ.GetDistanceToPoint(higher.position);

	}

}
