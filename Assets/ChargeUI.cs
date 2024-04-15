using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUI : MonoBehaviour
{
    [SerializeField]
    private Chargeble chargeble;

    [SerializeField]
    private Image chargeBar;


    void Start()
    {
        chargeble.OnChargeSetState += Chargeble_OnChargeSetState;
        chargeble.OnChargeUpdate += Chargeble_OnChargeUpdate;
        gameObject.SetActive(false);
    }

    private void Chargeble_OnChargeUpdate(object sender, float e)
    {
        chargeBar.fillAmount = e;
    }

    private void Chargeble_OnChargeSetState(object sender, bool e)
    {
        gameObject.SetActive(e);
    }
}
