using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private StateManager _stateManager;
    private EnemyIdle _enemyIdle;

    private void Awake()
    {
        _stateManager = GetComponent<StateManager>();
        _enemyIdle = GetComponent<EnemyIdle>();
        
        _stateManager.SetInitialState(_enemyIdle);
    }
}
