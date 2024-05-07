using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemUI : MonoBehaviour
{
    [SerializeField]
    private Button craftButton;

    [SerializeField]
    private CraftRecipeSO recipeSO;

    private Craft.IsValidCraftRecipeDelegate isValidCraft;

    TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonText = craftButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetupCraftButton(Craft.IsValidCraftRecipeDelegate isValidCraft, Craft.CraftRecipeDelegate callback)
    {
        this.isValidCraft = isValidCraft;
        craftButton.onClick.AddListener(() =>
        {
            callback(recipeSO);
        });
    }


    public void UpdateCraftButton()
    {
        craftButton.interactable = isValidCraft(recipeSO);
    }
}
