using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyIdle : MonoBehaviour, State
{
    private StateManager _stateManager;
    private GameObject _player;
    private Vector3 _targetPosition;
    private NavMeshAgent _agent;
    
    public void OnStateEnter()
    {
        _player = GameObject.FindWithTag("Player");
        _stateManager = GetComponent<StateManager>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var playerPosition = _player.transform.position;
        var selfPosition = transform.position;

        var direction = playerPosition - selfPosition;

        if (Vector3.Distance(playerPosition, selfPosition) > 3)
        {
            _targetPosition = playerPosition + new Vector3(
                                  Random.Range(-2.5f, 2.5f), 
                                  Random.Range(-2.5f, 2.5f),
                                  Random.Range(-2.5f, 2.5f));
        }

        _agent.SetDestination(_targetPosition);
    }

    public void OnStateExit()
    {
        
    }
}
