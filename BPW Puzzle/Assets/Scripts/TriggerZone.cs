using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private PuzzlePrerequisite _puzzlePrerequisite;

    private const string PLAYER_TAG = "Player";
    private const string ENEMY_TAG = "Enemy";
    
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG) || other.gameObject.CompareTag(ENEMY_TAG))
        {
            if (gameObject.tag == "FirstTrigger")
            {
                Debug.Log("FirstTrigger is true");
                _puzzlePrerequisite.prerequisite = true;
            }
        
            if (gameObject.tag == "SecondTrigger")
            {
                Debug.Log("SecondTrigger is true");
                _puzzlePrerequisite.prerequisite1 = true;
            }
        
            if (gameObject.tag == "ThirdTrigger")
            {
                Debug.Log("ThirdTrigger is true");
                _puzzlePrerequisite.prerequisite2 = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG) || other.gameObject.CompareTag(ENEMY_TAG))
        {
            if (gameObject.tag == "FirstTrigger")
            {
                Debug.Log("FirstTrigger is false");
                _puzzlePrerequisite.prerequisite = false;
            }
        
            if (gameObject.tag == "SecondTrigger")
            {
                Debug.Log("SecondTrigger is false");
                _puzzlePrerequisite.prerequisite1 = false;
            }
        
            if (gameObject.tag == "ThirdTrigger")
            {
                Debug.Log("ThirdTrigger is false");
                _puzzlePrerequisite.prerequisite2 = false;
            }
        }
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>() || other.GetComponent<PlayerController>() == null)
        {
            return;
        }

        _puzzlePrerequisite.prerequisite = true;
        //Check if a player or enemy hit is inside the triggerzone
        //Set a public bool (prequisite for opening puzzledoor) on true 
    }*/

    /*private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyBehaviour>() || other.GetComponent<PlayerController>() == null)
        {
            return;
        }

        _puzzlePrerequisite.prerequisite = false;
        //Set a public bool (prequisite for opening puzzledoor) on false 
    }*/
}


