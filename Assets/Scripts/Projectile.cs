using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get; set; }


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Collider projectileCollision = gameObject.GetComponent<Collider>();
        if ( collision.gameObject.TryGetComponent<IHit>(out IHit hitable))
        {
            hitable.Hit(Damage);
        }

        rb.isKinematic = true;
        projectileCollision.enabled = false;
        
        Destroy(gameObject, 0.1f);
    }
}
