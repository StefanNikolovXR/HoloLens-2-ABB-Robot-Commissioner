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
	/// Nudge in X direction
	/// </summary>
	private static void NudgeX()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge X");
		foreach(Transform t in Selection.transforms)
		{
			NudgeIt(t, new Vector3(nudge.x, 0.0f, 0.0f));
		}
	}
	
	/// <summary>
	/// Nudge in -X direction
	/// </summary>
	private static void NudgeNegX()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge -X");
		foreach(Transform t in Selection.transforms)
		{
			NudgeIt(t, new Vector3(-nudge.x, 0.0f, 0.0f));
		}
	}
	
	/// <summary>
	/// Nudge in Y direction
	/// </summary>
	private static void NudgeY()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge Y");
		foreach(Transform t in Selection.transforms)
		{	
			NudgeIt(t, new Vector3(0.0f, nudge.y, 0.0f));
		}
	}
	
	/// <summary>
	/// Nudge in -Y direction
	/// </summary>
	private static void NudgeNegY()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge -Y");
		foreach(Transform t in Selection.transforms)
		{		
			NudgeIt(t, new Vector3(0.0f, -nudge.y, 0.0f));
		}
	}
	
	/// <summary>
	/// Nudge in Z direction
	/// </summary>
	private static void NudgeZ()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge Z");
		foreach(Transform t in Selection.transforms)
		{		
			NudgeIt(t, new Vector3(0.0f, 0.0f, nudge.z));
		}
	}
	
	/// <summary>
	/// Nudge in -Z direction
	/// </summary>
	private static void NudgeNegZ()
	{
		Undo.RecordObjects(Selection.transforms, "Nudge -Z");
		foreach(Transform t in Selection.transforms)
		{
			NudgeIt(t, new Vector3(0.0f, 0.0f, -nudge.z));
		}
	}
	
	/// <summary>
	/// Moves a given transform in a given direction
	/// </summary>
	/// <param name="aTransform">
	/// A <see cref="Transform"/>
	/// </param>
	/// <param name="anAmount">
	/// A <see cref="Vector3"/>
	/// </param>
	private static void NudgeIt(Transform aTransform, Vector3 anAmount)
	{
		if (aTransform != null)
		{
			aTransform.Translate(anAmount, nudgeSpace);
		}
	}
}
