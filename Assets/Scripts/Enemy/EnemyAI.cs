using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(VisionSensor))]
public class EnemyAI : MonoBehaviour
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
    private BaseWeapon weapon;

    [SerializeField]
    private float chaseAttackDistance;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private List<PatrolPoint> patrolPoints;
    [SerializeField]
    private float aggressionRadius = 10;

    private Transform chaseTarget;
    private CharacterController characterController;
    public float EnemyMovementSpeed => enemyMovementSpeed;
    public float AttackDelay => attackDelay;
    public float AttackDamage => attackDamage;
    public CharacterController CharacterController => characterController;

    public float AggressionRadius => aggressionRadius;

    public LayerMask LayerMask => layerMask;

    public float ChaseDistance => chaseDistance;
    public float ChaseAttackDistance => chaseAttackDistance;
    public Transform ChaseTarget => chaseTarget;

    public Animator Animator => animator;

    public List<PatrolPoint> PatrolPoints => patrolPoints;

    public BaseWeapon Weapon => weapon;

    protected EnemyMovementSM movementFsm;
    protected EnemyAttackSM attackFsm;
    private VisionSensor visionSensor;

    protected virtual void SetupFSM()
    {
        movementFsm = new EnemyMovementSM(this);
        movementFsm.Init();
        attackFsm = new EnemyAttackSM(this);
        attackFsm.Init();
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        Player player = FindAnyObjectByType<Player>();
        chaseTarget = player.transform;
        SetupFSM();
        visionSensor = GetComponent<VisionSensor>();
        visionSensor.Init(player);
    }

    private void Update()
    {
        movementFsm.OnLogic();
        attackFsm.OnLogic();
    }

    public bool IsInAttackRange()
    {
        Vector3 targetPosition = ChaseTarget.position;
        Vector3 position = transform.position;
        return Vector3.Distance(position, targetPosition) <= weapon.AttackRange;
    }

    public bool IsInChaseAttackRange()
    {
        Vector3 targetPosition = ChaseTarget.position;
        Vector3 position = transform.position;
        return Vector3.Distance(position, targetPosition) <= ChaseAttackDistance;
    }

    public bool IsTargetInVision()
    {
        if (visionSensor.IsPlayerVisible)
        {
            Debug.Log("Player in vision");
        }
        return visionSensor.IsPlayerVisible;
    }

    public void OnDrawGizmosSelected()
    {
        int index = 0;
        foreach(var point in patrolPoints)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(point.transform.position, 1);
#if UNITY_EDITOR
            UnityEditor.Handles.color = Color.white;
            var labelPosition = point.transform.position;
            labelPosition.y += 5;
            labelPosition.x -= 0.5f;
            UnityEditor.Handles.Label(labelPosition, $"Point {index}");
            index++;
#endif
        }
    }
}

