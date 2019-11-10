using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcManager : MonoBehaviour
{
    [SerializeField] private int testArmorPoint;
    private int _armorPoint;

    private void Start()
    {
        _armorPoint = testArmorPoint;
    }

    private void Update()
    {
        if (_armorPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int GetArmorPoint() => _armorPoint;
    
    public void Damage(int value)
    {
        _armorPoint -= value;
        Debug.Log("Hit");
    }
}
