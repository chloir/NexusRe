using UnityEngine;
using Object = UnityEngine.Object;

public class Weapon
{
    private WeaponDetail _weaponData;
    private float _timer;
    private bool _canFire;
    private Transform _playerTransform;
    
    public Weapon(WeaponDetail data)
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _weaponData = data;
        _timer = 0;
        _canFire = true;
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
        if (_canFire)
        {
            _timer = 0;
            _canFire = false;
            Object.Instantiate(_weaponData.bulletPrefab, _playerTransform.forward, Quaternion.identity)
                .GetComponent<Rigidbody>()
                .AddForce(_playerTransform.forward * _weaponData.bulletVelocity, ForceMode.Impulse);
        }
    }
    
    public void ShowWeaponName(){ Debug.Log(_weaponData.weaponName); }
}
