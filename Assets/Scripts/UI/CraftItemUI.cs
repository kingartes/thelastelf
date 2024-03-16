using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemUI : MonoBehaviour
{
    [SerializeField]
    private Button craftButton;

    TextMeshProUGUI buttonText;

    private void Awake()
    {
        buttonText = craftButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetCraftInfo(CraftRecipeSO recipeSO, bool isAvailable, Craft.CraftRecipeDelegate callback)
    {
        string text = $@"{recipeSO.recipeName}";
        buttonText.text = text;
        craftButton.interactable = isAvailable;
        craftButton.onClick.AddListener(() =>
        {
            callback(recipeSO);
        });
    }

}
