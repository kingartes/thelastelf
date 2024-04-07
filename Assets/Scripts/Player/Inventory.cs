using Assets.Scripts.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnResourcesUpdated;
    public event EventHandler OnItemsUpdated;

    [SerializeField]
    private WeaponManager weaponManager;

    [SerializeField]
    private GameObject arrow;

    private GameObject selectedArrowType;

    private Dictionary<string, int> resources = new Dictionary<string, int>();

    public Dictionary<string, int> ResourceList => resources;

    private Dictionary<GameObject, int> items = new Dictionary<GameObject, int> { };

    public Dictionary<GameObject, int> Items => items;

    public int ArrowsCount => Items.Where(obj => obj.Key.name == selectedArrowType.name).Select(obj => obj.Value).FirstOrDefault();

    private void Awake()
    {
        selectedArrowType = arrow;
    }

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
        if (!items.ContainsKey(item))
        {
            if (item.TryGetComponent<MeeleWeapon>(out MeeleWeapon weapon))
            {
                weaponManager.AddMeeleWeapon(weapon);
            }
            items.Add(item, 1);
        } else
        {
            items[item] += 1;
        }
        OnItemsUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void EquipeArrow(GameObject arrowType)
    {
        selectedArrowType = arrowType;
        OnItemsUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void EquipMeeleWeapon(MeeleWeapon weapon)
    {
        weaponManager.EquipMeeleWeapon(weapon.ToString());
    }

    public bool HasRequiredResources(string resourceType, int amount) {
        return resources.ContainsKey(resourceType) && resources[resourceType] >= amount;
    }

    public Arrow GetEquipedArrow()
    {
        return selectedArrowType.GetComponent<Arrow>();
    }

    public void ConsumeArrow()
    {
        if (!items.ContainsKey(selectedArrowType) && items[selectedArrowType] <= 0)
        {
            Debug.LogError("Not enough arrows");
        }
        items[selectedArrowType] -= 1;
        OnItemsUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void ConsumeResource(string resourceType, int amount)
    {
        if (!resources.ContainsKey(resourceType) || resources[resourceType] < amount)
        {
            Debug.LogError("Not enough resource");
        }
        resources[resourceType] -= amount;
        OnResourcesUpdated?.Invoke(this, EventArgs.Empty);
    }
}
