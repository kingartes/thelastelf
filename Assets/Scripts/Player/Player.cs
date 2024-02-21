using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IHit
{
    [SerializeField]
    private float parryingDuration;
    [SerializeField]
    private float parryingCooldown;

    private float parryingCounter = 0;
    private float parryingCooldownCounter = 0;

    private Health health;

    private bool isParrying;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (InputManager.Instance.IsParryPressed() && !isParrying && parryingCooldownCounter <= 0)
        {
            isParrying = true;
            parryingCooldownCounter = parryingCooldown;
            parryingCounter = parryingDuration;
        }
        if (isParrying)
        {
            parryingCounter = Mathf.Max(parryingCounter - Time.deltaTime, 0);
            if (parryingCounter <= 0)
            {
                isParrying = false;
            }
        }
        
        parryingCooldownCounter = Mathf.Max(parryingCooldownCounter - Time.deltaTime, 0);
        
    }

    public void Hit(float damage)
    {
        Debug.Log("hit");
        if (!isParrying)
        {
            health.TakeDamage(damage);
        } else
        {
            Debug.Log("Parried");
        }

    }
}
