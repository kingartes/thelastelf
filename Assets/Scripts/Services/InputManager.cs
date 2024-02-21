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

    public Vector2 GetMouseScreenPosition()
    {
        return Input.mousePosition;
    }

    public bool IsSwitchBuildingMode()
    {
        return Input.GetKeyDown(KeyCode.B);
    }

    public bool IsPrimaryActionButtonPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsDashedPressed()
    {
        return Input.GetKeyDown(KeyCode.LeftShift); 
    }

    public bool IsEquipRangePressed() { 
        return Input.GetKeyDown(KeyCode.Alpha1);
    }

    public bool IsEquipedMeelePressed()
    {
        return Input.GetKeyDown(KeyCode.Alpha2);
    }

    public bool IsParryPressed()
    {
        return Input.GetKeyDown (KeyCode.Space);
    }
}
