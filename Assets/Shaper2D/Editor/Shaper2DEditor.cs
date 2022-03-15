using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;
using System;

[CustomEditor(typeof(Shaper2D))]
public class Shaper2DEditor : Editor{

	private Shaper2D script;
	
	[MenuItem("GameObject/2D Object/Shaper 2D")]
	static void Create(){
		GameObject go=new GameObject();
		go.AddComponent<Shaper2D>();
		go.name="Shaper 2D";
		go.transform.position=new Vector3(SceneView.lastActiveSceneView.pivot.x,SceneView.lastActiveSceneView.pivot.y,0f);
		if(Selection.activeGameObject!=null) go.transform.parent=Selection.activeGameObject.transform;
		Selection.activeGameObject=go;
	}

	void Awake(){
		script=(Shaper2D)target;		
	}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		//Show triangle count
		EditorGUILayout.BeginHorizontal();
		GUILayout.Box(new GUIContent("Triangle count: "+script.triangleCount.ToString()),EditorStyles.helpBox);
		EditorGUILayout.EndHorizontal();
		//Collider
		ColType colliderType=(ColType)EditorGUILayout.EnumPopup(new GUIContent("Auto collider 2D","Automatically create a collider. Set to \"None\" if you want to create your collider by hand"),script.colliderType);
		if(colliderType!=script.colliderType){
			Undo.RecordObject(script,"Change collider type");
			script.colliderType=colliderType;
			AddCollider(colliderType);
			script.UpdateCollider();
			EditorUtility.SetDirty(script);
			EditorGUIUtility.ExitGUI();
		}
		//Export mesh
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel(new GUIContent("Export mesh","Save mesh as a separate prefab in project root"));
		if(GUILayout.Button("Export mesh asset")){
			ExportMesh();
		}
		EditorGUILayout.EndHorizontal();
		
		//Sorting layer options
		GUILayout.Space(10);
		//Get sorting layers
		int[] layerIDs=GetSortingLayerUniqueIDs();
		string[] layerNames=GetSortingLayerNames();
		//Get selected sorting layer
		int selected=-1;
		for(int i=0;i<layerIDs.Length;i++){
			if(layerIDs[i]==script.sortingLayer){
				selected=i;
			}
		}
		//Select Default layer if no other is selected
		if(selected==-1){
			for(int i=0;i<layerIDs.Length;i++){
				if(layerIDs[i]==0){
					selected=i;
				}
			}
		}
		//Sorting layer dropdown
		EditorGUI.BeginChangeCheck();
		GUIContent[] dropdown=new GUIContent[layerNames.Length+2];
		for(int i=0;i<layerNames.Length;i++){
			dropdown[i]=new GUIContent(layerNames[i]);
		}
		dropdown[layerNames.Length]=new GUIContent();
		dropdown[layerNames.Length+1]=new GUIContent("Add Sorting Layer...");
		selected=EditorGUILayout.Popup(new GUIContent("Sorting Layer","Name of the Renderer's sorting layer"),selected,dropdown);
		if(EditorGUI.EndChangeCheck()){
			Undo.RecordObject(script,"Change sorting layer");
			if(selected==layerNames.Length+1){
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Tags and Layers");
			}else{
				script.sortingLayer=layerIDs[selected];
			}
			EditorUtility.SetDirty(script);
		}
		//Order in layer field
		EditorGUI.BeginChangeCheck();
		int order=EditorGUILayout.IntField("Order in Layer",script.orderInLayer);
		if(EditorGUI.EndChangeCheck()){
			Undo.RecordObject(script,"Change order in layer");
			script.orderInLayer=order;
			EditorUtility.SetDirty(script);
		}
	}

	void AddCollider(ColType type){
		bool ok=true;
		if(script.GetComponent<Collider2D>()!=null){
			ok=EditorUtility.DisplayDialog("Warning","This will remove existing Collider2D with all its settings.","Remove","Cancel");
			if(ok){
				while(script.GetComponent<Collider2D>()!=null){
					DestroyImmediate(script.GetComponent<Collider2D>());
				}
				while(script.GetComponent<PlatformEffector2D>()!=null){
					DestroyImmediate(script.GetComponent<PlatformEffector2D>());
				}
			}
		}
		if(ok && type!=ColType.None){
			if(type==ColType.Polygon){
				script.gameObject.AddComponent<PolygonCollider2D>();
			}else if(type==ColType.Edge){
				script.gameObject.AddComponent<EdgeCollider2D>();
			}
			UnityEditorInternal.InternalEditorUtility.SetIsInspectorExpanded(script.GetComponent<PolygonCollider2D>(),false);
			UnityEditorInternal.InternalEditorUtility.SetIsInspectorExpanded(script.GetComponent<EdgeCollider2D>(),false);
			script.UpdateCollider();
			EditorGUIUtility.ExitGUI();
		}
	}

	void ExportMesh(){
		Mesh mesh=script.GetMesh();
		if(System.IO.File.Exists("Assets/"+mesh.name.ToString()+".asset") && !EditorUtility.DisplayDialog("Warning","Asset with this name already exists in root of your project.","Overwrite","Cancel")){
			return;
		}
		AssetDatabase.CreateAsset(UnityEngine.Object.Instantiate(mesh),"Assets/"+mesh.name.ToString()+".asset");
		AssetDatabase.SaveAssets();
	}

	//Get the sorting layer IDs
	public int[] GetSortingLayerUniqueIDs() {
		Type internalEditorUtilityType=typeof(InternalEditorUtility);
		PropertyInfo sortingLayerUniqueIDsProperty=internalEditorUtilityType.GetProperty("sortingLayerUniqueIDs",BindingFlags.Static|BindingFlags.NonPublic);
		return (int[])sortingLayerUniqueIDsProperty.GetValue(null,new object[0]);
	}

	//Get the sorting layer names
	public string[] GetSortingLayerNames(){
		Type internalEditorUtilityType=typeof(InternalEditorUtility);
		PropertyInfo sortingLayersProperty=internalEditorUtilityType.GetProperty("sortingLayerNames",BindingFlags.Static|BindingFlags.NonPublic);
		return (string[])sortingLayersProperty.GetValue(null,new object[0]);
	}

}
