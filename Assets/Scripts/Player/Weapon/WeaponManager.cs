using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public enum WeaponType { 
    Bow,
    Sword
}

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    public Transform meeleSlot;

    public event EventHandler OnWeaponChanged;

    private WeaponType currentWeapon = WeaponType.Bow;

    private Dictionary<string, MeeleWeapon> meeleWeapons = new Dictionary<string, MeeleWeapon> { };

    [SerializeField]
    private MeeleWeapon equipedMeeleWeapon;

    public MeeleWeapon EquipedMeeleWeapon => equipedMeeleWeapon;

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
    
    public void AddMeeleWeapon(MeeleWeapon weapon)
    {
        var meeleWeapon = Instantiate(weapon, meeleSlot);
        meeleWeapon.gameObject.SetActive(false);
        if (!meeleWeapons.ContainsKey(weapon.ToString()))
        {
            meeleWeapons.Add(weapon.ToString(), meeleWeapon);
        }
    }

    public void EquipMeeleWeapon(string weaponName)
    {

        if (!meeleWeapons.ContainsKey(weaponName))
        {
            Debug.LogError("has no such weapon");
        }
        equipedMeeleWeapon.gameObject.SetActive(false);
        equipedMeeleWeapon = meeleWeapons[weaponName];
        equipedMeeleWeapon.gameObject.SetActive(true);
    } 

}
