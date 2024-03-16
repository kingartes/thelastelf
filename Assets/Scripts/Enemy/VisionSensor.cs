using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSensor : MonoBehaviour
{
    [SerializeField]
    private float visionRadius = 10f;

    [SerializeField]
    private float visionAngle = 90f;

    [SerializeField]
    private float scanInterval = 0.2f;
    [SerializeField]
    private float visionHeight = 0.5f;
    [SerializeField]
    private LayerMask layerMask;

    private Player target;

    private bool isPlayerVisible = false;

    public bool IsPlayerVisible => isPlayerVisible;
    public float VisionRadius => visionRadius;


    public void Init(Player target)
    {
        this.target = target;
        StartCoroutine(ScanTarget());
    }

    private IEnumerator ScanTarget()
    {
        while (true)
        {
        
            isPlayerVisible = IsTargetInVision();
            yield return new WaitForSeconds(scanInterval);
        }
    }

    private bool IsTargetInVision()
    {
        Vector3 targetXZVector = target.transform.position;
        Vector3 scanPosition = transform.position;
        scanPosition.y = visionHeight;
        targetXZVector.y = visionHeight;
        Vector3 directionToTarget = (targetXZVector - scanPosition).normalized;
        Debug.DrawRay(scanPosition, directionToTarget * 5, Color.red, 5);
        if (Vector3.Distance(scanPosition, targetXZVector) <= visionRadius && Vector3.Angle(transform.forward, directionToTarget) <= visionAngle / 2)
        {
            if (Physics.SphereCast(scanPosition, 0.5f, directionToTarget, out RaycastHit hitInfo, visionRadius + 1, layerMask))
            {
                return hitInfo.collider.TryGetComponent<Player>(out Player player);
            };
            
        }
        return false;
    }

    public (Vector3, Vector3) GetConeBoundVectors()
    {
        Vector3 leftVector = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * visionRadius;
        Vector3 rightVector = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * visionRadius;
        return (leftVector, rightVector);
    }
}
