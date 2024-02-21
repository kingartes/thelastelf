using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateList
{
    Chase,
    Attack
}

public class EnemyStateContext : StateContext
{
    [SerializeField]
    private float enemyMovementSpeed = 10f;

    [SerializeField]
    private float chaseDistance = 2.0f;
    [SerializeField]
    private float attackDelay = 0.3f;
    [SerializeField]
    private float attackDamage = 40;
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private MeeleWeapon weapon;

    private Transform chaseTarget;
    private CharacterController characterController;

    public Rigidbody RigidbodyComponent { get; private set; }
    public float EnemyMovementSpeed => enemyMovementSpeed;
    public float AttackDelay => attackDelay;
    public float AttackDamage => attackDamage;
    public CharacterController CharacterController => characterController;

    public LayerMask LayerMask => layerMask;

    public float ChaseDistance => chaseDistance;
    public Transform ChaseTarget => chaseTarget;

    public MeeleWeapon Weapon => weapon;

    protected override void Initialize()
    {
        base.Initialize();

        RigidbodyComponent = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        PlayerStateContext player = FindAnyObjectByType<PlayerStateContext>();
        chaseTarget = player.transform;
        stateList[EnemyStateList.Chase] = new EnemyChase(this);
        stateList[EnemyStateList.Attack] = new EnemyAttack(this);


        currentState = stateList[EnemyStateList.Chase];

        List<StateTransition> chaseTransitions = new List<StateTransition> {
            new StateTransition(
                StateList[EnemyStateList.Attack],
                new AttackCondition((EnemyChase)stateList[EnemyStateList.Chase])
            )
        };       
        List<StateTransition> attackTransitions = new List<StateTransition> {
            new StateTransition(
                StateList[EnemyStateList.Chase],
                new ChaseCondition((EnemyAttack)stateList[EnemyStateList.Attack])
            )
        };

        stateList[EnemyStateList.Chase].SetupStansitions(chaseTransitions);
        stateList[EnemyStateList.Attack].SetupStansitions(attackTransitions);
    }
}
