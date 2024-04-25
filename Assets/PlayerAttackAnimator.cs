using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerAttackAnimator : MonoBehaviour
{
    private Animator animator;
    private AnimatorState shootingState;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void PauseAttackAnimation()
    {
        Debug.Log("Pause");
        AnimatorController ac = animator.runtimeAnimatorController as AnimatorController;
        shootingState = ac.layers[1].stateMachine.states[1].state;
        Debug.Log(shootingState);
        shootingState.speed = 0;
    }

    public void ResumeAttackAnimation()
    {
        Debug.Log("RESUME");
        animator.SetTrigger("Shootfinished");
    }
}
