using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class Shaper2D:MonoBehaviour{

	Mesh mesh;
	List<Vector3> vertices=new List<Vector3>(200);
	List<Vector3> uvs=new List<Vector3>(200);
	List<Color> colors=new List<Color>(200);
	int[] triangles=new int[0];

	public Color innerColor;
	Color innerColorPrev;
	public Color outerColor;
	Color outerColorPrev;
	[Range(3,100)]
	public int sectorCount=36;
	int sectorCountPrev;
	[Range(0,360)]
	public float arcDegrees=360;
	float arcDegreesPrev;
	[Range(0,360)]
	public float rotation=90;
	float rotationPrev;
	public float innerRadius=1.5f;
	float innerRadiusPrev;
	public float outerRadius=2f;
	float outterRadiusPrev;
	[Range(0f,1f)]
	public float starrines=0f;
	float starrinesPrev;

	[HideInInspector]
	public ColType colliderType=ColType.None;
	private ColType _colliderType;

	[HideInInspector]
	public int sortingLayer=0;
	private int _sortingLayer;

	[HideInInspector]
	public int orderInLayer=0;
	private int _orderInLayer=0;

	//Private
	float a,radiusPlus;
	bool isCanvas=false;
	CanvasRenderer cr;
	MeshFilter mf;
	MeshRenderer mr;
	[HideInInspector]
	public Material useMaterial=null;


	void Awake(){
		//Get material to use
		if(useMaterial==null) useMaterial=(Material)Resources.Load("Shaper2DMaterial",typeof(Material));
		//Check there's a Canvas in parents of the object
		if(isCanvas!=isChildOfCanvas(transform)){
			isCanvas=!isCanvas;
			TakeCareOfComponenets();
		}
		//Create random color if no color is set
		if(innerColor.a==0){
			float hue=Random.Range(0f,1f);
			while((hue*360f)>=236f && (hue*360f)<=246f){
				hue=Random.Range(0f,1f);
			}
			float saturation=Random.Range(0.9f,1f);
			innerColor=Color.HSVToRGB(hue,saturation/2,1f);
			outerColor=innerColor;
		}
		TakeCareOfComponenets();
		ApplyChangesIfAny();
	}

	void Update(){
		//Get material to use
		if(useMaterial==null) useMaterial=(Material)Resources.Load("Shaper2DMaterial",typeof(Material));
		//Check there's a Canvas in parents of the object
		if(isCanvas!=isChildOfCanvas(transform)){
			isCanvas=!isCanvas;
			TakeCareOfComponenets();
		}
		#if UNITY_EDITOR
		Tools.pivotMode=PivotMode.Pivot;
		if(transform.hasChanged){
			if(isCanvas!=isChildOfCanvas(transform)){
				isCanvas=!isCanvas;
				TakeCareOfComponenets();
			}
		}
		#endif
		ApplyChangesIfAny();
	}

	//Add/remove componenets depending on parent
	void TakeCareOfComponenets(){
		if(isCanvas){
			DestroyImmediate(GetComponent<MeshFilter>());
			DestroyImmediate(GetComponent<MeshRenderer>());
			if(GetComponent<CanvasRenderer>()==null) gameObject.AddComponent<CanvasRenderer>();
			cr=GetComponent<CanvasRenderer>();
			cr.SetMaterial(useMaterial,null);
		}else{
			DestroyImmediate(GetComponent<CanvasRenderer>());
			if(GetComponent<MeshFilter>()==null) gameObject.AddComponent<MeshFilter>();
			if(GetComponent<MeshRenderer>()==null) gameObject.AddComponent<MeshRenderer>();
			mf=GetComponent<MeshFilter>();
			mr=GetComponent<MeshRenderer>();
			mr.sharedMaterial=useMaterial;
			sortingLayer=mr.sortingLayerID;
			orderInLayer=mr.sortingOrder;
		}
	}

	void ApplyChangesIfAny(bool force=false){
		if(somethingChanged || transform.hasChanged || force){
			//Dont allow radius to be negative
			if(innerRadius<0) innerRadius=0f;
			if(outerRadius<0) outerRadius=0f;
			//Don't allow inner radius to be bigger than outter radius
			if(innerRadius>=outerRadius) outerRadius=innerRadius+0.1f;
			if(outerRadius<=innerRadius) innerRadius=outerRadius-0.1f;
			//When generating a star, we only allow even numbr of sectors larger or equal than 6
			//6 sectors is a star with 3 points
			if(starrines>0){
				if(sectorCount<6) sectorCount=6;
				if(sectorCount%2!=0) sectorCount++;
			}
			MakeMesh();
			if(isCanvas){
				if(cr==null) cr=GetComponent<CanvasRenderer>();
				if(cr==null) TakeCareOfComponenets();
				cr.SetMesh(mesh);
			}else{
				if(mf==null) mf=GetComponent<MeshFilter>();
				if(mf==null) TakeCareOfComponenets();
				mf.sharedMesh=mesh;
			}
			if(mr!=null){
				mr.sortingLayerID=sortingLayer;
				mr.sortingOrder=orderInLayer;
			}
		}
	}

	bool isChildOfCanvas(Transform t){
		if(t.GetComponent<Canvas>()!=null){
			return true;
		}else if(t.parent!=null){
			return isChildOfCanvas(t.parent);
		}else{
			return false;
		}
	}

	bool somethingChanged{
		get{
			bool change=false;
			if(innerColor!=innerColorPrev){
				innerColorPrev=innerColor;
				change=true;
			}
			if(outerColor!=outerColorPrev){
				outerColorPrev=outerColor;
				change=true;
			}
			if(sectorCount!=sectorCountPrev){
				sectorCountPrev=sectorCount;
				change=true;
			}
			if(arcDegrees!=arcDegreesPrev){
				arcDegreesPrev=arcDegrees;
				change=true;
			}
			if(rotation!=rotationPrev){
				rotationPrev=rotation;
				change=true;
			}
			if(outerRadius!=outterRadiusPrev){
				outterRadiusPrev=outerRadius;
				change=true;
			}
			if(innerRadius!=innerRadiusPrev){
				innerRadiusPrev=innerRadius;
				change=true;
			}
			if(starrines!=starrinesPrev){
				starrinesPrev=starrines;
				change=true;
			}
			if(_sortingLayer!=sortingLayer){
				_sortingLayer=sortingLayer;
				change=true;
			}
			if(_orderInLayer!=orderInLayer){
				_orderInLayer=orderInLayer;
				change=true;
			}
			return change;
		}
	}

	//Called whenever we need to regenerate the mesh
	private void MakeMesh(){
		if(mesh==null){
			mesh=new Mesh();
			mesh.name="Shaper2D";
		}
		mesh.Clear();
		if(innerRadius==0){
			GenerateCircle();
		}else{
			GenerateArc();
		}
		if(colliderType!=ColType.None) UpdateCollider();
	}

	public Mesh GetMesh(){
		return mesh;
	}

	public int triangleCount{
		get{return triangles.Length/3;}
	}

	public void UpdateCollider(){
		Collider2D col=GetComponent<Collider2D>();
		if(col!=null){
			Vector2[] cpoints=new Vector2[vertices.Count];
			for(int i=0;i<vertices.Count;i++){
				cpoints[i]=(Vector2)vertices[i];
			}
			if(col.GetType()==typeof(UnityEngine.PolygonCollider2D)){
				GetComponent<PolygonCollider2D>().points=cpoints;
			}else if(col.GetType()==typeof(UnityEngine.EdgeCollider2D)){
				GetComponent<EdgeCollider2D>().points=cpoints;
			}
		}
	}

	void GenerateCircle(){
		vertices.Clear();
		colors.Clear();
		radiusPlus=0f;
		int realSectorCount=sectorCount;
		if(arcDegrees!=360f) realSectorCount++;
		for(int i=0;i<realSectorCount;i++){
			a=(((arcDegrees/sectorCount)*i+rotation)*Mathf.Deg2Rad);
			if(starrines>0){
				if(i%2==0) radiusPlus=(outerRadius*starrines);
				else radiusPlus=-(outerRadius*starrines);
			}
			vertices.Add(new Vector2(
				(float)(Mathf.Cos(a)*(outerRadius+radiusPlus)),
				(float)(Mathf.Sin(a)*(outerRadius+radiusPlus))
			));
			colors.Add(outerColor);
		}
		vertices.Add(Vector3.zero);
		colors.Add(innerColor);
		mesh.SetVertices(vertices);
		mesh.SetColors(colors);
		SetUVs();
		int trianglesNum=vertices.Count-1; //-1 because last point is center
		if(arcDegrees!=360f) trianglesNum--; //Downt join the ends
		if(triangles==null || triangles.Length!=trianglesNum*3) triangles=new int[trianglesNum*3];
		for(int i=0;i<trianglesNum;i++){
			triangles[(i*3)+0]=(i+1==vertices.Count-1?0:i+1);
			triangles[(i*3)+1]=i;
			triangles[(i*3)+2]=vertices.Count-1;
		}
		mesh.SetTriangles(triangles,0);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
	}

	void GenerateArc(){
		vertices.Clear();
		colors.Clear();
		radiusPlus=0f;
		for(int i=0;i<(sectorCount+1);i++){
			a=((((arcDegrees/((sectorCount+1)-1))*i))+rotation)*Mathf.Deg2Rad;
			if(starrines>0){
				if(i%2==0) radiusPlus=(outerRadius*starrines);
				else radiusPlus=-(outerRadius*starrines);
			}
			vertices.Add(new Vector3(
				(float)(Mathf.Cos(a)*(outerRadius+radiusPlus)),
				(float)(Mathf.Sin(a)*(outerRadius+radiusPlus))
			));
			colors.Add(outerColor);
		}
		for(int i=(sectorCount+1)-1;i>=0;i--){
			a=((arcDegrees/((sectorCount+1)-1))*i)+rotation;
			if(starrines>0){
				if(i%2==0) radiusPlus=(innerRadius*starrines);
				else radiusPlus=-(innerRadius*starrines);
			}
			vertices.Add(new Vector3(
				(float)(Mathf.Cos(a*Mathf.Deg2Rad)*(innerRadius+radiusPlus)),
				(float)(Mathf.Sin(a*Mathf.Deg2Rad)*(innerRadius+radiusPlus))
			));
			colors.Add(innerColor);
		}
		mesh.SetVertices(vertices);
		mesh.SetColors(colors);

		SetUVs();

		if(triangles==null || triangles.Length!=sectorCount*6) triangles=new int[sectorCount*6];
		for(int i=0;i<sectorCount;i++){
			//First triangle
			triangles[(i*6)+0]=i+1;
			triangles[(i*6)+1]=i;
			triangles[(i*6)+2]=vertices.Count-(i+1);
			//Second triangle
			triangles[(i*6)+3]=i+1;
			triangles[(i*6)+4]=vertices.Count-(i+1);
			triangles[(i*6)+5]=vertices.Count-(i+2);
		}
		mesh.SetTriangles(triangles,0);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
	}

	void SetUVs(){
		uvs.Clear();
		for(int i=0;i<vertices.Count;i++){
			uvs.Add(Vector3.zero);
		}
		mesh.SetUVs(0,uvs);
	}

}


public enum ColType{None,Polygon,Edge};
