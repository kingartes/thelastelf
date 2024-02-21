using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Health health;

    [SerializeField]
    private Image healthBar;

    private void Awake()
    {
        health.OnTakeDamage += Health_OnTakeDamage;
    }

    private void Health_OnTakeDamage(object sender, System.EventArgs e)
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        healthBar.fillAmount = health.GetHealthNormalized();
    }
}
