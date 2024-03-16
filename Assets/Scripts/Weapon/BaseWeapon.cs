using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseWeapon: MonoBehaviour
{
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float attackRange;

    [SerializeField]
    protected float attackInterval;


    public float AttackInterval => attackInterval;
    public float AttackRange => attackRange;
    public float Damage => damage;

    public abstract void Attack(Transform target);
}

