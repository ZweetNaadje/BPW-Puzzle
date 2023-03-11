using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerFOV : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _enemy;
    //[SerializeField] private Transform _enemy1;
    [SerializeField] private AI _ai;

    //[SerializeField] private List<AI> _aiFOO;

    [SerializeField] private List<AI> _enemies;

    private Vector3 _dir;
    private float _distance;


    // Start is called before the first frame update
    void Start()
    {
        _enemies = FindObjectsOfType<AI>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //StopMovementFirstEnemy();
        //StopMovementSecondEnemy();

        //StopMovementFOO(_enemy);
        StopAgentMovement(_enemies);
        //Debug.Log(_distance);
    }

    private void StopMovementFirstEnemy()
    {
        _dir = _player.position - _enemy.position;
        float playerToEnemyAngle = Vector3.Angle(_player.forward, _dir);

        _distance = Vector3.Distance(_player.position, _enemy.position);


        if (playerToEnemyAngle >= 140f && playerToEnemyAngle <= 190f && _distance <= 12f)
        {
            _ai.MayMove = false;
        }
        else
        {
            _ai.MayMove = true;
        }

        Debug.DrawLine(_player.position, _enemy.position, Color.blue);
        Debug.DrawLine(_enemy.position, _player.position, Color.red);
        Debug.DrawRay(_enemy.position, _enemy.forward * 10f, Color.magenta);
    }

    /*private void StopMovementSecondEnemy()
    {
        _dir = _player.position - _enemy1.position;
        float playerToEnemyAngle = Vector3.Angle(_player.forward, _dir);

        _distance = Vector3.Distance(_player.position, _enemy1.position);


        if (playerToEnemyAngle >= 140f && playerToEnemyAngle <= 190f && _distance <= 12f)
        {
            _ai.MayMove = false;
        }
        else
        {
            _ai.MayMove = true;
        }

        Debug.DrawLine(_player.position, _enemy1.position, Color.blue);
        Debug.DrawLine(_enemy1.position, _player.position, Color.red);
        Debug.DrawRay(_enemy1.position, _enemy1.forward * 10f, Color.magenta);
    }*/

    private void StopMovementFOO(Transform enemy)
    {
        _enemy = enemy;

        _dir = _player.position - _enemy.position;
        float playerToEnemyAngle = Vector3.Angle(_player.forward, _dir);

        _distance = Vector3.Distance(_player.position, _enemy.position);


        if (playerToEnemyAngle >= 140f && playerToEnemyAngle <= 190f && _distance <= 12f)
        {
            _ai.MayMove = false;
        }
        else
        {
            _ai.MayMove = true;
        }

        Debug.DrawLine(_player.position, _enemy.position, Color.blue);
        Debug.DrawLine(_enemy.position, _player.position, Color.red);
        Debug.DrawRay(_enemy.position, _enemy.forward * 10f, Color.magenta);
    }

    private void StopAgentMovement(List<AI> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            _dir =  enemies[i].transform.position - _player.position;
            float enemyToPlayerAngle = Vector3.Angle(_player.forward, _dir);

            _distance = Vector3.Distance(_player.position, enemies[i].transform.position);

            if (enemyToPlayerAngle >= 140f && enemyToPlayerAngle <= 190f && _distance <= 12f)
            {
                _ai.MayMove = false;
            }
            else
            {
                _ai.MayMove = true;
            }
            
            Debug.DrawLine(_player.position, enemies[i].transform.position, Color.blue);
            Debug.DrawLine(enemies[i].transform.position, _player.position, Color.red);
            Debug.DrawRay(enemies[i].transform.position, enemies[i].transform.forward * 10f, Color.magenta);
        }


        //Debug.Log(Vector3.Angle(_player.forward, enemy.forward));
    }
}