using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyIdle : MonoBehaviour, State
{
    private StateManager _stateManager;
    private GameObject _player;
    private Vector3 _targetPosition;
    private NavMeshAgent _agent;
    private Weapon _weapon;

    public Text ammoDebug;

    public void OnStateEnter()
    {
        _player = GameObject.FindWithTag("Player");
        _stateManager = GetComponent<StateManager>();
        _agent = GetComponent<NavMeshAgent>();

        _weapon = GetComponent<EnemyManager>().GetWeapon();
    }

    public void OnStateUpdate()
    {
        _weapon.WeaponTimerUpdate();
        transform.LookAt(_player.transform);
        
        var playerPosition = _player.transform.position;
        var selfPosition = transform.position;

        var distance = Vector3.Distance(playerPosition, selfPosition);

        if (distance > 3)
        {
            _targetPosition = playerPosition + new Vector3(
                                  Random.Range(-2.5f, 2.5f), 
                                  Random.Range(-2.5f, 2.5f),
                                  Random.Range(-2.5f, 2.5f));
        }

        if (distance < 15)
        {
            _weapon.Fire();
        }

        _agent.SetDestination(_targetPosition);

        ammoDebug.text = $"EnemyAmmo : {_weapon.CurrentAmmo}";
    }

    public void OnStateExit()
    {
        
    }
}
