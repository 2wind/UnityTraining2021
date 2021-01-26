using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_transform.position.x < -20 || _transform.position.y < -20 || _transform.position.x > 150)
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
