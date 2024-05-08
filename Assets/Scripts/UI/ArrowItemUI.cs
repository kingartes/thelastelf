using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowItemUI : MonoBehaviour
{

    [SerializeField]
    private Color activeColor;

    [SerializeField]
    private Color disabledColor;

    [SerializeField]
    private GameObject arrowType;

    [SerializeField]
    private Image arrowImage;

    [SerializeField]
    private TextMeshProUGUI arrowsCount;

    [SerializeField]
    private Inventory inventory;



    private void Awake()
    {
        inventory.OnItemsUpdated += Inventory_OnItemsUpdated;
    }

    private void Inventory_OnItemsUpdated(object sender, System.EventArgs e)
    {
        arrowImage.color = inventory.SelectedArrowType.name == arrowType.name ? activeColor : disabledColor;
        arrowsCount.text = inventory.ArrowsCount(arrowType).ToString();
    }
}
