using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemLabel;

    public void SetItemLabel(string name)
    {
        itemLabel.text = name;
    }
}
