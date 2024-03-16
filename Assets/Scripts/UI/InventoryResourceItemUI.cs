using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryResourceItemUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI resourceLabel;

    public void SetLabel(string type, int amount)
    {
        resourceLabel.text = $"{type}: {amount}";
    }
}
