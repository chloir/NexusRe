using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    private int _damage;

    public void SetDamage(int value) => _damage = value;

    private void OnTriggerEnter(Collider other)
    {
        var acManager = other.gameObject.GetComponent<AcManager>();
        if (acManager != null)
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            acManager.Damage(_damage);
        }
        Destroy(this.gameObject);
    }
}
