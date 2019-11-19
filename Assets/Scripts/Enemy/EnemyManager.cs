using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int enemyWeaponId = 0;
    private WeaponManager _weaponManager;
    private StateManager _stateManager;
    private EnemyIdle _enemyIdle;
    private Weapon _enemyWeapon;

    private void Awake()
    {
        _stateManager = GetComponent<StateManager>();
        _enemyIdle = GetComponent<EnemyIdle>();
        
        _stateManager.SetInitialState(_enemyIdle);
    }

    private void Start()
    {
        _weaponManager = WeaponManager.GetInstance();
        _enemyWeapon = new Weapon(_weaponManager.GetWeaponData(enemyWeaponId), transform);
    }

    public Weapon GetWeapon() => _enemyWeapon;
}
