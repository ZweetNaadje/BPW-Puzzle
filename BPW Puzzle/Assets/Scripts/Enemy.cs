using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    public float DetectRange = 10f;

    private Animator _animator;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = FindObjectOfType<Player>().transform;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if (MayMove())
        {
            _animator.speed = 2;
            transform.LookAt(Player);
            Agent.GetComponent<NavMeshAgent>().isStopped = false;
            Agent.SetDestination(Player.position);
        }
        else
        {
            _animator.speed = 0;
            Agent.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    private bool MayMove()
    {
        Vector3 directionFromEnemyToPlayer = gameObject.transform.position - Player.position;
        float distanceBetwEnemyAndPlayer = Vector3.Distance(Player.position, gameObject.transform.position);
        float angleBetwPlayerAndEnemy = Vector3.Angle(Player.transform.forward, directionFromEnemyToPlayer);

        Debug.Log(angleBetwPlayerAndEnemy);

        if (distanceBetwEnemyAndPlayer <= DetectRange && angleBetwPlayerAndEnemy < 45f)
        {
            return false;
        }

        return true;
    }
}