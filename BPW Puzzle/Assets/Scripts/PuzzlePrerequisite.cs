using System;
using UnityEngine;

public class PuzzlePrerequisite : MonoBehaviour
{
    public bool prerequisite, prerequisite1, prerequisite2;
    
    

    public bool PrerequisiteCheck()
    {
        return prerequisite && prerequisite1;
    }
    
    
}