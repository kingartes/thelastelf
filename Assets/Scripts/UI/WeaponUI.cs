using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]
    private WeaponItemUI weaponItemTemplate;

    [SerializeField]
    private WeaponManager weaponManager;

    private Dictionary<WeaponType, WeaponItemUI> icons;

    private void Start()
    {
        weaponManager.OnWeaponChanged += WeaponManager_OnWeaponChanged;
        InitializeIcons();
    }

    private void WeaponManager_OnWeaponChanged(object sender, System.EventArgs e)
    {
        ChangeWeaponIcon();
    }

    private void InitializeIcons()
    {
        icons = new Dictionary<WeaponType, WeaponItemUI>();
        foreach (WeaponType weaponType in Enum.GetValues(typeof(WeaponType)))
        {
            WeaponItemUI item = Instantiate(weaponItemTemplate, transform);
            item.SetLabel(((int)weaponType + 1).ToString());
            icons.Add(weaponType, item);
        }
        ChangeWeaponIcon();
    }

    private void ChangeWeaponIcon()
    {
        foreach(KeyValuePair<WeaponType, WeaponItemUI> icon in icons)
        {
            if (weaponManager.EquipedWeapon == icon.Key)
                icon.Value.SetActive();
            else icon.Value.SetInactive();
        }
    }
}
