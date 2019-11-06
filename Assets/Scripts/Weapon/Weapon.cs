using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public abstract int WeaponId { get; }
    public abstract string WeaponName { get; }
    public abstract float FireInterval { get; }
    
    public abstract void Shot();
    public abstract void Timer();
}
