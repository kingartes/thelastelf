using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SingletoneComponent<InputManager>
{
    public Vector2 GetMovementDirectionVector ()
    {
        Vector2 movementVector = new Vector2 (0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            movementVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector.x = 1;
        }

        return movementVector.normalized;
    }
}
