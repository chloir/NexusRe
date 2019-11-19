using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsButtonController : MonoBehaviour
{
    [SerializeField] private Text partsName;
    private PartsDataMaster _master;
    private PartsListManager _listManager;
    private int _selfId;
    
    public void InitializeButton(int id, PartsListManager manager)
    {
        _master = PartsDataMaster.GetInstance();
        _listManager = manager;
        _selfId = id;
        partsName.text = _master.GetPartsData(id).PartsName;
    }

    public void OnClick() => _listManager.PartsButtonOnClick(_selfId);
}
