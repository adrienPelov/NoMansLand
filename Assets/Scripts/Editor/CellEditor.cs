using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Cell))]
public class CellEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Cell targetScript = target as Cell;

		targetScript.UpdateCellColor();
	}
}
