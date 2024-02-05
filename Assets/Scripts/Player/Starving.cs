using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starving : MonoBehaviour
{
    public event EventHandler onStarveChanged;
    public event EventHandler onStarveExpired;

   

    [SerializeField]
    private float starvingValue = 1f;
    [SerializeField]
    private float starvingDelay = 1f;


    private const float MAX_STARVING_VALUE = 100f;
    private float starving = MAX_STARVING_VALUE;

    private float starvingCounter = 0f;

    private void Update()
    {
        if (starvingCounter >=starvingDelay)
        {
            starvingCounter = 0f;
            starving = Mathf.Clamp(starving - starvingValue, 0 , MAX_STARVING_VALUE);
            onStarveChanged?.Invoke(this, EventArgs.Empty);
        }
        if (starving <= 0f)
        {
            onStarveExpired?.Invoke(this, EventArgs.Empty);
        }
        starvingCounter += Time.deltaTime;
    }

    public float GetStarvingNormalized()
    {
        return starving / MAX_STARVING_VALUE;
    }

    public void EatFood(float starveAmount)
    {
        starving = Mathf.Clamp(starving + starveAmount, 0, MAX_STARVING_VALUE);
        onStarveChanged?.Invoke(this, EventArgs.Empty);
    }

}
