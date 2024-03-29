﻿using UnityEngine;
using Object = UnityEngine.Object;

public class Weapon
{
    private WeaponDetail _weaponData;

    private int _ammo;
    private float _timer;
    private bool _canFire;
    private Transform _transform;

    public Weapon(WeaponDetail data, Transform self)
    {
        _transform = self;
        _weaponData = data;
        _timer = _weaponData.fireInterval;
        _canFire = true;
        _ammo = _weaponData.ammo;
    }

    public void WeaponTimerUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer > _weaponData.fireInterval)
        {
            _canFire = true;
        }
    }

    public void Fire()
    {
        if (_ammo > 0)
        {
            if (_canFire)
            {
                var forwardVector = _transform.forward;
                _timer = 0;
                _canFire = false;
                var obj = Object.Instantiate(_weaponData.bulletPrefab, _transform.position + forwardVector,
                        Quaternion.identity);
                obj.GetComponent<Rigidbody>().AddForce(forwardVector * _weaponData.bulletVelocity, ForceMode.Impulse);
                obj.GetComponent<Bullet>().SetDamage(_weaponData.damage);
                _ammo -= 1;
            }
        }
    }

    public int CurrentAmmo => _ammo;
    public int MaxAmmo => _weaponData.ammo;
    public string WeaponName => _weaponData.weaponName;

    public float FireIntervalRatio => Mathf.Clamp(_timer / _weaponData.fireInterval, 0, 1);

    public void ShowWeaponName(){ Debug.Log(_weaponData.weaponName); }
}
