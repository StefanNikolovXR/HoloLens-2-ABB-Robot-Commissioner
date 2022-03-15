using UnityEngine;
using UnityEditor;//needed for Editor

[CustomEditor(typeof(ColorSwitcher))]//use colorswitcher
[CanEditMultipleObjects]//use multiple  objects
public class CS_CustomInspector : Editor // inherit from Editor
{

	float setInterval = 0f;//used to set the interval for all
	public override void OnInspectorGUI () 
	{

		ColorSwitcher myScript = (ColorSwitcher)target;//target the script an save it in a variable


		EditorGUILayout.HelpBox ("Color Switcher by OctoMan V 1.04", MessageType.Info);
		myScript.enable = EditorGUILayout.Toggle ("Enable", myScript.enable);//show enable checkbox and text
		myScript.reverse = EditorGUILayout.Toggle ("Reverse", myScript.reverse);//show reverse checkbox and text
		myScript.pingPong = EditorGUILayout.Toggle ("PingPong", myScript.pingPong);//show pingpong checkbox and text
		myScript.useCurrentAsFirst = EditorGUILayout.Toggle ("Use Current as First", myScript.useCurrentAsFirst);//show usecurrentas first checkbox and text

		myScript.beginWithElement = EditorGUILayout.IntField ("Begin with Element", myScript.beginWithElement);//show beginWithElement intfield and text

		serializedObject.Update ();//needed to use switcher as propertydrawer and update it properly
		SerializedProperty myArray = serializedObject.FindProperty("switcherElements");
		EditorGUILayout.PropertyField(myArray,true);//inititialize the array and draw it- true to affect children

		//cap size of beginWithElement in the Inspector to avoid bigger or smaller values
		int sizeCheck = 0;//needed to check and used for the math
		if (myArray.arraySize > 0)//if the array is bigger than 0
		{
			sizeCheck = myArray.arraySize - 1;//set sizeCheck to the right size
		}
		myScript.beginWithElement = Mathf.Clamp (myScript.beginWithElement, 0, sizeCheck);//set and clamp beginWithElement

		// TODO - Cap intervals

		


		EditorGUILayout.Space ();//just leave a line free
		EditorGUILayout.BeginHorizontal ();//put all following in one line
		setInterval = EditorGUILayout.FloatField ("set all Intervals to: ", setInterval);//create floatfield
		if (GUILayout.Button ("Set")) //show button
		{
			if(myScript.switcherElements.Length>0)//check if there is at 1 color in the list
			{
				for(int i = 0; i< myScript.switcherElements.Length; i++)//count through all elements
				{
					myScript.switcherElements[i].interval = setInterval;//and set them to the given interval
				}
			}
			else
			{
				Debug.Log("<color=red>Fatal error:</color>You need at least 1 color in ColorSwitcher!");
			}
		}
		EditorGUILayout.EndHorizontal ();//end put all in one line



		serializedObject.ApplyModifiedProperties ();// apply all modiefied things in switcher
	}
}
