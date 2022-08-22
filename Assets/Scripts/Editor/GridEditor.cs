using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Grid targetScript = target as Grid;

		if (GUILayout.Button("Generate Grid"))
		{
			targetScript.GenerateGrid();
		}

		if (GUILayout.Button("Flush Grid"))
		{
			targetScript.FlushGrid();
		}
	}
}
