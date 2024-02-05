using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10;
    [SerializeField]
    private float evasionSpeed = 5f;
    [SerializeField]
    private AnimationCurve evasionCurve;
    [SerializeField]
    private float evasionTime = 1;

    private Rigidbody rb;

    private bool isEvading;
    private float evasionCounter = 0f;


    public Vector3 MovementVector { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        MovementVector = new Vector3(movementDirection.x, 0, movementDirection.y);

        Vector3 velocityVector = MovementVector * movementSpeed;

        if (InputManager.Instance.IsEvasionPressed())
        {
            isEvading = true;
            evasionCounter = 0f;
        }

        if (isEvading)
        {
            evasionCounter += Time.deltaTime;
           if (evasionCounter < evasionTime)
            {
                velocityVector *= evasionCurve.Evaluate(evasionCounter) * evasionSpeed;
            } else
            {
                isEvading = false;
            }
        }

        rb.velocity = velocityVector;
    }
}
