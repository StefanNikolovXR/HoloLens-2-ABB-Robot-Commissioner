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
	/// Transform Yaw Right
	/// </summary>	
	private static void YawRight()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Yaw Right");
		foreach(Transform t in Selection.transforms)
		{	
			RotateIt(t, new Vector3(0.0f, rotateAmount, 0.0f));
		}
	}
	
	/// <summary>
	/// Transform Yaw Left
	/// </summary>	
	private static void YawLeft()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Yaw Left");
		foreach(Transform t in Selection.transforms)
		{	
			RotateIt(t, new Vector3(0.0f, -rotateAmount, 0.0f));
		}
	}
	
	/// <summary>
	/// Transform Roll Left
	/// </summary>	
	private static void RollLeft()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Roll Left");
		foreach(Transform t in Selection.transforms)
		{		
			RotateIt(t, new Vector3(rotateAmount, 0.0f, 0.0f));
		}
	}
	
	/// <summary>
	/// Transform Roll Right
	/// </summary>	
	private static void RollRight()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Roll Right");
		foreach(Transform t in Selection.transforms)
		{		
			RotateIt(t, new Vector3(-rotateAmount, 0.0f, 0.0f));
		}
	}
	
	/// <summary>
	/// Transform Pitch Up
	/// </summary>	
	private static void PitchUp()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Pitch Up");
		foreach(Transform t in Selection.transforms)
		{
			RotateIt(t, new Vector3(0.0f, 0.0f, rotateAmount));
		}
	}
	
	/// <summary>
	/// Transform Pitch Down
	/// </summary>	
	private static void PitchDown()
	{
		Undo.RecordObjects(Selection.transforms, "Rotate Pitch Down");
		foreach(Transform t in Selection.transforms)
		{
			RotateIt(t, new Vector3(0.0f, 0.0f, -rotateAmount));
		}		
	}
	
	/// <summary>
	/// Reset transform rotation
	/// </summary>	
	private static void ResetRotation()
	{
		Undo.RecordObjects(Selection.transforms, "Reset Rotation");
		foreach(Transform t in Selection.transforms)
		{
			t.rotation = Quaternion.identity;
		}
	}
	
	/// <summary>
	/// Rotate a transform by a given angle
	/// </summary>	
	private static void RotateIt(Transform aTransform, Vector3 anAngle)
	{
		if (aTransform != null)
		{
			aTransform.Rotate(anAngle, rotationSpace);
		}
	}
}
