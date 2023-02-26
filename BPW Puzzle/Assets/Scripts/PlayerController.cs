using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private bool _rotateTowardsMouse;
    
    
    private InputHandler _inputHandler;

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>(); //SerializeField is now not necessary.
    }

    private void Start()
    {
    }

    private void Update()
    {
        Vector3 targetVector = new Vector3(_inputHandler.InputVector.x, 0, _inputHandler.InputVector.y); //Converting Vector2 to Vector3

        Vector3 movementVector = MoveTowardTarget(targetVector);
        
        //Move in direction we are aiming
        MoveTowardTarget(targetVector);

        if (!_rotateTowardsMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        else
        {
            RotateTowardMouseVector();
        }
    }

    private void RotateTowardMouseVector()
    {
       Ray ray = _camera.ScreenPointToRay(_inputHandler.MousePosition);
       RaycastHit raycastHit; 
       
       if (Physics.Raycast(ray, out raycastHit, maxDistance: 300f))
       {
           Vector3 target = raycastHit.point;
           target.y = transform.position.y;
           transform.LookAt(target);
       }

    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0)
        {
            return;
        }
        
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float speed = _moveSpeed * Time.deltaTime;
        float cameraOffset = _camera.transform.rotation.eulerAngles.y;
        
        targetVector = Quaternion.Euler(0, cameraOffset, 0) * targetVector;
        Vector3 targetPosition = transform.position + targetVector * speed;
        
        targetVector = Vector3.Normalize(targetVector);
        transform.position = targetPosition;
        
        return targetVector;
    }
}