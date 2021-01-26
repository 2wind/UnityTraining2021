using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20 || transform.position.y < -20 || transform.position.x > 150)
        {
            _ = StartCoroutine(nameof(OnDestroyed));
        }
    }

    IEnumerator OnDestroyed()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    
}
