using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Craft : SingletoneComponent<Craft>
{
    public delegate void CraftRecipeDelegate(CraftRecipeSO recipeSO); 
    public delegate bool IsValidCraftRecipeDelegate(CraftRecipeSO recipeSO); 

    public event EventHandler OnStatusChanged;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private List<CraftRecipeSO> recipes;
    public List<CraftRecipeSO> Recipes => recipes;


    public bool IsEnabled { get; private set; } = false;

    protected override void Awake()
    {
        base.Awake();
        inventory.OnResourcesUpdated += Inventory_OnResourcesUpdated;
    }

    private void Inventory_OnResourcesUpdated(object sender, EventArgs e)
    {
        OnStatusChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (InputManager.Instance.IsCraftPressed())
        {
            IsEnabled = !IsEnabled;
            OnStatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsValidRecipe(CraftRecipeSO recipeSO)
    {
        return recipeSO.recipeContent.items.All(item => inventory.HasRequiredResources(item.resourceSO.Type, item.amount));
    }

    public void CraftRecipe(CraftRecipeSO recipeSO)
    {
        recipeSO.recipeContent.items.ForEach(item => inventory.ConsumeResource(item.resourceSO.Type, item.amount));
        inventory.AddItem(recipeSO.recipeContent.craftItem);
    }
}
