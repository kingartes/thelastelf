using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] 
    private Inventory inventory;

    [SerializeField]
    private InventoryResourceItemUI inventoryResourceItemTemplate;

    [SerializeField]
    private InventoryItemUI inventoryItemTemplate;

    [SerializeField]
    private Transform resourceBlock;

    [SerializeField]
    private Transform itemBlock;

    private void Awake()
    {
        inventory.OnResourcesUpdated += Inventory_OnResourcesUpdated;
        inventory.OnItemsUpdated += Inventory_OnItemsUpdated;
    }

    private void Inventory_OnItemsUpdated(object sender, EventArgs e)
    {
        CleanItems();
        foreach (KeyValuePair<GameObject, int> item in inventory.Items)
        {
            RenderItem(item.Key, item.Value);
        }
    }


    private void Inventory_OnResourcesUpdated(object sender, System.EventArgs e)
    {
        CleanResources();
        foreach( KeyValuePair<string, int> item in inventory.ResourceList)
        {
            RenderInventoryResourceItem(item.Key, item.Value);
        }
    }

    private void CleanItems()
    {
        foreach (Transform child in itemBlock)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void CleanResources()
    {
        foreach (Transform child in resourceBlock)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void RenderInventoryResourceItem(string type, int amount)
    {
        InventoryResourceItemUI uiItem = Instantiate(inventoryResourceItemTemplate, resourceBlock);
        uiItem.gameObject.SetActive(true);
        uiItem.SetLabel(type, amount);
    }


    private void RenderItem(GameObject item, int amount)
    {
        InventoryItemUI itemUI = Instantiate(inventoryItemTemplate, itemBlock);
        itemUI.SetItemLabel(item.ToString(), amount);
    }
}
