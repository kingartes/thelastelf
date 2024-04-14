using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Collider projectileCollision;
    private void Awake()
    {
        Destroy(gameObject, 0.5f);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Explosion");
        if (collision.gameObject.TryGetComponent<IHit>(out IHit hitable))
        {
            hitable.Hit(200f);
        }

        projectileCollision.enabled = false;
    }


}
