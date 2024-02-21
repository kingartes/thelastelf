using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IHit
{
    private Health health;

    public void Hit(float damage)
    {
        health.TakeDamage(damage);
    }

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnHealthDrop += Health_OnHealthDrop;
    }

    private void Health_OnHealthDrop(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }
}
