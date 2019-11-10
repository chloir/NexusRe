using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcManager : MonoBehaviour
{
    private UiManager _uiManager;
    private int _armorPoint = 25000;

    private int _prevArmorPoint;
    
    void Start()
    {
        _uiManager = UiManager.GetInstance();
        _prevArmorPoint = _armorPoint;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _armorPoint -= 200;
        }
        
        if (_armorPoint != _prevArmorPoint)
        {
            _uiManager.UpdateArmorPoint(_armorPoint);
        }

        _prevArmorPoint = _armorPoint;
    }
}
