using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleWeapon : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IHit>(out IHit hitable))
        {
            hitable.Hit(30);
        }
       
    }


    public void Attack()
    {
        animator.Play("MeeleAttack");
    }

    public void StopAttack()
    {
        gameObject.SetActive(false);
    }
   
}
