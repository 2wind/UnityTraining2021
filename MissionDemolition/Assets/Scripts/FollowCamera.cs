using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public static FollowCamera current;
    public float cameraZ;
    public float easing = 0.05f;
    public GameObject defaultObject;

    public GameObject pointOfInterest;
    

    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        cameraZ = transform.position.z;
        pointOfInterest = defaultObject;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 destination;
        if (!pointOfInterest)
        {
            destination = Vector3.zero;
            GetComponent<Camera>().orthographicSize = 10;
            
        } else {
            destination = pointOfInterest.transform.position;
            if (pointOfInterest.CompareTag("Projectile") && pointOfInterest.GetComponent<Rigidbody>().IsSleeping())
            {
                pointOfInterest = defaultObject;
                destination = Vector3.zero;
            }
        }

        destination.x = Mathf.Max(0, destination.x);
        destination.y = Mathf.Max(0, destination.y);
        destination.z = cameraZ;
        if (Vector3.Magnitude(transform.position - destination) > 0.1f)
        {
            transform.position = (Vector3.Lerp(transform.position, destination, easing));
            GetComponent<Camera>().orthographicSize = 10 + destination.y / 2;
        }




    }
}
