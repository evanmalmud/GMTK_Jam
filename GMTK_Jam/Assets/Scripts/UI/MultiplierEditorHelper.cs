using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ScorePointsSpawn;

[CustomEditor(typeof(MultiplierEntry))]
public class MultiplierEditorHelper : Editor
{
    public override void OnInspectorGUI()
    {
        var script = (MultiplierEntry)target;

        script.multiVal = EditorGUILayout.IntField("multiVal", script.multiVal);
        script.multiString = EditorGUILayout.TextField("multiString", script.multiString);
        script.enemiesRequired = EditorGUILayout.IntField("enemiesRequired", script.enemiesRequired);
        script.timeRequired = EditorGUILayout.FloatField("timeRequired", script.timeRequired);
        script.bumperMinus = EditorGUILayout.IntField("bumperMinus", script.bumperMinus);
    }
}