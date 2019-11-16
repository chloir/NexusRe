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

    private void Start()
    {
        _master = PartsDataMaster.GetInstance();
    }

    public void InitializeButton(int id, PartsListManager manager)
    {
        _listManager = manager;
        partsName.text = _master.GetPartsData(id).PartsName;
    }
}
