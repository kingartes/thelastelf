using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event EventHandler OnTakeDamage;
    public event EventHandler OnHealthDrop;

    [SerializeField]
    private float maxHealth = 500;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        OnTakeDamage?.Invoke(this, EventArgs.Empty);
        if ( currentHealth ==0 )
        {
            OnHealthDrop?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetHealthNormalized()
    {
        return currentHealth / maxHealth;
    }
}
