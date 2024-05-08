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
    private PlayerAttackAnimator attackAnimator;

    [SerializeField] 
    private Animator animator;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    public float attackSpeed;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float shootDamage;

    [SerializeField]
    private GameObject firstArrow;

    [SerializeField]
    private GameObject secondArrow;

    [SerializeField]
    private GameObject thirdArrow;

    private WeaponManager weaponManager;

    private Inventory inventory;
    private Chargeble chargeble;

    private EssenceSystem ES;

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
        ES = GetComponent<EssenceSystem>();
    }

    private void Update()
    {
        if (InputManager.Instance.EquipFirstArrowPressed())
        {
            inventory.EquipeArrow(firstArrow);
        }
        if (InputManager.Instance.EquipSecondArrowPressed())
        {
            inventory.EquipeArrow(secondArrow);
        }
        if (InputManager.Instance.EquipThirdArrowPressed())
        {
            inventory.EquipeArrow(thirdArrow);
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
        animator.SetTrigger("Shoot");
        chargeble.SetCharging(true);

    }

    private void HandleShoot()
    {
        float chargeMultiplier = chargeble.GetChargeMultiplier();
        if (attackCounter == 0 && inventory.ArrowsCount(inventory.SelectedArrowType) > 0)
        {
            attackAnimator.ResumeAttackAnimation();
            Projectile projectile = Instantiate(projectilePrefab, shootPoint);
            Arrow arrowType = inventory.GetEquipedArrow();
            projectile.transform.parent = null;
            Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
            projectile.Damage = (shootDamage + arrowType.Damage) * chargeMultiplier;

            Vector3 shootDirection = transform.forward;
            projectileRigidBody.useGravity = false;
            projectileRigidBody.velocity = shootDirection * projectileSpeed * chargeMultiplier;
 
            inventory.ConsumeArrow();
            Destroy(projectile.gameObject, 3f);
            attackCounter = 1 / attackSpeed;
            ES.EssenceChange(-5);
        }
    }
}
