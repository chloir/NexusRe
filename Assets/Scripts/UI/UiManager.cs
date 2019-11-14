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
    [SerializeField] private Image reticle;
    [SerializeField] private Image ammoGauge;
    [SerializeField] private Image intervalGauge;

    private Camera _mainCamera;
    
    private int _currentAmmo, _maxAmmo;
    private string _currentWeaponName;
    private Vector2 _ammoGaugeRatio = Vector2.one;
    private Vector2 _intervalGaugeRatio = Vector2.one;

    private Transform _playerTransform;

    private static UiManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<PlayerManager>().GetAimTarget().transform;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        reticle.transform.position = _mainCamera.WorldToScreenPoint(
            _playerTransform.position);
    }

    public void UpdateAmmoDisplay(int current, int max)
    {
        _currentAmmo = current;
        _maxAmmo = max;

        float currentAmmoRatio = (float)current / (float)max;
        _ammoGaugeRatio.x = currentAmmoRatio;
        
        currentWeaponDisplay.text = $"{_currentWeaponName} : {_currentAmmo:0000} / {_maxAmmo:0000}";
        ammoGauge.transform.localScale = _ammoGaugeRatio;
    }

    public void UpdateFireIntervalUi(float scale)
    {
        _intervalGaugeRatio.x = scale;
        intervalGauge.transform.localScale = _intervalGaugeRatio;
    }

    public void SetWeaponName(string weaponName)
    {
        _currentWeaponName = weaponName;
        currentWeaponDisplay.text = $"{_currentWeaponName} : {_currentAmmo:0000} / {_maxAmmo:0000}";
    }

    public void UpdateArmorPoint(int value) => armorPointText.text = $"AP {value:00000}";

    public static UiManager GetInstance() => _instance;
}
