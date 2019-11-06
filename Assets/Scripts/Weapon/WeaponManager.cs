using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData weaponMaster;
    private static WeaponManager _instance;

    private void Awake()
    {
        if (WeaponManager.GetInstance() != null)
        {
            Destroy(this);
        }
        _instance = this;
    }

    public static WeaponManager GetInstance() => _instance;

    public WeaponDetail GetWeaponData(int id) => weaponMaster.WeaponDetailList[id];
}
