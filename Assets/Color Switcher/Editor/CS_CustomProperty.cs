using System.Collections;
using UnityEngine;
using UnityEditor;//needed for PropertyDrawer

[CustomPropertyDrawer(typeof(switcher))]//make use of my custom class switcher
[CanEditMultipleObjects]//make it useable on more than one object
public class CS_CustomProperty : PropertyDrawer//inherit from PropertyDrawer
{
	const int size = 50;//fixed width in the rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		label = EditorGUI.BeginProperty(position, label, property);// handle default labels, bold font for prefab overrides, revert to prefab right click menu and so on
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);//show Element Names(Element 0, Element 1 ...)
		contentPosition.width *= 0.25f;//content width 25%

		if(property.isArray)//Is this property an array?
		{
			EditorGUI.PropertyField (position, property, false);//needed to make switcher usable without beeing redrawn (Null Reference)
		}
		else
		{
		int indent = EditorGUI.indentLevel;//save current indentlevel
		EditorGUI.indentLevel = 0;//set the indent level

		EditorGUIUtility.labelWidth = 60f;//labelwidth of text
		EditorGUI.PropertyField (new Rect (position.width - 280, position.y, size*2, position.height),property.FindPropertyRelative ("interval"), new GUIContent("Interval"));//draw the intervalfield
		EditorGUIUtility.labelWidth = 80f;//labelwidth of text
		EditorGUI.PropertyField (new Rect (position.width - 170, position.y, 100f, position.height),property.FindPropertyRelative ("fadeToNext"), new GUIContent("FadeToNext"));//draw fadetonext
		EditorGUI.PropertyField (new Rect (position.width - size, position.y, size, position.height),property.FindPropertyRelative ("color"), GUIContent.none);//show color
		
		EditorGUI.indentLevel = indent;//set it back to the saved indent

		EditorGUI.EndProperty();// end - handle default labels, bold font for prefab overrides, revert to prefab right click menu and so on
		}
	}
}
