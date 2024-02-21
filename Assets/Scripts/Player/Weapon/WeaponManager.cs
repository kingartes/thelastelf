using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { 
    Bow,
    Sword
}

public class WeaponManager : MonoBehaviour
{
    public event EventHandler OnWeaponChanged;

    private WeaponType currentWeapon = WeaponType.Bow;

    public WeaponType EquipedWeapon => currentWeapon;

    public void EquipBow()
    {
        currentWeapon = WeaponType.Bow;
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
    }

    public void EquipSword()
    {
        currentWeapon = WeaponType.Sword;
        OnWeaponChanged?.Invoke(this, EventArgs.Empty);
    }

}
