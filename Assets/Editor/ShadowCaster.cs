using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoShadowCaster))]
public class ShadowCASTER : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AutoShadowCaster generator = (AutoShadowCaster)target;
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        if (GUILayout.Button("Generate"))
        {

            generator.Generate();

        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Destroy All Children"))
        {

            generator.DestroyAllChildren();

        }
    }
}
