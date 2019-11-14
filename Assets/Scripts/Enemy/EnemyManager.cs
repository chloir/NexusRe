using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int enemyWeaponId;
    [SerializeField] private GameObject destroyEffect;
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

    private void OnDestroy()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }

    public Weapon GetWeapon() => _enemyWeapon;
}
