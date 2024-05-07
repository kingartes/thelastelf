using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject WallRise;
    public GameObject BossHealth;


    private bool hasEntered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasEntered)
        {
            WallRise.SetActive(true);
            BossHealth.SetActive(true);
            hasEntered = true;  
        }
    }
}
