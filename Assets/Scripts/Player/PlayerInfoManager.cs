using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    private UiManager _uiManager;
    private AcManager _acManager;

    private int _maxArmorPoint;
    private int _prevArmorPoint;
    
    void Start()
    {
        _uiManager = UiManager.GetInstance();
        _acManager = GetComponent<AcManager>();

        _maxArmorPoint = _acManager.GetArmorPoint();
    }

    void Update()
    {
        var ap = _acManager.GetArmorPoint();
        if (_prevArmorPoint != ap)
        {
            _uiManager.UpdateArmorPoint(ap);
            _uiManager.UpdateBarrierGauge(Mathf.Clamp((float)ap/(float)_maxArmorPoint, 0, 1));
        }

        _prevArmorPoint = ap;
    }
}
