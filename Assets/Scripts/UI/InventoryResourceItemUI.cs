using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryResourceItemUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI resourceLabel;

    [SerializeField]
    private string resourceType;

    public string GetResourceType()
    {
        return resourceType;
    }

    public void SetLabel(int amount)
    {
        resourceLabel.text = $"{amount}";
    }
}
