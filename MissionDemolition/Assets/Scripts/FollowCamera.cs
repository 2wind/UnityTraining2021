using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public static FollowCamera current;
    public float cameraZ;
    public float easing = 0.05f;

    public GameObject pointOfInterest;

    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        cameraZ = transform.position.z;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (pointOfInterest == null)
        {
            GetComponent<Camera>().orthographicSize = 10;
            return;
        }


        Vector3 destination = pointOfInterest.transform.position;
        destination.x = Mathf.Max(0, destination.x);
        destination.y = Mathf.Max(0, destination.y);
        destination.z = cameraZ;
        if (Vector3.Magnitude(transform.position - destination) > 0.1f){
            transform.position = (Vector3.Lerp(transform.position, destination, easing));
            GetComponent<Camera>().orthographicSize = 10 + destination.y / 2;
        }
    }
}
