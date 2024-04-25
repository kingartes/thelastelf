using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour, IHit
{
    public GameObject Explosion;
    public GameObject[] DestroyObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        for(int i = 0; i < DestroyObjects.Length; ++i)
        {
            Destroy(DestroyObjects[i]);
        }
        Destroy(gameObject);
    }
}
