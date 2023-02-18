using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CodeMonkey.Utils; //!!Imported Package!!//

/// <summary>
/// When configuring a grid, be sure to change the _grid.SetValue..... to _grid<> gridnumber. Otherwise the code will only work for the first grid.
/// Line 19: Configure this line
/// Line 20: Configure this line
/// Line 21: Configure this line
/// Line 37: Configure this line
/// Line 42: Configure this line
/// </summary>

public class Testing : MonoBehaviour
{
    private Grid _grid;
    private Grid _grid1;
    private Grid _grid2;
    
    private void Start()
    {
        _grid = new Grid(4, 2, 10f, new Vector3(20, 0));
        new Grid(2, 5, 5f, new Vector3(0, -20)); //This does not work right now. In the video it does but why?
        new Grid(10, 10, 20f, new Vector3(-100f, -20)); //This does not work right now. In the video it does but why?
        
        
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(_grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
