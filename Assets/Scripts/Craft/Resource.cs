using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private ResourceSO resourceSO = null;

    [SerializeField]
    private int resourceAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Inventory>(out Inventory inventory))
        {
            inventory.AddResource(resourceSO.Type, resourceAmount);
            Destroy(gameObject);
        }
    }
}
