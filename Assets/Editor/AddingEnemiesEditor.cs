using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AddingEnemies))]
public class AddingEnemiesEditor : Editor {

    /// <summary>
    /// add button to the inspector for adding new enemies
    /// </summary>
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AddingEnemies addingScript = (AddingEnemies)target;

        if (GUILayout.Button("Add enemy"))
        {
            addingScript.AddEnemy();
        }
    }
}
