using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chargeble : MonoBehaviour
{
    public event EventHandler<bool> OnChargeSetState;
    public event EventHandler<float> OnChargeUpdate;

    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private float minChargeMultiplier = 0.5f;
    [SerializeField]
    private float maxChargeMultiplier = 1.2f;

    private bool isCharging;
    private float chargeState = 0;

    public void SetCharging(bool isCharging)
    {
        if (isCharging)
        {
            chargeState = 0;
        }
        this.isCharging = isCharging;
        OnChargeSetState?.Invoke(this, isCharging);
    }

    public float GetChargeMultiplier()
    {
        return Mathf.Lerp(minChargeMultiplier, maxChargeMultiplier, chargeState);
    }

    private void Update()
    {
        if (isCharging)
        {
            chargeState = Mathf.Clamp(chargeState + Time.deltaTime*chargeSpeed, 0, 1);
            OnChargeUpdate?.Invoke(this, chargeState);
        }
    }

}
