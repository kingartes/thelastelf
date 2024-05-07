using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenuUI : MonoBehaviour
{
    [SerializeField]
    private Craft craft;

    [SerializeField]
    private CraftItemUI itemUI;

    [SerializeField]
    private Transform itemsContainer;

    [SerializeField]
    private CraftItemUI[] craftButtons;

    private void Awake()
    {
        craft.OnStatusChanged += Craft_OnStatusChanged;
        SetVisibility();
        InitCraftRecipes();
    }

    private void SetVisibility()
    {
        this.gameObject.SetActive(craft.IsEnabled);
        if (craft.IsEnabled )
        {
            UpdateCraftRecipes();
        }
    }

    private void Craft_OnStatusChanged(object sender, System.EventArgs e)
    {
        SetVisibility();
    }

    private void InitCraftRecipes()
    {
        foreach(CraftItemUI item in craftButtons)
        {
            item.SetupCraftButton(craft.IsValidRecipe, craft.CraftRecipe);
        }
    }

    private void UpdateCraftRecipes()
    {
        foreach (CraftItemUI item in craftButtons)
        {
            item.UpdateCraftButton();
        }
    }
}
