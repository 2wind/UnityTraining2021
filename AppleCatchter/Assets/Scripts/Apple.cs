using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -1f;

    public delegate void DestroyAction();
    public static event DestroyAction OnDestroy;

    private void OnEnable()
    {
        OnDestroy += DestroyItself;

    }

    private void OnDisable()
    {
        OnDestroy -= DestroyItself;

    }

    private void DestroyItself()
    {
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        if (apples != null)
        {
            foreach (var apple in apples)
            {
                Destroy(apple);
            }
        }
    }

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            OnDestroy();
        }
    }
}