using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerWalk: State
{
    private PlayerMovement playerMovement; 

    public PlayerWalk(PlayerMovement playerMovement) : base(PlayerStateList.WALKING)
    {
        this.playerMovement = playerMovement;
        Debug.Log(playerMovement);
    }

    public override void OnLogic()
    {
        base.OnLogic();
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        Vector3 movementVector = new Vector3(movementDirection.x, 0, movementDirection.y);

        Vector3 velocityVector = movementVector * playerMovement.MovementSpeed * Time.deltaTime;
        playerMovement.CharacterController.Move(velocityVector);
        playerMovement.transform.forward = Vector3.Slerp(playerMovement.transform.forward, movementVector, Time.deltaTime * playerMovement.RotationSpeed);
    }

}
