using Assets.Scripts.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] 
    private Inventory inventory;

    [SerializeField]
    private InventoryResourceItemUI[] resourceItems;
/*
    [SerializeField]
    private InventoryItemUI inventoryItemTemplate;*/

    [SerializeField]
    private Transform resourceBlock;

/*    [SerializeField]
    private Transform itemBlock;*/

    private void Awake()
    {
        inventory.OnResourcesUpdated += Inventory_OnResourcesUpdated;
        //inventory.OnItemsUpdated += Inventory_OnItemsUpdated;
    }

    private void Inventory_OnItemsUpdated(object sender, EventArgs e)
    {
        foreach (KeyValuePair<GameObject, int> item in inventory.Items)
        {
            RenderItem(item.Key, item.Value);
        }
    }


    private void Inventory_OnResourcesUpdated(object sender, System.EventArgs e)
    {
        foreach(InventoryResourceItemUI uiItem in resourceItems)
        {
            if(inventory.ResourceList.ContainsKey(uiItem.GetResourceType()))
            {
                RenderInventoryResourceItem(uiItem, inventory.ResourceList[uiItem.GetResourceType()]);
            }
        }
    }

    private void RenderInventoryResourceItem(InventoryResourceItemUI uiItem, int amount)
    {
        uiItem.gameObject.SetActive(true);
        uiItem.SetLabel(amount);
    }


    private void RenderItem(GameObject item, int amount)
    {
        /*InventoryItemUI itemUI = Instantiate(inventoryItemTemplate, itemBlock);
        itemUI.SetItemLabel(item.ToString(), amount);
        if (item.TryGetComponent<MeeleWeapon>(out MeeleWeapon weapon))
        {
            Action equipMeeleeCallback = () =>
            {
                inventory.EquipMeeleWeapon(weapon);
            };
            itemUI.SetEquipButton(equipMeeleeCallback);
        }
        if (item.TryGetComponent<Arrow>(out Arrow arrow))
        {
            Action equipArrowCallback = () => {
                inventory.EquipeArrow(item);
            };
            itemUI.SetEquipButton(equipArrowCallback);
        }*/
    }
}
