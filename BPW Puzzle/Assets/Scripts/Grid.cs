using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int _width;
    private int _height;

    private int[,] _gridArray; //[,] means 2-Dimensional; [,,] means 3-Dimensional;
    
    public Grid(int width, int height)
    {
        this._width = width;
        this._height = _height;

        _gridArray = new int[_width, _height];
    }
}
