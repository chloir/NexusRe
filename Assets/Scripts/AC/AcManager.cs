using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcManager : MonoBehaviour
{
    [SerializeField] private int testArmorPoint = 0;
    [SerializeField] private GameObject destroyEffect = null;
    private int _armorPoint;

    private void Awake()
    {
        _armorPoint = testArmorPoint;
    }

    private void Update()
    {
        if (_armorPoint <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void SetArmorPoint(int value) => _armorPoint = value;

    public int GetArmorPoint() => _armorPoint;
    
    public void Damage(int value)
    {
        _armorPoint -= value;
        Debug.Log("Hit");
    }
}
