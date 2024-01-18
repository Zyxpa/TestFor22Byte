using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] double MaxTime;
    [SerializeField] double MinDistance;
    public SwipeAction swipeAction = new SwipeAction();
    
    GameInput inputActions;

    Vector2 startPosition;
    double startTime;

    void Awake()
    {
        inputActions = new GameInput();
    }
    void Start()
    {
        inputActions.Main.PrimaryContact.started += ctx => StarContact(ctx);
        inputActions.Main.PrimaryContact.canceled += ctx => EndContact(ctx);
    }

    private void StarContact(InputAction.CallbackContext ctx)
    {
        startTime = ctx.time;
        startPosition = GetPointOnWorld(Camera.main);
        //Debug.Log(startPosition);
    }

    Vector2[] directions = { Vector2.down, Vector2.up, Vector2.right, Vector2.left };
    private void EndContact(InputAction.CallbackContext ctx)
    {
        Vector2 swipe = GetPointOnWorld(Camera.main) - startPosition;

        if (ctx.time - startTime > MaxTime || swipe.magnitude < MinDistance)
            return;
        
        swipe = swipe.normalized;
        //Debug.Log(directions.MaxBy(x => Vector2.Dot(swipe, x)));
        swipeAction.Invoke(directions.MaxBy(x => Vector2.Dot(swipe, x)));

    }

    private Vector2 GetPointOnWorld(Camera camera)
    {
        var val = (Vector3)inputActions.Main.PrimaryPosition.ReadValue<Vector2>();
        val.z = camera.nearClipPlane;
        return (Vector2)camera.ScreenToWorldPoint(val);
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    public class SwipeAction : UnityEvent<Vector2>
    {
    }
}
