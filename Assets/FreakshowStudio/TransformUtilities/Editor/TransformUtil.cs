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

/// <summary>
/// The TransformUtil class contains all functionallity.
/// 
/// Definition is separated in multiple files using a partial
/// class definition.
/// </summary>
public partial class TransformUtil : EditorWindow
{
	/// <summary>
	/// Unity OnEnable function, uses onSceneGUIDelegate to enable drawing 
	/// the grid in the scene view with DrawInScene() function.
	/// </summary>
	void OnEnable()
	{
		SceneView.onSceneGUIDelegate = DrawInScene;
	}
	
	
	/// <summary>
	/// Shows the config and control window in Unity.
	/// </summary>
	private static void SettingsGUI()
	{
		TransformUtil tu = (TransformUtil) GetWindow<TransformUtil>();
		tu.title = "Transform Util";
		tu.Show();
	}
	
	
	/// <summary>
	/// This is the delegate function given to SceneView.onSceneGUIDelegate
	/// which allows us to draw the grid in the scene view.
	/// </summary>
	/// <param name="sv">
	/// A <see cref="SceneView"/>
	/// </param>
	static void DrawInScene(SceneView sv)
	{
		if (showGridXZ)
		{
			DrawXZGrid();
		}
		if (showGridYX)
		{
			DrawYXGrid();
		}
		if (showGridYZ)
		{
			DrawYZGrid();
		}
	}
}
