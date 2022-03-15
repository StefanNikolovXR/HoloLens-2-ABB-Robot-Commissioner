//Script by unicoea 2017.4.22
//v1.2.2a Version:
//Change OnGUI to UGUI

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
//using UnityEditor; //Comment this for publish.


public class MeasureLine : MonoBehaviour {

	public enum Coordinate
	{
		Local,
		World,
	}

	public enum MetricOrImperial
	{
		Inches,
		Foot,
		Meter,
	}

	public class LinkedObjects
	{
		public GameObject obj0;
		public GameObject obj1;
	}

	private Transform myTransform;
	private RaycastHit hit_Right0 = new RaycastHit();
	private RaycastHit hit_Right1 = new RaycastHit();
	private RaycastHit hit_Left0 = new RaycastHit();
	private RaycastHit hit_Left1 = new RaycastHit();
	private RaycastHit hit_Up0 = new RaycastHit();
	private RaycastHit hit_Up1 = new RaycastHit();
	private RaycastHit hit_Down0 = new RaycastHit();
	private RaycastHit hit_Down1 = new RaycastHit();
	private RaycastHit hit_Forward0 = new RaycastHit();
	private RaycastHit hit_Forward1 = new RaycastHit();
	private RaycastHit hit_Back0 = new RaycastHit();
	private RaycastHit hit_Back1 = new RaycastHit();
	private Transform line_L;
	private Transform line_R;
	private Transform line_U;
	private Transform line_D;
	private Transform line_F;
	private Transform line_B;
	private Vector3 screenL;
	private Vector3 screenR;
	private Vector3 screenU;
	private Vector3 screenD;
	private Vector3 screenF;
	private Vector3 screenB;
	private Vector3 midPoint;
	private float lengthL;
	private float lengthR;
	private float lengthU;
	private float lengthD;
	private float lengthF;
	private float lengthB;
	private bool showL;
	private bool showR;
	private bool showU;
	private bool showD;
	private bool showF;
	private bool showB;
	public Material mat;
	private Camera mainCamera;
	private Transform camTransform;
	public float lineWidth = 0.08f;
	public Color lineColor = new Color(0.627f, 0.839f, 0.165f, 1);
	public Color textColor = new Color(1, 1, 1, 1);
	public int textSize = 14;
	public int decimalPlaces = 2;
	public MetricOrImperial metricOrImperial = MetricOrImperial.Meter;
	private MetricOrImperial lastMetricOrImperial = MetricOrImperial.Meter;
	static public MetricOrImperial StaticMetricOrImperial = MetricOrImperial.Meter;
	public Vector3 pivotBias = Vector3.zero;
	public Vector3 angle = Vector3.zero;
	public Coordinate coordinate = Coordinate.Local;
	public bool AxisX_P = true;
	public bool AxisX_N = true;
	public bool AxisY_P = true;
	public bool AxisY_N = true;
	public bool AxisZ_P = true;
	public bool AxisZ_N = true;
	private Transform lineParent;
	public float maxDistance = 100f;
	public LayerMask layerMask = -1;
	private Transform axisDummy = null;
	private bool isEmptyObject = false;
	private float textBiasX = 10f;
	public bool canBeBlock = true;
	public bool ShowTargetLine = true;
    public bool IsShowText = true;
    public Transform[] targetObjects;
	private List<Transform> targetList = new List<Transform> ();
	private Transform[] targets;
	private Transform[] targetLines;
	private Vector3[] targetScreen;
	private float[] targetLength;
	private bool[] showTarget;
	private RaycastHit hit_Target0;
	private RaycastHit hit_Target1;
	private Renderer lineRender = null;
	private int layer = 0;
	private int lastTargetLineCount = 0;
	private GameObject lineCollection;
	private GameObject overlayUICanvas;
	private RectTransform canvasRT;
	private GameObject uiTextParent;
	private Text uiText_L;
	private Text uiText_R;
	public Text uiText_U;
	private Text uiText_D;
	private Text uiText_F;
	private Text uiText_B;
	private List<Text> linkTexts = new List<Text>();

	//Comment this function for publish.
//	void OnDrawGizmos() 
//	{
//		//Show Label
//		if (AxisX_P && line_R!=null && showR && InFrontOfCamera(line_R.position)) {
//			Handles.Label (line_R.position, (Mathf.Round (lengthR * 100) / 100).ToString () + "m");
//		}
//		if (AxisX_N && line_L != null && showL && InFrontOfCamera(line_L.position)) {
//			Handles.Label (line_L.position, (Mathf.Round (lengthL * 100) / 100).ToString () + "m");
//		}
//		if (AxisY_P && line_U != null && showU && InFrontOfCamera(line_U.position)) {
//			Handles.Label (line_U.position, (Mathf.Round (lengthU * 100) / 100).ToString () + "m");
//		}
//		if (AxisY_N && line_D!=null && showD && InFrontOfCamera(line_D.position)) {
//			Handles.Label (line_D.position, (Mathf.Round (lengthD * 100) / 100).ToString () + "m");
//		}
//		if (AxisZ_P && line_F != null && showF && InFrontOfCamera(line_F.position)) {
//			Handles.Label (line_F.position, (Mathf.Round (lengthF * 100) / 100).ToString () + "m");
//		}
//		if (AxisZ_N && line_B!=null && showB && InFrontOfCamera(line_B.position)) {
//			Handles.Label (line_B.position, (Mathf.Round (lengthB * 100) / 100).ToString () + "m");
//		}
//		//Get Really Targets
//		GetReallyTarget ();
//		//Refresh Target Lines
//		if (lastTargetLineCount != targets.Length) {
//			RefreshTargetLines();
//			lastTargetLineCount = targets.Length;
//		}
//		if (targets.Length > 0 && targetLines!=null && targetLines.Length>0) {
//			for (int i=0;i<targetLines.Length;i++){
//				if (ShowTargetLine && showTarget[i] && targetLines[i]!=null && InFrontOfCamera(targetLines[i].transform.position)){
//					Handles.Label (targetLines[i].transform.position, (Mathf.Round (targetLength[i] * 100) / 100).ToString () + "m");
//				}
//			}
//		}
//		if (isEmptyObject)
//			Gizmos.DrawWireSphere (myTransform.position, 0.5f);
//	}

	/// <summary>
	/// Clear all lines
	/// </summary>
	static public void DeleteAllLines()
	{
		//Del all MeasureLine_WorldCanvas
		MeasureLine[] mls = UnityEngine.Object.FindObjectsOfType<MeasureLine>();
		for (int i=0;i<mls.Length;i++)
		{
			MeasureLine ml = mls[i];
			if (ml.gameObject.name == "SurfaceLineDummy")
			{
				Destroy(ml.gameObject);
			}
			else
			{
				Destroy(ml);
			}
		}
		//Del all SurfaceLineDummy empty object
		GameObject sld = GameObject.Find("SurfaceLineDummy");
		while(sld!=null)
		{
			DestroyImmediate(sld);
			sld = GameObject.Find("SurfaceLineDummy");
		}
		//Del all childs of lineCollection
		Transform lineCollection = GameObject.Find ("lineCollection").transform;
		List<GameObject> cildObjects = new List<GameObject>();
		for (int i=0;i<lineCollection.childCount;i++)
		{
			cildObjects.Add(lineCollection.GetChild(i).gameObject);
		}
		for (int i=0;i<cildObjects.Count;i++)
		{
			Destroy(cildObjects[i]);
		}
		cildObjects.Clear();
		//Clear SurfaceLink
		surfaceLinks.Clear();
	}

	/// <summary>
	/// For Dynamic Draw Line
	/// </summary>
	static public void AddLine(Transform obj1, Transform obj2, bool canBeBlock, bool onSurface, bool ignoreSurfaceLinks = false)
	{
		MeasureLine mw1 = obj1.GetComponent<MeasureLine>();
		MeasureLine mw2 = obj2.GetComponent<MeasureLine>();
		MeasureLine mw = null;
		if (mw1 == null && mw2 == null){
			mw = null;
		}else if (mw1 != null && mw2 == null){
			mw = mw1;
		}else if (mw1 == null && mw2 != null){
			mw = mw2;
		}else if (mw1 != null && mw2 != null){
			if (IsExistTarget(mw1, obj2) || IsExistTarget(mw2, obj1)){
				return;
			}else{
				mw = mw1;
			}
		}
		if (mw == null) 
		{
			mw = obj1.gameObject.AddComponent<MeasureLine> ();
			mw.canBeBlock = canBeBlock;
			mw.AxisX_P = false;
			mw.AxisX_N = false;
			mw.AxisY_N = false;
			mw.AxisY_P = false;
			mw.AxisZ_N = false;
			mw.AxisZ_P = false;
		}
		AddTarget(mw, obj2);
		//Add to surfaceLinks
		if (onSurface && !ignoreSurfaceLinks){
			AddSurfaceLinks(obj1.gameObject, obj2.gameObject);
		}
	}

	//Delete Line in one object
	static public void DeleteLine(Transform obj1, bool onSurface)
	{
		DeleteLine(obj1, obj1, onSurface);
	}

	//Delete line between two objects
	static public void DeleteLine(Transform obj1, Transform obj2, bool onSurface)
	{
		//Delete surfaceLinks
		if (onSurface){
//			Debug.Log("DelSurfaceLinks");
			DelSurfaceLinks(obj1.gameObject, obj2.gameObject);
		}
		else
		{
			MeasureLine mw1 = obj1.GetComponent<MeasureLine>();
			MeasureLine mw2 = obj2.GetComponent<MeasureLine>();
			DelTarget(mw1, obj2);
			DelTarget(mw2, obj1);
		}
	}

	static public Dictionary<string, List<LinkedObjects>> surfaceLinks = new Dictionary<string, List<LinkedObjects>>();

	static public void DelSurfaceLinks(GameObject object0, GameObject object1)
	{
		string id_0_1 = object0.GetInstanceID().ToString() + "_" + object1.GetInstanceID().ToString();
		string id_1_0 = object1.GetInstanceID().ToString() + "_" + object0.GetInstanceID().ToString();
		//		Debug.Log("DelSurfaceLinks->id_0_1 = "+id_0_1+" id_1_0 = "+id_1_0);
		if (surfaceLinks.ContainsKey(id_0_1))
		{
			List<LinkedObjects> list = surfaceLinks[id_0_1];
			List<LinkedObjects> newList = new List<LinkedObjects>();
			List<int> removeIndexList = new List<int>();
			GameObject obj0;
			GameObject obj1;
			for(int i=0;i<list.Count;i++)
			{
				obj0 = list[i].obj0;
				obj1 = list[i].obj1;
				if ((obj0.transform.parent == object0.transform && obj1.transform.parent == object1.transform) || (obj0.transform.parent == object1.transform && obj0.transform.parent == object1.transform))
				{
					//Delete in Dummy's targetObjects's list
					MeasureLine mw0 = obj0.GetComponent<MeasureLine>();
					MeasureLine mw1 = obj1.GetComponent<MeasureLine>();
					DelTarget(mw0, obj1.transform);
					DelTarget(mw1, obj0.transform);
					//Delete no measureline_worldcanvas component's one's gameobject.
					if (mw0!=null && mw1==null)
					{
						Destroy(obj1);
						if (MeasureLineHelper.IsEmpty(mw0.targetObjects))
						{
							Destroy(obj0);
						}
						removeIndexList.Add(i); //ready to remove from list, save index first
					}
					else if (mw1!=null && mw0==null)
					{
						Destroy(obj0);
						if (MeasureLineHelper.IsEmpty(mw1.targetObjects))
						{
							Destroy(obj1);
						}
						removeIndexList.Add(i); //ready to remove from list, save index first
					}
				}
			}
			//Build new list if needed
			if (removeIndexList.Count>0)
			{
				for (int i=0;i<list.Count;i++)
				{
					if (!MeasureLineHelper.CheckIntInList(removeIndexList, i))
					{
						newList.Add(list[i]);
					}
				}
				surfaceLinks[id_0_1] = newList;
				removeIndexList.Clear();
				list.Clear();
			}
		}
		else if (surfaceLinks.ContainsKey(id_1_0))
		{
			List<LinkedObjects> list = surfaceLinks[id_1_0];
			List<LinkedObjects> newList = new List<LinkedObjects>();
			List<int> removeIndexList = new List<int>();
			GameObject obj0;
			GameObject obj1;
			for(int i=0;i<list.Count;i++)
			{
				obj0 = list[i].obj0;
				obj1 = list[i].obj1;
				if ((obj0.transform.parent == object0.transform && obj1.transform.parent == object1.transform) || (obj0.transform.parent == object1.transform && obj0.transform.parent == object1.transform))
				{
					//Delete in Dummy's targetObjects's list
					MeasureLine mw0 = obj0.GetComponent<MeasureLine>();
					MeasureLine mw1 = obj1.GetComponent<MeasureLine>();
					DelTarget(mw0, obj1.transform);
					DelTarget(mw1, obj0.transform);
					//Delete no measureline_worldcanvas component's one's gameobject.
					if (mw0!=null && mw1==null)
					{
						Destroy(obj1);
						if (MeasureLineHelper.IsEmpty(mw0.targetObjects))
						{
							Destroy(obj0);
						}
						removeIndexList.Add(i); //ready to remove from list, save index first
					}
					else if (mw1!=null && mw0==null)
					{
						Destroy(obj0);
						if (MeasureLineHelper.IsEmpty(mw1.targetObjects))
						{
							Destroy(obj1);
						}
						removeIndexList.Add(i); //ready to remove from list, save index first
					}
				}
			}
			//Build new list if needed
			if (removeIndexList.Count>0)
			{
				for (int i=0;i<list.Count;i++)
				{
					if (!MeasureLineHelper.CheckIntInList(removeIndexList, i))
					{
						newList.Add(list[i]);
					}
				}
				surfaceLinks[id_1_0] = newList;
				removeIndexList.Clear();
				list.Clear();
			}
		}
	}

	static public void AddSurfaceLinks(GameObject child0, GameObject child1)
	{
		LinkedObjects item = new LinkedObjects();
		item.obj0 = child0;
		item.obj1 = child1;
		string id_0_1 = child0.transform.parent.gameObject.GetInstanceID().ToString() + "_" + child1.transform.parent.gameObject.GetInstanceID().ToString();
		string id_1_0 = child1.transform.parent.gameObject.GetInstanceID().ToString() + "_" + child0.transform.parent.gameObject.GetInstanceID().ToString();
		if (surfaceLinks.ContainsKey(id_0_1))
		{
			surfaceLinks[id_0_1].Add(item);
//			Debug.Log("id = "+id_0_1 + " list's count = "+surfaceLinks[id_0_1].Count);
		}
		else if (surfaceLinks.ContainsKey(id_1_0))
		{
			surfaceLinks[id_1_0].Add(item);
//			Debug.Log("id = "+id_1_0 + " list's count = "+surfaceLinks[id_1_0].Count);
		}
		else
		{
			List<LinkedObjects> list = new List<LinkedObjects>();
			list.Add(item);
			surfaceLinks.Add(id_0_1, list);
//			Debug.Log("id = "+id_0_1 + " list's count = "+list.Count);
		}
	}

	static public Transform staticTarget = null;
	static public bool verticalOrHorizontal = false;
	static public void DrawLine(Transform newTarget, bool canBeBlock, bool onSurface, bool threeAxis = false)
	{
		//if click first object then click it again, then onsurface dummy will be delete.
//		if (staticTarget!=null && onSurface && staticTarget.parent == newTarget.parent)
//			Destroy(newTarget.gameObject);
		//Start
//		if (staticTarget==null || (!onSurface && staticTarget!=newTarget) || (onSurface && staticTarget.parent != newTarget.parent) )
		if (staticTarget==null || (!onSurface && staticTarget!=newTarget) || (onSurface) )
		{
			//DrawLine Target Point
			if (staticTarget!=null)
			{
				if (!threeAxis)
				{
					if (verticalOrHorizontal)
                    {
                        Vector3 vec = newTarget.position - staticTarget.position;
                        //Horizontal Modify
                        if (Mathf.Abs(vec.y) < Mathf.Abs(vec.x) || Mathf.Abs(vec.y) < Mathf.Abs(vec.z))
                        {
                            newTarget.position = new Vector3(newTarget.position.x, staticTarget.position.y, newTarget.position.z);
                        }
                        //Vertical Modify
                        else if (Mathf.Abs(vec.y) > Mathf.Abs(vec.x) && Mathf.Abs(vec.y) > Mathf.Abs(vec.z))
                        {
                            newTarget.position = new Vector3(staticTarget.position.x, newTarget.position.y, staticTarget.position.z);
                        }
                    }
					AddLine(staticTarget, newTarget, canBeBlock, onSurface);
				}
				else
				{
					//Add Three Axis Sub Lines
					AddLine(staticTarget, newTarget, canBeBlock, onSurface);
					GameObject axisXZObj0 = null;
					GameObject axisXYObj0 = null;
					GameObject axisXZObj1 = null;
					GameObject axisXYObj1 = null;
					GameObject lowerObj = null;
					GameObject higherObj = null;
					bool leftIsLower = true;
					MeasureLineHelper.CreateThreeAxisObj(staticTarget, newTarget, out axisXZObj0, out axisXYObj0, out axisXZObj1, out axisXYObj1, out lowerObj, out higherObj);
					AddLine(higherObj.transform, axisXZObj0.transform, canBeBlock, onSurface, true); //ignoreSurfaceLinks
					AddLine(axisXZObj1.transform, axisXYObj1.transform, canBeBlock, onSurface, true); //ignoreSurfaceLinks
					AddLine(lowerObj.transform, axisXYObj0.transform, canBeBlock, onSurface, true); //ignoreSurfaceLinks
				}
			}
			//Start DrawLine Start Point
			else
			{
				if (newTarget.gameObject.GetComponent<MeasureLine> () == null) 
				{
					MeasureLine mw = newTarget.gameObject.AddComponent<MeasureLine> ();
					mw.canBeBlock = canBeBlock;
					mw.AxisX_P = false;
					mw.AxisX_N = false;
					mw.AxisY_N = false;
					mw.AxisY_P = false;
					mw.AxisZ_N = false;
					mw.AxisZ_P = false;
				}
				staticTarget = newTarget;
			}
		}
	}

	static public void EndDrawLine()
	{
		staticTarget = null;
	}

	static private bool IsExistTarget(MeasureLine mw, Transform obj)
	{
		bool result = false;
		Transform[] targetObjs = mw.targetObjects;
		if (targetObjs == null) {
			result = false;
		}
		else 
		{
			List<Transform> lists = new List<Transform> ();
			for (int i = 0; i < targetObjs.Length; i++) {
				if (targetObjs[i]==obj)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	static public void AddTarget(MeasureLine mw, Transform obj)
	{
		Transform[] targetObjs = mw.targetObjects;
		if (targetObjs == null) {
			targetObjs = new Transform[]{ obj };
		}
		else 
		{
			List<Transform> lists = new List<Transform> ();
			for (int i = 0; i < targetObjs.Length; i++) {
				if (targetObjs[i]!=obj)
				{
					lists.Add (targetObjs[i]);
				}
			}
			lists.Add (obj);
			targetObjs = lists.ToArray ();
		}
		mw.targetObjects = targetObjs;
	}

	static private void DelTarget(MeasureLine mw, Transform target)
	{
		if (mw!=null)
		{
			Transform[] targetObjs = mw.targetObjects;
			if (targetObjs!=null && targetObjs.Length>0)
			{
				List<Transform> objs = new List<Transform>();
				for (int i=0;i<targetObjs.Length;i++)
				{
					if (targetObjs[i]!=null)
						objs.Add(targetObjs[i]);
				}
				objs.Remove(target);
				targetObjs = objs.ToArray();
			}
			mw.targetObjects = targetObjs;
		}
	}

	/// <summary>
	/// For Attach to gameObject use
	/// </summary>
	void GetLineCollection()
	{
		lineCollection = GameObject.Find ("lineCollection");
		if (lineCollection == null) {
			lineCollection = new GameObject ("lineCollection");
//			lineCollection.hideFlags = HideFlags.HideInHierarchy;
		}
		lineParent = lineCollection.transform;
	}

	void Awake()
	{
		myTransform = transform;
		GetLineCollection ();
		axisDummy = new GameObject("AxisDummy").transform;
		if (coordinate == Coordinate.Local) {
			axisDummy.rotation = myTransform.rotation;
		}
		else {
			axisDummy.rotation = Quaternion.identity;
		}
		axisDummy.SetParent (myTransform);
	}

	void Start () 
	{
		if (mainCamera == null) {
			mainCamera = Camera.main;
		}
		camTransform = mainCamera.transform;
		layer = LayerMask.NameToLayer ("Ignore Raycast");
		//mat = new Material (Shader.Find ("Unlit/ColorML"));
		mat.color = lineColor;

		line_R = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_R.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_R.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		Destroy (line_R.GetComponent<BoxCollider>());
		showR = false;
		line_R.gameObject.layer = layer;
		line_R.name = "line_R";
		line_R.parent = lineParent;

		line_L = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_L.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_L.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		Destroy (line_L.GetComponent<BoxCollider>());
		showL = false;
		line_L.gameObject.layer = layer;
		line_L.name = "line_L";
		line_L.parent = lineParent;

		line_U = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_U.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_U.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		Destroy (line_U.GetComponent<BoxCollider>());
		showU = false;
		line_U.gameObject.layer = layer;
		line_U.name = "line_U";
		line_U.parent = lineParent;

		line_D = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_D.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_D.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		Destroy (line_D.GetComponent<BoxCollider>());
		showD = false;
		line_D.gameObject.layer = layer;
		line_D.name = "line_D";
		line_D.parent = lineParent;

		line_F = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_F.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_F.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		Destroy (line_F.GetComponent<BoxCollider>());
		showF = false;
		line_F.gameObject.layer = layer;
		line_F.name = "line_F";
		line_F.parent = lineParent;

		line_B = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
		line_B.localScale = new Vector3 (lineWidth, lineWidth, 1);
		lineRender = line_B.GetComponent<Renderer> ();
		lineRender.sharedMaterial = mat;
		lineRender.enabled = false;
		Destroy (line_B.GetComponent<BoxCollider>());
		lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
		lineRender.receiveShadows = false;
		showB = false;
		line_B.gameObject.layer = layer;
		line_B.name = "line_B";
		line_B.parent = lineParent;

		//Get Really Targets
		GetReallyTarget ();
		//TargetLines
		lastTargetLineCount = targets.Length;
		RefreshTargetLines ();

		//Angle Rotate and Pivot Bias
		if (coordinate == Coordinate.Local) {
			axisDummy.localEulerAngles = angle;
		}
		else {
			axisDummy.eulerAngles = angle;
		}
		axisDummy.localPosition = pivotBias;
		//Is Empty GameObject?
		isEmptyObject = (GetComponentInChildren<MeshRenderer> () == null && GetComponentInChildren<SkinnedMeshRenderer> () == null);
		//If use UICanvas
		overlayUICanvas = GameObject.Find ("Canvas_MeasureLine");
		if (overlayUICanvas == null) 
		{
			overlayUICanvas = new GameObject ("Canvas_MeasureLine", typeof(Canvas));
			overlayUICanvas.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceOverlay;
		}
		//Wait For UICanvas
		StartCoroutine (WaitForUICanvas());
		//DecimalPlaces
		if (decimalPlaces < 0)
			decimalPlaces = 0;
		else if (decimalPlaces > 8)
			decimalPlaces = 8;
	}

	IEnumerator WaitForUICanvas()
	{
		while (overlayUICanvas == null)
			yield return 0;
		
		canvasRT = overlayUICanvas.GetComponent<RectTransform> ();
		uiTextParent = GameObject.Find ("uiTextParent");
		if (uiTextParent == null) {
			uiTextParent = new GameObject ("uiTextParent");
		}
		//UITextParent
//		uiTextParent.AddComponent<RectTransform> ();
		uiTextParent.transform.SetParent (overlayUICanvas.transform);
		uiTextParent.transform.localPosition = Vector3.zero;
		//LeftText
		uiText_L = AddTextToCanvas("", new GameObject ("uiText_L"));
		uiText_L.alignment = TextAnchor.MiddleCenter;
		uiText_L.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_L.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_L.transform.SetParent (uiTextParent.transform);
		uiText_L.transform.localPosition = Vector3.zero;
		//RightText
		uiText_R = AddTextToCanvas("", new GameObject ("uiText_R"));
		uiText_R.alignment = TextAnchor.MiddleCenter;
		uiText_R.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_R.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_R.transform.SetParent (uiTextParent.transform);
		uiText_R.transform.localPosition = Vector3.zero;
		//UpText
		uiText_U = AddTextToCanvas("", new GameObject ("uiText_U"));
		uiText_U.alignment = TextAnchor.MiddleCenter;
		uiText_U.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_U.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_U.transform.SetParent (uiTextParent.transform);
		uiText_U.transform.localPosition = Vector3.zero;
		//DownText
		uiText_D = AddTextToCanvas("", new GameObject ("uiText_D"));
		uiText_D.alignment = TextAnchor.MiddleCenter;
		uiText_D.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_D.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_D.transform.SetParent (uiTextParent.transform);
		uiText_D.transform.localPosition = Vector3.zero;
		//ForwardText
		uiText_F = AddTextToCanvas("", new GameObject ("uiText_F"));
		uiText_F.alignment = TextAnchor.MiddleCenter;
		uiText_F.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_F.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_F.transform.SetParent (uiTextParent.transform);
		uiText_F.transform.localPosition = Vector3.zero;
		//BackwardText
		uiText_B = AddTextToCanvas("", new GameObject ("uiText_B"));
		uiText_B.alignment = TextAnchor.MiddleCenter;
		uiText_B.horizontalOverflow = HorizontalWrapMode.Overflow;
		uiText_B.verticalOverflow = VerticalWrapMode.Overflow;
		uiText_B.transform.SetParent (uiTextParent.transform);
		uiText_B.transform.localPosition = Vector3.zero;

		//RefreshTargetLines when uiTextParent is existed
		RefreshTargetLines();
	}

	public static Text AddTextToCanvas(string textString, GameObject textGameObject)
	{
		Text text = textGameObject.AddComponent<Text>();
		text.text = textString;

		Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		text.font = ArialFont;
		text.material = ArialFont.material;

		return text;
	}

	void GetReallyTarget()
	{
		//Get Really Targets
		targetList.Clear ();
		if (targetObjects!=null && targetObjects.Length>0)
		{
			for (int i=0; i<targetObjects.Length; i++) {
				if (targetObjects[i]!=null){
					targetList.Add(targetObjects[i]);
				}
			}
		}
		targets = targetList.ToArray ();
	}

	void OnEnable()
	{
		
	}

	void OnDisable()
	{
		//Hide Common Six Lines
		if (line_R!=null)
			line_R.GetComponent<Renderer> ().enabled = false;
		if (line_L!=null)
			line_L.GetComponent<Renderer> ().enabled = false;
		if (line_U!=null)
			line_U.GetComponent<Renderer> ().enabled = false;
		if (line_D!=null)
			line_D.GetComponent<Renderer> ().enabled = false;
		if (line_F!=null)
			line_F.GetComponent<Renderer> ().enabled = false;
		if (line_B!=null)
			line_B.GetComponent<Renderer> ().enabled = false;
		//Hide Target lines
		if (targetLines!=null && targetLines.Length>0){
			for (int i=0;i<targetLines.Length;i++){
				if (targetLines[i]!=null)
					targetLines[i].GetComponent<Renderer> ().enabled = false;
			}
		}

		//UICanvas
		if (uiText_L!=null)
			uiText_L.text = "";
		if (uiText_R!=null)
			uiText_R.text = "";
		if (uiText_U!=null)
			uiText_U.text = "";
		if (uiText_D!=null)
			uiText_D.text = "";
		if (uiText_F!=null)
			uiText_F.text = "";
		if (uiText_B!=null)
			uiText_B.text = "";
		//linkTexts
		if (linkTexts.Count > 0) {
			for (int i = 0; i < linkTexts.Count; i++) {
				if (linkTexts [i]!=null)
					linkTexts [i].text = "";
			}
		}
	}

	void OnDestroy()
	{
		//Delete Common Six Lines
		if (line_L!=null)
			DestroyImmediate(line_L.gameObject);
		if (line_R!=null)
			DestroyImmediate(line_R.gameObject);
		if (line_U!=null)
			DestroyImmediate(line_U.gameObject);
		if (line_D!=null)
			DestroyImmediate(line_D.gameObject);
		if (line_F!=null)
			DestroyImmediate(line_F.gameObject);
		if (line_B!=null)
			DestroyImmediate(line_B.gameObject);
		//Destroy Target lines
		if (targetLines!=null && targetLines.Length>0){
			for (int i=0;i<targetLines.Length;i++){
				if (targetLines[i]!=null)
					DestroyImmediate(targetLines[i].gameObject);
			}
		}
	}

	void RefreshTargetLines()
	{
		if (targetLines!=null && targetLines.Length>0){
			for (int i=0;i<targetLines.Length;i++){
				if (targetLines[i]!=null)
					Destroy(targetLines[i].gameObject);
			}
		}
		targets = targetList.ToArray ();
		//Create Target Lines
		if (targets.Length > 0) 
		{
			targetLines = new Transform[targets.Length];
			targetScreen = new Vector3[targets.Length];
			targetLength = new float[targets.Length];
			showTarget = new bool[targets.Length];

			for (int i=0; i<targets.Length; i++) {
				targetLines[i] = GameObject.CreatePrimitive (PrimitiveType.Cube).transform;
				targetLines[i].localScale = new Vector3 (lineWidth, lineWidth, 1);
				lineRender = targetLines[i].GetComponent<Renderer> ();
				lineRender.sharedMaterial = mat;
				lineRender.enabled = false;
				DestroyImmediate (targetLines[i].GetComponent<BoxCollider>());
				lineRender.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
				lineRender.receiveShadows = false;
				showTarget[i] = false;
				targetLines[i].gameObject.layer = layer;
				targetLines[i].name = gameObject.name+"_To_" + targets[i].name + "_line";
				GetLineCollection ();
				targetLines[i].parent = lineParent;
			}
		}

		if (uiTextParent == null)
			return;

		//Clear last linkTexts
		if (linkTexts.Count > 0) {
			for (int i = 0; i < linkTexts.Count; i++) {
				Destroy (linkTexts [i].gameObject);
			}
			linkTexts.Clear ();
		}
		if (targets.Length > 0) {
			for (int i=0;i<targetLines.Length;i++){
				if (ShowTargetLine && targetLines[i]!=null && InFrontOfCamera(targetLines[i].transform.position)) {
					targetScreen[i] = mainCamera.WorldToScreenPoint (targetLines[i].transform.position);
					Text uiText = AddTextToCanvas("", new GameObject ("uiText_Link"));
					uiText.color = textColor;
					uiText.fontSize = textSize;
					uiText.alignment = TextAnchor.MiddleCenter;
					uiText.horizontalOverflow = HorizontalWrapMode.Overflow;
					uiText.verticalOverflow = VerticalWrapMode.Overflow;
					uiText.transform.SetParent (uiTextParent.transform);
					uiText.transform.localPosition = Vector3.zero;
					uiText.text = NumberToPlaceString (targetLength[i], decimalPlaces);
					uiText.transform.position = ScreenToUICanvas (new Vector2 (targetScreen[i].x-textBiasX, targetScreen[i].y), canvasRT, uiText.transform);
					linkTexts.Add (uiText);
				}
			}
		}

	}


	bool InFrontOfCamera(Vector3 pos)
	{
		bool result = false;
		if (Vector3.Dot (camTransform.forward, (pos - camTransform.position).normalized) > 0) {
			result = true;
		}
		return result;
	}

	Vector3 ScreenToUICanvas(Vector2 screenPos, RectTransform canvasRT, Transform uiTarget)
	{
		Vector2 uv = new Vector2 (screenPos.x/Screen.width, screenPos.y/Screen.height);
		Vector2 destPos = new Vector2 (canvasRT.anchoredPosition.x*2*uv.x, canvasRT.anchoredPosition.y*2*uv.y);
		return new Vector3 (destPos.x, destPos.y, uiTarget.position.z);
	}

	public string NumberToPlaceString(float number, int decimalPlaces)
	{
		string formatString = "0.";
		for (int i = 0; i < decimalPlaces; i++) {
			formatString += "0";
		}

		if (StaticMetricOrImperial == MetricOrImperial.Foot)
		{
			number = number * 3.28084f;
			return Convert.ToDouble(number).ToString(formatString) + "ft";
		}
		else if (StaticMetricOrImperial == MetricOrImperial.Inches)
		{
			number = number * 3.28084f * 12f;
			return Convert.ToDouble(number).ToString(formatString) + "in";
		}
		else
		{
			return Convert.ToDouble(number).ToString(formatString) + "m";
		}
	}

	void LateUpdate()
	{
		if (overlayUICanvas == null || uiTextParent==null)
			return;

		//Color
		uiText_L.color = textColor;
		uiText_R.color = textColor;
		uiText_U.color = textColor;
		uiText_D.color = textColor;
		uiText_F.color = textColor;
		uiText_B.color = textColor;

		//Size
		uiText_L.fontSize = textSize;
		uiText_R.fontSize = textSize;
		uiText_U.fontSize = textSize;
		uiText_D.fontSize = textSize;
		uiText_F.fontSize = textSize;
		uiText_B.fontSize = textSize;

		//Decimal Places
		if (decimalPlaces < 0)
			decimalPlaces = 0;
		else if (decimalPlaces > 8)
			decimalPlaces = 8;

		mat.color = lineColor;
		line_L.localScale = new Vector3 (lineWidth, lineWidth, 1);
		line_R.localScale = new Vector3 (lineWidth, lineWidth, 1);
		line_U.localScale = new Vector3 (lineWidth, lineWidth, 1);
		line_D.localScale = new Vector3 (lineWidth, lineWidth, 1);
		line_F.localScale = new Vector3 (lineWidth, lineWidth, 1);
		line_B.localScale = new Vector3 (lineWidth, lineWidth, 1);

		//Get Really Targets
		GetReallyTarget ();
		//Refresh Target Lines
		if (lastTargetLineCount != targets.Length) {
			RefreshTargetLines();
			lastTargetLineCount = targets.Length;
		}
		if (targets.Length > 0 && targetLines!=null && targetLines.Length>0) {
			for (int i=0;i<targetLines.Length;i++){
				if (targetLines[i]!=null)
					targetLines[i].localScale = new Vector3 (lineWidth, lineWidth, 1);
			}
		}
		//Angle Rotate and Pivot Bias
		if (coordinate == Coordinate.Local) {
			axisDummy.localEulerAngles = angle;
		}
		else {
			axisDummy.eulerAngles = angle;
		}
		axisDummy.localPosition = pivotBias;
		//Show by Axis
		if (AxisX_P) {
			LineRight ();
		} else {
			line_R.GetComponent<Renderer>().enabled = false;
			showR = false;
		}
		if (AxisX_N){
			LineLeft ();
		}else{
			line_L.GetComponent<Renderer>().enabled = false;
			showL = false;
		}
		if (AxisY_P) {
			LineUp ();
		} else {
			line_U.GetComponent<Renderer>().enabled = false;
			showU = false;
		}
		if (AxisY_N){
			LineDown ();
		}else{
			line_D.GetComponent<Renderer>().enabled = false;
			showD = false;
		}
		if (AxisZ_P) {
			LineForward ();
		} else {
			line_F.GetComponent<Renderer>().enabled = false;
			showF = false;
		}
		if (AxisZ_N){
			LineBack ();
		}else{
			line_B.GetComponent<Renderer>().enabled = false;
			showB = false;
		}
		//Show Target Lines
		if (ShowTargetLine) {
			TargetLines ();
		} else {
			if (targetLines!=null && targetLines.Length > 0) {
				for (int i=0;i<targetLines.Length;i++){
					if (targetLines[i]!=null)
					{
						targetLines[i].GetComponent<Renderer>().enabled = false;
						showTarget[i] = false;
                        linkTexts[i].enabled = false;
                    }
				}
			}
		}
		//StaticMetricOrImperial
		if (lastMetricOrImperial!= metricOrImperial)
		{
			StaticMetricOrImperial = metricOrImperial;
			lastMetricOrImperial = metricOrImperial;
		}

		//Text
		if (AxisX_N && showL && InFrontOfCamera (line_L.position)) {
			screenL = mainCamera.WorldToScreenPoint (line_L.position);
			uiText_L.text = NumberToPlaceString (lengthL, decimalPlaces);
			uiText_L.transform.position = ScreenToUICanvas (new Vector2 (screenL.x - textBiasX, screenL.y), canvasRT, uiText_L.transform);
		} else {
			uiText_L.text = "";
		}

		if (AxisX_P && showR && InFrontOfCamera(line_R.position)) {
			screenR = mainCamera.WorldToScreenPoint (line_R.position);
			uiText_R.text = NumberToPlaceString (lengthR, decimalPlaces);
			uiText_R.transform.position = ScreenToUICanvas (new Vector2 (screenR.x - textBiasX, screenR.y), canvasRT, uiText_R.transform);
		} else {
			uiText_R.text = "";
		}

		if (AxisY_P && showU && InFrontOfCamera(line_U.position)) {
			screenU = mainCamera.WorldToScreenPoint (line_U.position);
			uiText_U.text = NumberToPlaceString (lengthU, decimalPlaces);
			uiText_U.transform.position = ScreenToUICanvas (new Vector2 (screenU.x - textBiasX, screenU.y), canvasRT, uiText_U.transform);
		} else {
			uiText_U.text = "";
		}

		if (AxisY_N && showD && InFrontOfCamera(line_D.position)) {
			screenD = mainCamera.WorldToScreenPoint (line_D.position);
			uiText_D.text = NumberToPlaceString (lengthD, decimalPlaces);
			uiText_D.transform.position = ScreenToUICanvas (new Vector2 (screenD.x - textBiasX, screenD.y), canvasRT, uiText_D.transform);
		} else {
			uiText_D.text = "";
		}

		if (AxisZ_P && showF && InFrontOfCamera(line_F.position)) {
			screenF = mainCamera.WorldToScreenPoint (line_F.position);
			uiText_F.text = NumberToPlaceString (lengthF, decimalPlaces);
			uiText_F.transform.position = ScreenToUICanvas (new Vector2 (screenF.x - textBiasX, screenF.y), canvasRT, uiText_F.transform);
		} else {
			uiText_F.text = "";
		}

		if (AxisZ_N && showB && InFrontOfCamera(line_B.position)) {
			screenB = mainCamera.WorldToScreenPoint (line_B.position);
			uiText_B.text = NumberToPlaceString (lengthB, decimalPlaces);
			uiText_B.transform.position = ScreenToUICanvas (new Vector2 (screenB.x - textBiasX, screenB.y), canvasRT, uiText_B.transform);
		} else {
			uiText_B.text = "";
		}

		//Update LinkTexts
		if (linkTexts.Count > 0) {
			for (int i=0;i<linkTexts.Count;i++){
				if (ShowTargetLine && showTarget[i] && targetLines[i]!=null && InFrontOfCamera(targetLines[i].transform.position)) {
					targetScreen[i] = mainCamera.WorldToScreenPoint (targetLines[i].transform.position);
					Text uiText = linkTexts[i];
					uiText.color = textColor;
					uiText.fontSize = textSize;
					uiText.alignment = TextAnchor.MiddleCenter;
					uiText.horizontalOverflow = HorizontalWrapMode.Overflow;
					uiText.verticalOverflow = VerticalWrapMode.Overflow;
					uiText.transform.SetParent (uiTextParent.transform);
					uiText.transform.localPosition = Vector3.zero;
					uiText.text = NumberToPlaceString (targetLength[i], decimalPlaces);
					uiText.transform.position = ScreenToUICanvas (new Vector2 (targetScreen[i].x-textBiasX, targetScreen[i].y), canvasRT, uiText.transform);
				}
			}
		}

	}

    //	void OnGUI()
    //	{
    //		if (overlayUICanvas != null)
    //			return;

    //		GUI.color = textColor;
    //		if (AxisX_P && showR && InFrontOfCamera(line_R.position)) {
    //			screenR = mainCamera.WorldToScreenPoint (line_R.position);
    //			GUI.Label (new Rect (screenR.x-textBiasX, Screen.height - screenR.y, 150, 50), (Mathf.Round (lengthR * 100) / 100).ToString () + "m");
    //		}
    //		if (AxisX_N && showL && InFrontOfCamera(line_L.position)) {
    //			screenL = mainCamera.WorldToScreenPoint (line_L.position);
    //			GUI.Label (new Rect (screenL.x-textBiasX, Screen.height - screenL.y, 150, 50), (Mathf.Round (lengthL * 100) / 100).ToString () + "m");
    //		}
    //		if (AxisY_P && showU && InFrontOfCamera(line_U.position)) {
    //			screenU = mainCamera.WorldToScreenPoint (line_U.position);
    //			GUI.Label (new Rect (screenU.x-textBiasX, Screen.height - screenU.y, 150, 50), (Mathf.Round (lengthU * 100) / 100).ToString () + "m");
    //		}
    //		if (AxisY_N && showD && InFrontOfCamera(line_D.position)) {
    //			screenD = mainCamera.WorldToScreenPoint (line_D.position);
    //			GUI.Label (new Rect (screenD.x-textBiasX, Screen.height - screenD.y, 150, 50), (Mathf.Round (lengthD * 100) / 100).ToString () + "m");
    //		}
    //		if (AxisZ_P && showF && InFrontOfCamera(line_F.position)) {
    //			screenF = mainCamera.WorldToScreenPoint (line_F.position);
    //			GUI.Label (new Rect (screenF.x-textBiasX, Screen.height - screenF.y, 150, 50), (Mathf.Round(lengthF*100)/100).ToString()+"m");
    //		}
    //		if (AxisZ_N && showB && InFrontOfCamera(line_B.position)) {
    //			screenB = mainCamera.WorldToScreenPoint (line_B.position);
    //			GUI.Label (new Rect (screenB.x-textBiasX, Screen.height - screenB.y, 150, 50), (Mathf.Round(lengthB*100)/100).ToString()+"m");
    //		}
    //		//Get Really Targets
    //		GetReallyTarget ();
    //		//Refresh Target Lines
    //		if (lastTargetLineCount != targets.Length) {
    //			RefreshTargetLines();
    //			lastTargetLineCount = targets.Length;
    //		}
    //		if (targets.Length > 0) {
    //			for (int i=0;i<targetLines.Length;i++){
    //				if (ShowTargetLine && showTarget[i] && targetLines[i]!=null && InFrontOfCamera(targetLines[i].transform.position)) {
    //					targetScreen[i] = mainCamera.WorldToScreenPoint (targetLines[i].transform.position);
    //					GUI.Label (new Rect (targetScreen[i].x-textBiasX, Screen.height - targetScreen[i].y, 150, 50), (Mathf.Round(targetLength[i]*100)/100).ToString()+"m");
    //				}
    //			}
    //		}
    //	}

    void Update()
    {
        //UICanvas
        if (uiText_L != null)
            uiText_L.enabled = IsShowText;
        if (uiText_R != null)
            uiText_R.enabled = IsShowText;
        if (uiText_U != null)
            uiText_U.enabled = IsShowText;
        if (uiText_D != null)
            uiText_D.enabled = IsShowText;
        if (uiText_F != null)
            uiText_F.enabled = IsShowText;
        if (uiText_B != null)
            uiText_B.enabled = IsShowText;
        //linkTexts
        if (linkTexts.Count > 0)
        {
            for (int i = 0; i < linkTexts.Count; i++)
            {
                if (linkTexts[i] != null)
                    linkTexts[i].enabled = IsShowText;
            }
        }
    }

    void TargetLines()
	{
		if (targets.Length > 0)
        {
			for (int i=0; i<targetLines.Length; i++)
            {
				if (canBeBlock)
				{
					if (Physics.Raycast (axisDummy.position, (targets[i].position - axisDummy.position).normalized, out hit_Target0, maxDistance, layerMask))
					{
                        if ((hit_Target0.transform == targets[i]) || (hit_Target0.transform != targets[i] && !MeasureLineHelper.ExistInArray(hit_Target0.transform, targets)))
                        {
                            if (Physics.Raycast(hit_Target0.point, (axisDummy.position - targets[i].position).normalized, out hit_Target1, maxDistance, layerMask))
                            {
                                if (FindParentUpwards(hit_Target1.transform, myTransform))
                                {
                                    midPoint = (hit_Target0.point + hit_Target1.point) / 2;
                                }
                                else
                                {
                                    midPoint = (hit_Target0.point + axisDummy.position) / 2;
                                }
                            }
                            else
                            {
                                midPoint = (hit_Target0.point + axisDummy.position) / 2;
                            }
                            float length = (hit_Target0.point - midPoint).magnitude * 2;
                            targetLength[i] = length;
                            Transform targetLine = targetLines[i];
                            targetLine.GetComponent<Renderer>().enabled = true;
                            showTarget[i] = true;
                            targetLine.position = midPoint;
                            Vector3 vec = hit_Target0.point - midPoint;
                            if (vec != Vector3.zero)
                                targetLine.rotation = Quaternion.LookRotation(vec);
                            targetLine.localScale = new Vector3(targetLine.localScale.x, targetLine.localScale.y, length);
                            if (IsShowText)
                            {
                                linkTexts[i].enabled = true;
                            }
                        }
					}
					else
					{
						targetLines[i].GetComponent<Renderer>().enabled = false;
                        showTarget[i] = false;
                        linkTexts[i].enabled = false;
                    }
				}
                else if ((targets[i].position - axisDummy.position).magnitude <= maxDistance)
                {
					midPoint = (targets[i].position + axisDummy.position)/2;
					float length = (targets[i].position - midPoint).magnitude*2;
					targetLength[i] = length;
					Transform targetLine = targetLines[i];
					targetLine.GetComponent<Renderer>().enabled = true;
					showTarget[i] = true;
					targetLine.position = midPoint;
					Vector3 vec = targets[i].position - midPoint;
					if (vec!=Vector3.zero)
						targetLine.rotation = Quaternion.LookRotation(vec);
					targetLine.localScale = new Vector3(targetLine.localScale.x, targetLine.localScale.y, length);
                    if (IsShowText)
                    {
                        linkTexts[i].enabled = true;
                    }
                }
			}
		}
        else
        {
            if (showTarget != null && showTarget.Length > 0)
            {
				for (int i=0;i<showTarget.Length;i++){
					showTarget[i] = false;
				}
			}
		}
	}

	void LineBack()
	{
		if (Physics.Raycast (axisDummy.position, -axisDummy.forward, out hit_Back0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Back0.point, axisDummy.forward, out hit_Back1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Back1.transform, myTransform))
				{
					midPoint = (hit_Back0.point + hit_Back1.point)/2;
				}
				else
				{
					midPoint = (hit_Back0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Back0.point + axisDummy.position)/2;
			}
			lengthB = (hit_Back0.point - midPoint).magnitude*2;
			line_B.GetComponent<Renderer>().enabled = true;
			showB = true;
			line_B.position = midPoint;
			Vector3 vec = hit_Back0.point - midPoint;
			if (vec!=Vector3.zero)
				line_B.rotation = Quaternion.LookRotation(vec);
			line_B.localScale = new Vector3(line_B.localScale.x, line_B.localScale.y, lengthB);
		}
		else
		{
			line_B.GetComponent<Renderer>().enabled = false;
			showB = false;
		}
	}

	void LineForward()
	{
		if (Physics.Raycast (axisDummy.position, axisDummy.forward, out hit_Forward0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Forward0.point, -axisDummy.forward, out hit_Forward1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Forward1.transform, myTransform))
				{
					midPoint = (hit_Forward0.point + hit_Forward1.point)/2;
				}
				else
				{
					midPoint = (hit_Forward0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Forward0.point + axisDummy.position)/2;
			}
			lengthF = (hit_Forward0.point - midPoint).magnitude*2;
			line_F.GetComponent<Renderer>().enabled = true;
			showF = true;
			line_F.position = midPoint;
			Vector3 vec = hit_Forward0.point - midPoint;
			if (vec!=Vector3.zero)
				line_F.rotation = Quaternion.LookRotation(vec);
			line_F.localScale = new Vector3(line_F.localScale.x, line_F.localScale.y, lengthF);
		}
		else
		{
			line_F.GetComponent<Renderer>().enabled = false;
			showF = false;
		}
	}

	void LineDown()
	{
		if (Physics.Raycast (axisDummy.position, -axisDummy.up, out hit_Down0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Down0.point, axisDummy.up, out hit_Down1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Down1.transform, myTransform))
				{
					midPoint = (hit_Down0.point + hit_Down1.point)/2;
				}
				else
				{
					midPoint = (hit_Down0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Down0.point + axisDummy.position)/2;
			}
			lengthD = (hit_Down0.point - midPoint).magnitude*2;
			line_D.GetComponent<Renderer>().enabled = true;
			showD = true;
			line_D.position = midPoint;
			Vector3 vec = hit_Down0.point - midPoint;
			if (vec!=Vector3.zero)
				line_D.rotation = Quaternion.LookRotation(vec);
			line_D.localScale = new Vector3(line_D.localScale.x, line_D.localScale.y, lengthD);
		}
		else
		{
			line_D.GetComponent<Renderer>().enabled = false;
			showD = false;
		}
	}

	void LineUp()
	{
		if (Physics.Raycast (axisDummy.position, axisDummy.up, out hit_Up0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Up0.point, -axisDummy.up, out hit_Up1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Up1.transform, myTransform))
				{
					midPoint = (hit_Up0.point + hit_Up1.point)/2;
				}
				else
				{
					midPoint = (hit_Up0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Up0.point + axisDummy.position)/2;
			}
			lengthU = (hit_Up0.point - midPoint).magnitude*2;
			line_U.GetComponent<Renderer>().enabled = true;
			showU = true;
			line_U.position = midPoint;
			Vector3 vec = hit_Up0.point - midPoint;
			if (vec!=Vector3.zero)
				line_U.rotation = Quaternion.LookRotation(vec);
			line_U.localScale = new Vector3(line_U.localScale.x, line_U.localScale.y, lengthU);
		}
		else
		{
			line_U.GetComponent<Renderer>().enabled = false;
			showU = false;
		}
	}

	void LineLeft()
	{
		if (Physics.Raycast (axisDummy.position, -axisDummy.right, out hit_Left0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Left0.point, axisDummy.right, out hit_Left1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Left1.transform, myTransform))
				{
					midPoint = (hit_Left0.point + hit_Left1.point)/2;
				}
				else
				{
					midPoint = (hit_Left0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Left0.point + axisDummy.position)/2;
			}
			lengthL = (hit_Left0.point - midPoint).magnitude*2;
			line_L.GetComponent<Renderer>().enabled = true;
			showL = true;
			line_L.position = midPoint;
			Vector3 vec = hit_Left0.point - midPoint;
			if (vec!=Vector3.zero)
				line_L.rotation = Quaternion.LookRotation(vec);
			line_L.localScale = new Vector3(line_L.localScale.x, line_L.localScale.y, lengthL);
		}
		else
		{
			line_L.GetComponent<Renderer>().enabled = false;
			showL = false;
		}
	}

	void LineRight()
	{
		if (Physics.Raycast (axisDummy.position, axisDummy.right, out hit_Right0, maxDistance, layerMask)) 
		{
			if (Physics.Raycast (hit_Right0.point, -axisDummy.right, out hit_Right1, maxDistance, layerMask))
			{
				if (FindParentUpwards(hit_Right1.transform, myTransform))
				{
					midPoint = (hit_Right0.point + hit_Right1.point)/2;
				}
				else
				{
					midPoint = (hit_Right0.point + axisDummy.position)/2;
				}
			}
			else
			{
				midPoint = (hit_Right0.point + axisDummy.position)/2;
			}
			lengthR = (hit_Right0.point - midPoint).magnitude*2;
			line_R.GetComponent<Renderer>().enabled = true;
			showR = true;
			line_R.position = midPoint;
			Vector3 vec = hit_Right0.point - midPoint;
			if (vec!=Vector3.zero)
				line_R.rotation = Quaternion.LookRotation(vec);
			line_R.localScale = new Vector3(line_R.localScale.x, line_R.localScale.y, lengthR);
		}
		else
		{
			line_R.GetComponent<Renderer>().enabled = false;
			showR = false;
		}
	}

	static public bool FindParentUpwards(Transform child, Transform targetParent)
	{
		bool result = false;
		if (child == targetParent) {
			result = true;
		}
		else{
			Transform parent = child.parent;
			while (parent!=null) {
				if (parent == targetParent){
					result = true;
					break;
				}
				else{
					parent = parent.parent;
				}
			}
		}
		return result;
	}

}



