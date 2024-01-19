using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Tilemaps;

public class TractorController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputController inputController;
    [SerializeField] private Tilemap map;
    [SerializeField] private float speed;

    private Vector3 direction = Vector3.right;
    private Vector3 newDirection = Vector3.right;
    const float EpsForEqualing = 1.3015f;

    private void Awake()
    {
        inputController.swipeAction.AddListener(ChangeDirection);
    }

    private void OnEnable()
    {
        direction = Vector3.right;
        newDirection = Vector3.right;
    }
    private void FixedUpdate()
    {
        if (InCenterOfTile() && direction != newDirection) Rotation();
        characterController.Move(direction * speed*Time.fixedDeltaTime);
    }
    private void Rotation() 
    {
        var CrossProduct = Vector3.Cross(direction, newDirection);
        if(CrossProduct == Vector3.zero)
            gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 180, 0));
        else
        if (CrossProduct == Vector3.up)
            gameObject.transform.localRotation *= Quaternion.Euler(new Vector3(0, 90, 0));
        else
            gameObject.transform.localRotation *= Quaternion.Euler(new Vector3(0, -90, 0));

        direction = newDirection;
    }

    private bool InCenterOfTile()
    {
        var cellPosition = map.WorldToCell(gameObject.transform.position);
        var v = map.GetCellCenterWorld(cellPosition);
        //Debug.Log("Position" + gameObject.transform.position);
        //Debug.Log("WorldToCell" + v);
        //Debug.Log((gameObject.transform.position - v).magnitude);
        return (gameObject.transform.position - v).magnitude < EpsForEqualing;
    }

    private void ChangeDirection(Vector2 Direction)
    {
        if (Direction == Vector2.right || Direction == Vector2.left)
            newDirection = Direction;
        else
            if (Direction == Vector2.up)
            newDirection = Vector3.forward;
        else
            newDirection = Vector3.back;
    }

    public void SetMap(Tilemap tilemap)
    {
        map = tilemap;
    }
}
