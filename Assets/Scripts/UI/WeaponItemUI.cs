using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponItemUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    public void SetActive()
    {
        textMeshProUGUI.color = Color.green;
    }

    public void SetInactive()
    {
        textMeshProUGUI.color = Color.red;
    }

    public void SetLabel(string label)
    {
        gameObject.SetActive(true);
        textMeshProUGUI.text = label;
    }
}
