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
    }

    public override void OnEnter()
    {
        playerMovement.Animator.SetBool(PlayerMovement.ANIMATION_RUNNING, true);
    }

    public override void OnExit()
    {
        playerMovement.Animator.SetBool(PlayerMovement.ANIMATION_RUNNING, false);
    }

    public override void OnLogic()
    {
        base.OnLogic();
        Vector2 movementDirection = InputManager.Instance.GetMovementDirectionVector();
        Vector3 movementVector = new Vector3(movementDirection.x, 0, movementDirection.y);
   

        Vector3 velocityVector = movementVector * playerMovement.MovementSpeed * Time.deltaTime;
        playerMovement.CharacterController.Move(velocityVector);
        Vector3 forward = playerMovement.transform.forward;
        Vector3 right = playerMovement.transform.right;

        Debug.Log("Walks");
        playerMovement.Animator.SetFloat("x", Vector3.Dot(movementVector, right));
        playerMovement.Animator.SetFloat("y", Vector3.Dot(movementVector, forward));
    }

}
