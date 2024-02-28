using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateList_Derprecated
{
    Chase,
    Attack
}

public class EnemyStateContext : StateContext_Deprecated
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
        stateList[EnemyStateList_Derprecated.Chase] = new EnemyChase_Deprecated(this);
        stateList[EnemyStateList_Derprecated.Attack] = new EnemyAttack_Deprecated(this);


        currentState = stateList[EnemyStateList_Derprecated.Chase];

        List<StateTransition_Deprecated> chaseTransitions = new List<StateTransition_Deprecated> {
            new StateTransition_Deprecated(
                StateList[EnemyStateList_Derprecated.Attack],
                new AttackCondition((EnemyChase_Deprecated)stateList[EnemyStateList_Derprecated.Chase])
            )
        };       
        List<StateTransition_Deprecated> attackTransitions = new List<StateTransition_Deprecated> {
            new StateTransition_Deprecated(
                StateList[EnemyStateList_Derprecated.Chase],
                new ChaseCondition((EnemyAttack_Deprecated)stateList[EnemyStateList_Derprecated.Attack])
            )
        };

        stateList[EnemyStateList_Derprecated.Chase].SetupStansitions(chaseTransitions);
        stateList[EnemyStateList_Derprecated.Attack].SetupStansitions(attackTransitions);
    }
}
