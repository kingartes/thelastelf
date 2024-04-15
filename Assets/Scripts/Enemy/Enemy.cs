using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IHit
{
    private Health health;
    private VisionSensor visionSensor;

    public float enemyRadius = 20f;
    public float awareTimer = 2;

    public void Hit(float damage)
    {
        health.TakeDamage(damage);
        StartCoroutine(AwareHit());
    }

    private void Awake()
    {
        health = GetComponent<Health>();
        health.OnHealthDrop += Health_OnHealthDrop;

        visionSensor = GetComponent<VisionSensor>();
    }

    private void Health_OnHealthDrop(object sender, System.EventArgs e)
    {
        Destroy(gameObject);
    }

    IEnumerator AwareHit()
    {
        float currentRadius = visionSensor.visionRadius;
        float currentAngle = visionSensor.visionAngle;

        visionSensor.visionRadius = 20;
        visionSensor.visionAngle = 360;
        yield return new WaitForSeconds(awareTimer);
        visionSensor.visionRadius = currentRadius;
        visionSensor.visionAngle = currentAngle;
    }
}
