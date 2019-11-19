using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData weaponMaster;
    private static WeaponManager _instance;
    private Dictionary<int, WeaponDetail> _weaponMaster = new Dictionary<int, WeaponDetail>();

    private void Awake()
    {
        _instance = this;
        foreach (var data in weaponMaster.WeaponDetailList)
        {
            _weaponMaster.Add(data.weaponId, data);
        }
    }

    public static WeaponManager GetInstance() => _instance;

    public WeaponDetail GetWeaponData(int id) => weaponMaster.WeaponDetailList[id];

    public Dictionary<int, WeaponDetail> GetWeaponMaster() => _weaponMaster;
}
