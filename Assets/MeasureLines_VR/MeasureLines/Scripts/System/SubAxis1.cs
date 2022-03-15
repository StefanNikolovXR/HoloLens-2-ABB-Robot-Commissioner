using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubAxis1 : MonoBehaviour {

	public bool enabled = false;
	private Plane planeXY = new Plane();
	private Transform lower;
	private Transform higher;
	private Transform myTransform;
	private SubAxis0 subAxis0;

	void Awake()
	{
		myTransform = transform;
	}
	
	public void Init (Transform _lower, Transform _higher, SubAxis0 _subAxis0) 
	{
		lower = _lower;
		higher = _higher;
		subAxis0 = _subAxis0;
		planeXY.SetNormalAndPosition(lower.forward, lower.position);
		Vector3 downPosFromHigher = subAxis0.transform.position;
		myTransform.position = downPosFromHigher - Vector3.forward * planeXY.GetDistanceToPoint(downPosFromHigher);
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (lower==null && higher==null) Destroy(gameObject);

		if (!enabled || lower == null) return;

		planeXY.SetNormalAndPosition(lower.forward, lower.position);
		Vector3 downPosFromHigher = subAxis0.transform.position;
		myTransform.position = downPosFromHigher - Vector3.forward * planeXY.GetDistanceToPoint(downPosFromHigher);

	}

}
