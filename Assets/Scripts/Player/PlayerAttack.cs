using Assets.Scripts.Weapon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(Chargeble))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float shootDamage;

    private WeaponManager weaponManager;

    private Inventory inventory;
    private Chargeble chargeble;

    private float attackCounter = 0;

    private Dictionary<WeaponType, Action> attackHandlers;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        inventory = GetComponent<Inventory>();
        chargeble = GetComponent<Chargeble>();
    }

    private void Start()
    {
        attackHandlers = new Dictionary<WeaponType, Action>();
        attackHandlers[WeaponType.Sword] = HandleMeele;
        attackHandlers[WeaponType.Bow] = HandleRanged;
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
        if (InputManager.Instance.IsPrimaryActionReleased() && weaponManager.EquipedWeapon == WeaponType.Bow)
        {
            chargeble.SetCharging(false);
            HandleShoot();
        }
        attackCounter = Mathf.Clamp(attackCounter - Time.deltaTime, 0, float.MaxValue);
    }

    private void HandleMeele()
    {
        weaponManager.EquipedMeeleWeapon.gameObject.SetActive(true);
        weaponManager.EquipedMeeleWeapon.Attack(null);
    }

    private void HandleRanged()
    {
        chargeble.SetCharging(true);

    }

    private void HandleShoot()
    {
        float chargeMultiplier = chargeble.GetChargeMultiplier();
        if (attackCounter == 0 && inventory.ArrowsCount > 0)
        {
            Projectile projectile = Instantiate(projectilePrefab, shootPoint);
            Arrow arrowType = inventory.GetEquipedArrow();
            projectile.transform.parent = null;
            Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
            projectile.Damage = (shootDamage + arrowType.Damage) * chargeMultiplier;

            Vector3 shootDirection = transform.forward;
            projectileRigidBody.useGravity = false;
            projectileRigidBody.velocity = shootDirection * projectileSpeed * chargeMultiplier;
            Debug.Log("Shooting");
            Debug.Log($"Damage: {shootDamage + arrowType.Damage}");
            inventory.ConsumeArrow();
            Destroy(projectile.gameObject, 3f);
            attackCounter = 1 / attackSpeed;
        }
    }
}
