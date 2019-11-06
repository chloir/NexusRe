using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
  public List<WeaponDetail> WeaponDetailList = new List<WeaponDetail>();
}

[System.Serializable]
public class WeaponDetail
{
  public int weaponId;
  public string weaponName;
  public float fireInterval;
  public float bulletVelocity;
  public GameObject bulletPrefab;
  public int damage;
  public int ammo;
}
