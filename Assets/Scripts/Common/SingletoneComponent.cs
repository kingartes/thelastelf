using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneComponent<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Could not initialize instance of {typeof(T)}");
        }
        Instance = this as T;
    }
}
