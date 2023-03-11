using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))] //Als ik dit niet heb voeg ik het toe anders, go on.
public class Player : MonoBehaviour
{
    private PlayerController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        _controller.EntirePlayerMovement();
    }
}