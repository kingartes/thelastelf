using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 10f;
    [SerializeField]
    private float dashDuration = 1f;
    [SerializeField]
    private float dashMultiplier = 5f;
    [SerializeField]
    private float dashCooldown = 1f;
    [SerializeField]
    private AnimationCurve dashDecayCurve;
    [SerializeField]
    private float rotationSpeed;

    private float dashCooldownCounter = 0;
    private CharacterController characterController;

    public float MovementSpeed => movementSpeed;
    public float DashDuration => dashDuration;
    public float DashMultiplier => dashMultiplier;
    public float DashCooldown => dashCooldown;

    public float DashCooldownCounter => dashCooldownCounter;
    public AnimationCurve DashDecayCurve => dashDecayCurve;

    public CharacterController CharacterController => characterController;

    public float RotationSpeed => rotationSpeed;
    
    private PlayerSM fsm;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        fsm = new PlayerSM(this);
        fsm.Init();
    }

    private void Update()
    {
        fsm.OnLogic();
    }
}

