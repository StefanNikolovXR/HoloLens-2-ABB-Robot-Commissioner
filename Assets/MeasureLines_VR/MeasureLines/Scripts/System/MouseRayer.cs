using UnityEngine;
using System.Collections;

public class MouseRayer : MonoBehaviour {
	

	static public GameObject GetMouseRayHit(Camera cameras, out Vector3 point)
	{
		int layerMask = 0;
		layerMask = ~layerMask;
		GameObject result = null;
		point = Vector3.zero;
		Ray ray = cameras.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
		{
			result = hit.transform.gameObject;
			point = hit.point;
		}
		return result;
	}

	static public GameObject GetMouseRayHit(Vector3 mousePos, out Vector3 point)
	{
		int layerMask = 0;
		layerMask = ~layerMask;
		GameObject result = null;
		point = Vector3.zero;
		Ray ray = Camera.main.ScreenPointToRay(mousePos);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
		{
			result = hit.transform.gameObject;
			point = hit.point;
		}
		return result;
	}

}



