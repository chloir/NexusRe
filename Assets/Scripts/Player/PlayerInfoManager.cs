using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    private UiManager _uiManager;
    private AcManager _acManager;

    private int _prevArmorPoint;
    
    void Start()
    {
        _uiManager = UiManager.GetInstance();
        _acManager = GetComponent<AcManager>();
    }

    void Update()
    {
        var ap = _acManager.GetArmorPoint();
        if (_prevArmorPoint != ap)
            _uiManager.UpdateArmorPoint(ap);

        _prevArmorPoint = ap;
    }
}
