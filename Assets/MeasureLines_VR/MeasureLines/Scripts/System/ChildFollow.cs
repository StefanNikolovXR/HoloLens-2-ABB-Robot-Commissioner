using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFollow : MonoBehaviour {

	public bool enabled = false;
	private Transform myTransform;
	private Transform target;
	private Transform lower;
	private Transform higher;

	void Awake()
	{
		myTransform = transform;
	}

	public void Init (Transform _target, Transform _lower, Transform _higher) 
	{
		lower = _lower;
		higher = _higher;
		target = _target;
		myTransform.position = target.position;
		enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (lower==null && higher==null) Destroy(gameObject);

		if (!enabled || target==null) return;

		myTransform.position = target.position;
	}
}
