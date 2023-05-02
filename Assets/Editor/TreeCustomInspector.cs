using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Tree))]
public class TreeCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        Tree tree = (Tree)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Build Tree")) tree.BuildTree();
        else if (GUILayout.Button("Clear")) tree.Clear();
        else if (GUILayout.Button("Clear and Build")) { tree.Clear(); tree.BuildTree(); }
    }
}
