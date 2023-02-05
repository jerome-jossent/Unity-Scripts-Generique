using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(_NotesInInspector))]
public class ScriptlessEditor : Editor
{
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawPropertiesExcluding(serializedObject, _dontIncludeMe);
        serializedObject.ApplyModifiedProperties();
    }
}