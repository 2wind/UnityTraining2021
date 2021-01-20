using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

    public static GameEvent current;
    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    public event Action OnProjectileFired;

    public void ProjectileFired(GameObject projectile) => OnProjectileFired?.Invoke();

    // Update is called once per frame
    void Update()
    {
        
    }
}
