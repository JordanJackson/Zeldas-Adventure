using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public enum EnemyState
    {
        Idle,
        Dead,
        Chasing,
        Attacking,
        Fleeing
    }

    public EnemyState currentState;
}
