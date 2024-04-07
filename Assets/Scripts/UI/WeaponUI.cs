using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField]
    private WeaponItemUI weaponItemTemplate;

    [SerializeField]
    private WeaponManager weaponManager;

    [SerializeField] 
    private Inventory inventory;

    [SerializeField]
    private Transform weaponBlock;

    [SerializeField]
    private TextMeshProUGUI arrowsCountLabel;

    private Dictionary<WeaponType, WeaponItemUI> icons;

    private void Start()
    {
        weaponManager.OnWeaponChanged += WeaponManager_OnWeaponChanged;
        inventory.OnItemsUpdated += Inventory_OnItemsUpdated;
        InitializeIcons();
    }

    private void Inventory_OnItemsUpdated(object sender, EventArgs e)
    {
        SetArrowsLabel();
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
            WeaponItemUI item = Instantiate(weaponItemTemplate, weaponBlock);
            item.SetLabel(((int)weaponType + 1).ToString());
            icons.Add(weaponType, item);
        }
        ChangeWeaponIcon();
    }

    private void ChangeWeaponIcon()
    {
        arrowsCountLabel.gameObject.SetActive(false);
        if (weaponManager.EquipedWeapon == WeaponType.Bow)
        {
            arrowsCountLabel.gameObject.SetActive(true);
            SetArrowsLabel();
        }
        foreach (KeyValuePair<WeaponType, WeaponItemUI> icon in icons)
        {
            if (weaponManager.EquipedWeapon == icon.Key)
                icon.Value.SetActive();
            else icon.Value.SetInactive();
        }
    }

    private void SetArrowsLabel()
    {
        arrowsCountLabel.text = inventory.ArrowsCount.ToString();
    }
}
