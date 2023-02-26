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

        private set //default dit altijd naar private?
        {
            _inputVector2 = value; //Waarom value gebruiken?
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

        private set //default dit altijd naar private?
        {
            _mousePosition = value; //Waarom value gebruiken?
        }
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        InputVector = new Vector2(horizontal, vertical);

        MousePosition = Input.mousePosition;
    }
}