using UnityEditor;

[CustomEditor(typeof(BasketButton))]
public class BasketButtonEditor: Editor
{
    public override void OnInspectorGUI()
    {
        BasketButton targetMenuButton = (BasketButton)target;
        DrawDefaultInspector();
    }
}