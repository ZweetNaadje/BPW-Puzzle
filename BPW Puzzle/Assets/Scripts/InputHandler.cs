using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //public Vector2 InputVector { get; private set; } //Auto property
    private Vector2 _inputVector2;

    public Vector2 InputVector
    {
        get
        {
            return _inputVector2;
        }

        private set //Getters and setters default to Public
        {
            _inputVector2 = value; //Value is a reserved keyword
        }
    }
    
    //public Vector2 MousePosition { get; private set; } //Auto property
    private Vector2 _mousePosition;
    
    public Vector2 MousePosition
    {
        get
        {
            return _mousePosition;
        }

        private set //Getters and setters default to Public
        {
            _mousePosition = value; //Value is a reserved keyword
        }
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        InputVector = new Vector2(horizontal, vertical).normalized;

        MousePosition = Input.mousePosition;
    }
}