using System.Net;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public int primaryWeaponId;
    public int secondaryWeaponId;
    private Weapon _primary;
    private Weapon _secondary;
    private WeaponManager _weaponManager;
    private Weapon _current;

    private UiManager _uiManager;

    private void Start()
    {
        _uiManager = UiManager.GetInstance();
        _weaponManager = WeaponManager.GetInstance();

        _primary = new Weapon(_weaponManager.GetWeaponData(primaryWeaponId));
        _secondary = new Weapon(_weaponManager.GetWeaponData(secondaryWeaponId));
        
        _primary.ShowWeaponName();
        _secondary.ShowWeaponName();
        
        _current = _primary;
        _uiManager.SetWeaponName(_current.WeaponName);
        _uiManager.UpdateAmmoDisplay(_current.CurrentAmmo, _current.MaxAmmo);
    }

    private void Update()
    {
        _current.WeaponTimerUpdate();
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _current.Fire();
            _uiManager.UpdateAmmoDisplay(_current.CurrentAmmo, _current.MaxAmmo);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_current == _primary)
            {
                _current = _secondary;
            }
            else
            {
                _current = _primary;
            }
            
            _uiManager.SetWeaponName(_current.WeaponName);
            _uiManager.UpdateAmmoDisplay(_current.CurrentAmmo, _current.MaxAmmo);
            
            _current.ShowWeaponName();
        }
    }
}