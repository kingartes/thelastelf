using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSection : MonoBehaviour
{
    [SerializeField]
    private Transparency TS;

    private bool enteredZone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!enteredZone)
            {
                TS.ChangeTransparency(true);
                enteredZone = true;
            }
            else if (enteredZone)
            {
                TS.ChangeTransparency(false);
                enteredZone = false;
            }
        }

    }

}
