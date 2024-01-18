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
    const float EpsForEqualing = 1.3503f;

    private void Awake()
    {
        inputController.swipeAction.AddListener(ChangeDirection);
    }

    private void OnEnable()
    {
        direction = Vector3.right;
    }
    private void FixedUpdate()
    {
        if (InCenterOfTile() && direction != newDirection) Rotation();
        characterController.Move(direction * speed*Time.fixedDeltaTime);
    }

    //ToDo
    private void Rotation() 
    { 

        if (direction + newDirection == Vector3.zero)
            gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 180, 0));

        if (direction == Vector3.right)
            if(newDirection == Vector3.forward)
                gameObject.transform.localRotation *= Quaternion.Euler(new Vector3(0, -90, 0));
            else
                gameObject.transform.localRotation *= Quaternion.Euler(new Vector3(0, 90, 0));

        if(direction == Vector3.forward)
            if (newDirection == Vector3.left)
            gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, -90, 0));
            else
            gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));

        if (direction == Vector3.left)
            if (newDirection == Vector3.back)
                gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, -90, 0));
            else
                gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));

        if (direction == Vector3.back)
            if (newDirection == Vector3.right)
                gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, -90, 0));
            else
                gameObject.transform.rotation *= Quaternion.Euler(new Vector3(0, 90, 0));
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
