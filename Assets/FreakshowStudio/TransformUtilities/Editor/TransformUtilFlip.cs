/*! 
 * \file
 * \author Stig Olavsen <stig.olavsen@freakshowstudio.com>
 * \author http://www.freakshowstudio.com
 * \date © 2011-2015
 */

using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

public partial class TransformUtil : EditorWindow
{
	/// <summary>
	/// Flip active transform in X direction
	/// </summary>
	private static void FlipX()
	{
		Undo.RecordObjects(Selection.transforms, "Flip X");
		foreach(Transform t in Selection.transforms)
		{
			Undo.RecordObject(t, "Flip X " + t.name);
			t.localScale = 
				new Vector3(-t.localScale.x,
				            t.localScale.y,
				            t.localScale.z);
		}
	}
	
	/// <summary>
	/// Flip active transform in Y direction
	/// </summary>
	private static void FlipY()
	{
		Undo.RecordObjects(Selection.transforms, "Flip Y");
		foreach(Transform t in Selection.transforms)
		{
			Undo.RecordObject(t, "Flip Y " + t.name);
			t.localScale = 
				new Vector3(t.localScale.x,
				            -t.localScale.y,
				            t.localScale.z);
		}
	}

	/// <summary>
	/// Flip active transform in Z direction
	/// </summary>
	private static void FlipZ()
	{
		Undo.RecordObjects(Selection.transforms, "Flip Z");
		foreach(Transform t in Selection.transforms)
		{
			t.localScale = 
				new Vector3(t.localScale.x,
				            t.localScale.y,
				            -t.localScale.z);
		}
	}
}
