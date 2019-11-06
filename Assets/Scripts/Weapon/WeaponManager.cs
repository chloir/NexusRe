using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum WeaponCategory
    {
        Machinegun,
        Shotgun,
        Lasergun,
        None
    }

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
}
