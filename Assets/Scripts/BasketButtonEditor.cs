using UnityEditor;

[CustomEditor(typeof(BasketButton))]
public class BasketButtonEditor: Editor
{
    public override void OnInspectorGUI()
    {
        BasketButton targetMenuButton = (BasketButton)target;

        //targetMenuButton.acceptsPointerInput = EditorGUILayout.Toggle("Accepts pointer input", targetMenuButton.acceptsPointerInput);

        // Show default inspector property editor
        DrawDefaultInspector();
    }
}