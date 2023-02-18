using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils; //Imported Package

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;

    private int[,] _gridArray; //[,] means 2-Dimensional; [,,] means 3-Dimensional;
    
    public Grid(int width, int height, float cellSize)
    {
        this._width = width;
        this._height = height;
        this._cellSize = cellSize;

        _gridArray = new int[_width, _height];
        
        //This is how you cycle through a multidimensional array (2D variant)
        for (int x = 0; x < _gridArray.GetLength(0); x++) //Cycle through the first dimension.
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++) //Cycle through the second dimension.
            {
                UtilsClass.CreateWorldText(_gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(_cellSize, _cellSize) * 0.5f, 20, Color.black, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 100f); //Drawn from bottom left point of gridcell . Visualize leftside vertical line |  
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.green, 100f); //Drawn from bottom left point of gridcell . Visualize leftside horizontal line _ 
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.yellow, 100f); //Drawn from upper left point of last gridcell row -. Visualize horizontal line on top part of gridcell _  
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.blue, 100f); //Drawn from bottom right point of last gridcell column |. Visualize vertical line on top part of gridcell |
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize;
    }
}

