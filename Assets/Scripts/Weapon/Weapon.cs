using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private WeaponDetail _weaponData;
    private float _timer;
    private bool _canFire;
    private Transform _playerTransform;
    
    Weapon(WeaponDetail data)
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _weaponData = data;
        _timer = 0;
        _canFire = true;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _weaponData.fireInterval)
        {
            _canFire = true;
        }
    }

    public void Fire()
    {
        if (_canFire)
        {
            _timer = 0;
            _canFire = false;
            Instantiate(_weaponData.bulletPrefab)
                .GetComponent<Rigidbody>()
                .AddForce(_playerTransform.forward * _weaponData.bulletVelocity, ForceMode.Impulse);
        }
    }
}
