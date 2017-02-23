using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(NavMeshAgent))]
public class Knight : MonoBehaviour
{

    Enemy enemy;
    NavMeshAgent agent;

    void Start()
    {
        enemy = this.GetComponent<Enemy>();
        agent = this.GetComponent<NavMeshAgent>();
    }

	void Update()
    {
        // do nothing while paused
        if (GameManager.Instance.currentState == GameManager.GameState.PAUSED)
        {
            return;
        }

        switch (enemy.currentState)
        {
            case Enemy.EnemyState.Dead:
            {
                // check for respawn
                break;
            }
            case Enemy.EnemyState.Idle:
            {
                // idle animation
                // look for player
                break;
            }
            case Enemy.EnemyState.Attacking:
            {
                // attack and go back to chase state
                break;
            }
            case Enemy.EnemyState.Chasing:
            {
                // approach player
                break;
            }
            case Enemy.EnemyState.Fleeing:
            {
                break;
            }
            default:
                break;
        }
    }
}
