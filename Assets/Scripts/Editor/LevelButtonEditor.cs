using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelButton))]
public class LevelButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelButton targetMenuButton = (LevelButton)target;
        DrawDefaultInspector();
    }

}
