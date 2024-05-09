using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void PauseAttackAnimation()
    {

    }

    public void ResumeAttackAnimation()
    {
        animator.SetTrigger("Shootfinished");
    }
}
