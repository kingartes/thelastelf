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

    private void Awake()
    {
        craft.OnStatusChanged += Craft_OnStatusChanged;
        SetVisibility();
    }

    private void SetVisibility()
    {
        this.gameObject.SetActive(craft.IsEnabled);
        if (craft.IsEnabled )
        {
            RenderCraftRecipes();
        }
    }

    private void Craft_OnStatusChanged(object sender, System.EventArgs e)
    {
        SetVisibility();
    }

    private void ClearItems()
    {
        foreach(Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }
    }

    private void RenderCraftRecipes()
    {
        ClearItems();
        foreach(CraftRecipeSO recipeSO in craft.Recipes)
        {
            CraftItemUI item = Instantiate(itemUI, itemsContainer);
            item.SetCraftInfo(recipeSO, craft.IsValidRecipe(recipeSO), craft.CraftRecipe);
        }
    }
}
