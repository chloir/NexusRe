using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text armorPointText;
    [SerializeField] private Text currentWeaponDisplay;
    [SerializeField] private Image barriarGauge;
    
    private int _currentAmmo, _maxAmmo;
    private string _currentWeaponName;

    private static UiManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateAmmoDisplay(int current, int max)
    {
        _currentAmmo = current;
        _maxAmmo = max;
        currentWeaponDisplay.text = $"{_currentWeaponName} : {_currentAmmo:0000} / {_maxAmmo:0000}";
    }

    public void SetWeaponName(string weaponName)
    {
        _currentWeaponName = weaponName;
        currentWeaponDisplay.text = $"{_currentWeaponName} : {_currentAmmo:0000} / {_maxAmmo:0000}";
    }

    public void UpdateArmorPoint(int value) => armorPointText.text = $"AP {value:00000}";

    public static UiManager GetInstance() => _instance;
}
