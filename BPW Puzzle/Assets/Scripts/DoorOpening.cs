using System;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private PuzzlePrerequisite _puzzlePrerequisite;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        if (_puzzlePrerequisite.PrerequisiteCheck())
        {
            _door.transform.position = new Vector3(transform.localPosition.x, -0.5f, transform.localPosition.z);
        }
    }
}