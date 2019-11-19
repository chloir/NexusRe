using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text armorPointText = null;
    [SerializeField] private Text currentWeaponDisplay = null;
    [SerializeField] private Image barriarGauge = null;
    [SerializeField] private Image reticle = null;
    [SerializeField] private Image ammoGauge = null;
    [SerializeField] private Image intervalGauge = null;

    private Camera _mainCamera;
    
    private int _currentAmmo, _maxAmmo;
    private string _currentWeaponName;
    private Vector2 _ammoGaugeRatio = Vector2.one;
    private Vector2 _intervalGaugeRatio = Vector2.one;
    private Vector2 _barrierGaugeRatio = Vector2.one;

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

    public void UpdateBarrierGauge(float scale)
    {
        _barrierGaugeRatio.x = scale;
        barriarGauge.transform.localScale = _barrierGaugeRatio;
    }

    public void SetWeaponName(string weaponName)
    {
        _currentWeaponName = weaponName;
        currentWeaponDisplay.text = $"{_currentWeaponName} : {_currentAmmo:0000} / {_maxAmmo:0000}";
    }

    public void UpdateArmorPoint(int value) => armorPointText.text = $"AP {value:00000}";

    public static UiManager GetInstance() => _instance;
}
