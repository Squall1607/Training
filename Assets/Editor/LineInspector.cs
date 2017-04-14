using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Line))]
public class LineInspector : Editor {

	private void OnSceneGUI(){
		Line line = target as Line;

		#region Convert the point into World Space
		Transform handleTransform = line.transform;
		#region Get transform's rotation to show position handles for 2 points, Use Tools.pivotRotation to determine the current mode and set rotation accordingly
		Quaternion handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
		#endregion
		Vector3 p0 = handleTransform.TransformPoint(line.p0);
		Vector3 p1 = handleTransform.TransformPoint(line.p1);
		#endregion

		#region Draw a White Line
		Handles.color = Color.white;
		Handles.DrawLine (p0, p1);
		Handles.DoPositionHandle(p0, handleRotation);
		Handles.DoPositionHandle(p1, handleRotation);
		#endregion

		#region Convert position back into the line's local space
		EditorGUI.BeginChangeCheck();
		p0 = Handles.DoPositionHandle(p0,handleRotation);
		if(EditorGUI.EndChangeCheck()){
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.p0 = handleTransform.InverseTransformPoint(p0);
		}
		EditorGUI.BeginChangeCheck();
		p1 = Handles.DoPositionHandle(p1,handleRotation);
		if(EditorGUI.EndChangeCheck()){
			Undo.RecordObject(line, "Move Point");
			EditorUtility.SetDirty(line);
			line.p1 = handleTransform.InverseTransformPoint(p1);
		}
		#endregion
	}

}
