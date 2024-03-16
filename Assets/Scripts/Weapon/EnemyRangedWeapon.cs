using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyRangedWeapon: BaseWeapon
{ 

    [SerializeField]
    private Transform shootingPoint;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private Projectile projectilePrefab;

    public override void Attack(Transform target)
    {
        Projectile projectile = Instantiate(projectilePrefab, shootingPoint);
        projectile.transform.parent = null;
        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();
        projectile.Damage = damage;
        Vector3 targetPosition = target.position;
        targetPosition.y = shootingPoint.position.y;
        Vector3 shootDirection = targetPosition - shootingPoint.position;
        projectileRigidBody.useGravity = false;
        projectileRigidBody.velocity = shootDirection * projectileSpeed;
        Destroy(projectile.gameObject, 3f);
    }
}

