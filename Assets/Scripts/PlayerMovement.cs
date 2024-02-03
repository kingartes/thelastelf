using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10;

    void Update()
    {
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        Vector3 movementVector = new Vector3(movementDirection.x, 0, movementDirection.y);

        transform.position += movementVector * movementSpeed * Time.deltaTime; 
    }
}
