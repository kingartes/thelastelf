using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    public float attackSpeed;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float shootDamage;

    [SerializeField]
    private MeeleWeapon meeleWeapon;

    [SerializeField]
    private WeaponManager weaponManager;

    private EssenceSystem ES;

    private float attackCounter = 0;

    private Dictionary<WeaponType, Action> attackHandlers;

    private void Start()
    {
        attackHandlers = new Dictionary<WeaponType, Action>();
        attackHandlers[WeaponType.Sword] = HandleMeele;
        attackHandlers[WeaponType.Bow] = HandleRanged;
        ES = GetComponent<EssenceSystem>();
    }

    private void Update()
    {
        if (InputManager.Instance.IsEquipRangePressed())
        {
            weaponManager.EquipBow();
        }
        if (InputManager.Instance.IsEquipedMeelePressed())
        {
            weaponManager.EquipSword();
        }
        if (InputManager.Instance.IsPrimaryActionButtonPressed())
        {
            attackHandlers[weaponManager.EquipedWeapon].Invoke();
        }
        attackCounter = Mathf.Clamp(attackCounter - Time.deltaTime, 0, float.MaxValue);
    }

    private void HandleMeele()
    {
        meeleWeapon.gameObject.SetActive(true);
        meeleWeapon.Attack(null);

    }

    private void HandleRanged()
    {
        if (attackCounter == 0)
        {
            Projectile projectile = Instantiate(projectilePrefab, shootPoint);
            projectile.transform.parent = null;
            Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
            projectile.Damage = shootDamage;
            Vector3 mouseWorldPosition = MouseWorld.GetPosition();
            mouseWorldPosition.y = shootPoint.position.y;
            Vector3 shootDirection = mouseWorldPosition - shootPoint.position;
            projectileRigidBody.useGravity = false;
            projectileRigidBody.velocity = shootDirection * projectileSpeed;
            Debug.Log("Shooting");
            Destroy(projectile.gameObject, 3f);
            attackCounter = 1 / attackSpeed;
            ES.EssenceChange(-5);
        }


    }
}
