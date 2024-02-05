using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IPickable
{
    [SerializeField]
    private float starveFullfill = 20;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if ( other.gameObject.TryGetComponent<Starving>(out Starving playerStarving))
        {
            PickUp(playerStarving);
        }
    }

    public void PickUp(Starving playerStarving)
    {
        playerStarving.EatFood(starveFullfill);
        Destroy(gameObject);
    }

}
