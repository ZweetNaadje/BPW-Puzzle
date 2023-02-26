using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils; //!!Imported Package!!//

/// <summary>
/// The video is working on the principles of a 2D game. Since this game is going to be in 3D you need to be wary of a couple of things.
/// 1: To have the gridsystem work right now, you need to set the "Main Camera Projection" in "Orthographic" mode.
/// 2: I assume you're going to make this game in 3D-Top Down which means you're going to need to get the mouse position in 3D space. https://www.youtube.com/watch?v=0jTPKz3ga4w
/// 3:
/// </summary>

public class Grid
{
    private int _width;
    private int _height;
    private float _cellSize;

    private int[,] _gridArray; //[,] means 2-Dimensional; [,,] means 3-Dimensional;
    private TextMesh[,] _debugTextArray; //Array used for debugging.

    private Vector3 _originPosition;
    
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this._width = width; //Redundant?
        this._height = height; //Redundant?
        this._cellSize = cellSize; //Redundant?
        this._originPosition = originPosition; //Redundant?

        _gridArray = new int[_width, _height];
        _debugTextArray = new TextMesh[_width, _height];
        
        //This is how you cycle through a multidimensional array (2D variant). Gridcells are drawn from bottom left corner. 0, 0 is starting point.
        for (int x = 0; x < _gridArray.GetLength(0); x++) //Cycle through the first dimension.
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++) //Cycle through the second dimension.
            {
                _debugTextArray[x, y] = UtilsClass.CreateWorldText(_gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(_cellSize, _cellSize) * 0.5f, 20, Color.black, TextAnchor.MiddleCenter); // !!Imported package Function!! //
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.red, 100f); //Drawn from bottom left point of gridcell . Visualize leftside vertical line |  
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.green, 100f); //Drawn from bottom left point of gridcell . Visualize leftside horizontal line _ 
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.yellow, 100f); //Drawn from upper left point of last gridcell row -. Visualize horizontal line on top part of gridcell _  
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.blue, 100f); //Drawn from bottom right point of last gridcell column |. Visualize vertical line on top part of gridcell |
        
        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int y) //Convert grid position into world position.
    {
        return new Vector3(x, y) * _cellSize + _originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) //Convert world position into a grid position. With using "out" we can now return multiple values from a single function
    {
        x = Mathf.FloorToInt((worldPosition - _originPosition).x / _cellSize);
        y = Mathf.FloorToInt((worldPosition - _originPosition).y / _cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            _gridArray[x, y] = value;
            _debugTextArray[x, y].text = _gridArray[x, y].ToString(); //Set text mesh text to be on the newly set value.
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < _width && y < _height)
        {
            return _gridArray[x, y];
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}

