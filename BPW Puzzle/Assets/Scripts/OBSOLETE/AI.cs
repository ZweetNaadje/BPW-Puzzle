using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    public bool MayMove = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (MayMove)
        {
            transform.LookAt(Player);
            Enemy.GetComponent<NavMeshAgent>().isStopped = false;
            Enemy.SetDestination(Player.position);
        }
        else
        {
            Enemy.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}