using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemLabel;

    [SerializeField]
    private Button equipButton;

    public void SetItemLabel(string name, int amount)
    {
        itemLabel.text = $@"{name}({amount})";
        equipButton.gameObject.SetActive(false);
    }

    public void SetEquipButton(Action equipWeaponCallback)
    {
        equipButton.gameObject.SetActive(true);
        equipButton.onClick.AddListener(() => equipWeaponCallback());
    }

}
