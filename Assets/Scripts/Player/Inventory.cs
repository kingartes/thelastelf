using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnResourcesUpdated;
    public event EventHandler OnItemsUpdated;

    private Dictionary<string, int> resources = new Dictionary<string, int>();

    public Dictionary<string, int> ResourceList => resources;

    private List<GameObject> items = new List<GameObject> { };

    public List<GameObject> Items => items;

    public void AddResource(string resourceType, int amount)
    {
        if (resources.ContainsKey(resourceType))
        {
            resources[resourceType] += amount;
        } else
        {
            resources[resourceType] = amount;
        }
        OnResourcesUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        OnItemsUpdated?.Invoke(this, EventArgs.Empty);
    }

    public bool HasRequiredResources(string resourceType, int amount) {
        return resources.ContainsKey(resourceType) && resources[resourceType] >= amount;
    }

    public void ConsumeResource(string resourceType, int amount)
    {
        if (!resources.ContainsKey(resourceType) || resources[resourceType] < amount)
        {
            throw new Exception("Not enough resource ");
        }
        resources[resourceType] -= amount;
        OnResourcesUpdated?.Invoke(this, EventArgs.Empty);
    }
}
