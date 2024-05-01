using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement PM;

    [SerializeField]
    private PlayerAttack PA;

    [SerializeField]
    private Health PlayerHealth;

    [SerializeField]
    private EssenceUI EUI;

    public float essenceCapacity = 1000;
    public float currentEssence;
    private float Timer = 0;

    public GameObject Indicator;
    // Start is called before the first frame update
    void Start()
    {
        currentEssence = essenceCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        EssenceTimer();
        PlayerStatsChange();
    }

    public void EssenceTimer()
    {
        if (Timer > 1)
        {
            currentEssence -= 3;
            Timer = 0;
        }
    }

    public void EssenceChange(float amount)
    {
        currentEssence += amount;
        EUI.BarFlash();
    }

    public void PlayerStatsChange()
    {
        if (currentEssence <= essenceCapacity / 2)
        {
            PM.movementSpeed = 10;
            PM.dashDuration = 0.4f;
            PM.dashMultiplier = 0.75f;
            PM.dashCooldown = 0.75f;

            PA.attackSpeed = 1.5f;
            Indicator.SetActive(true);
        }
        else
        {
            PM.movementSpeed = 7;
            PM.dashDuration = 0.25f;
            PM.dashMultiplier = 10;
            PM.dashCooldown = 1.25f;

            PA.attackSpeed = 2f;
        }
    }

    public float GetEssenceNormalized()
    {
        return currentEssence / essenceCapacity;
    }
}
