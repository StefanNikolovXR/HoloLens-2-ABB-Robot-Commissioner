using UnityEngine;
using System.Collections;

public class DynamicAddLineSample_WorldCanvas : MonoBehaviour {

	public bool OnSurface = true;
	private Vector3 hitPos;
	private Transform lastHitTransform;
	private bool isDrawLine = true;
	private bool prevIsDrawLine = true;
    private bool showSubAxis = false;
	public bool verticalOrHorizontal = false;

	void Update () 
	{
		//MeasureLine_WorldCanvas's verticalOrHorizontal
		MeasureLine_WorldCanvas.verticalOrHorizontal = verticalOrHorizontal;
		//Add Line
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			isDrawLine = true;
			if (prevIsDrawLine != isDrawLine)
			{
				lastHitTransform = null;
				prevIsDrawLine = isDrawLine;
			}
			GameObject hitObj = MouseRayer.GetMouseRayHit(Camera.main, out hitPos);
			if (hitObj!=null)
			{
				if (isDrawLine)
				{
					if (!OnSurface)
					{
						MeasureLine_WorldCanvas.DrawLine(hitObj.transform, false, false, OnSurface, 6f);
						if (lastHitTransform != null) {
							MeasureLine_WorldCanvas.EndDrawLine ();
							lastHitTransform = null;
						} else {
							lastHitTransform = hitObj.transform;
						}
					}
					else
					{
						GameObject hitDummy = new GameObject("SurfaceLineDummy");
						hitDummy.transform.position = hitPos;
						hitDummy.transform.SetParent(hitObj.transform);
						MeasureLine_WorldCanvas.DrawLine(hitDummy.transform, false, false, OnSurface, 6f, showSubAxis);
						if (lastHitTransform != null) {
							MeasureLine_WorldCanvas.EndDrawLine ();
							lastHitTransform = null;
						} else {
							lastHitTransform = hitObj.transform;
						}
					}
				}
			}
		}
		//Delete Line
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			isDrawLine = false;
			if (prevIsDrawLine != isDrawLine)
			{
				lastHitTransform = null;
				prevIsDrawLine = isDrawLine;
			}
			GameObject hitObj = MouseRayer.GetMouseRayHit(Camera.main, out hitPos);
			if (lastHitTransform != null) {
				if (lastHitTransform != hitObj.transform) {
					MeasureLine_WorldCanvas.DeleteLine(lastHitTransform, hitObj.transform, OnSurface);
					lastHitTransform = null;
				}
				else
				{
					MeasureLine_WorldCanvas.DeleteLine(hitObj.transform, OnSurface);
					lastHitTransform = null;
				}
			} else {
				lastHitTransform = hitObj.transform;
			}
		}
		//Delete All Lines
		else if (Input.GetKeyDown(KeyCode.Mouse2))
		{
			MeasureLine_WorldCanvas.DeleteAllLines();
			lastHitTransform = null;
		}
	}

// 	void OnGUI()
// 	{
// //		isDrawLine = GUI.Toggle(new Rect(5, Screen.height-150, 130, 30), isDrawLine, "Is Draw Line?");

// 		if (GUI.Button(new Rect(5, Screen.height-100, 400, 30), "Delete lines between ObjectA and ObjectB"))
// 		{
// 			MeasureLine_WorldCanvas.DeleteLine(GameObject.Find("Icosahedron (1)").transform, GameObject.Find("Icosahedron (2)").transform, OnSurface);
// 		}
// 		if (GUI.Button(new Rect(5, Screen.height-65, 400, 30), "Delete lines In ObjectC"))
// 		{
// 			MeasureLine_WorldCanvas.DeleteLine(GameObject.Find("LowpolyObj").transform, OnSurface);
// 		}
// 	}

}
