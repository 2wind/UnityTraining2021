using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float maxDragDistance = 2.5f;
    public float tension = 2f;

    public Transform leftArmEnd;
    public Transform rightArmEnd;

    Vector3 launchPosition;
    GameObject projectile;
    bool isAiming;
    Camera mainCamera;

    private Vector3 TOP_CENTER;
    


    Renderer[] children;

    Shader standard;
    Shader outline;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Renderer>();
        standard = Shader.Find("Standard");
        outline = Shader.Find("Outlined/UltimateOutline");
        isAiming = false;
        TOP_CENTER = transform.position + Vector3.up * 3;
        mainCamera = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        foreach (var child in children)
        {
            child.material.shader = outline;
        }
        
    }

    private void OnMouseExit()
    {
        foreach (var child in children)
        {
            child.material.shader = standard;
        }
    }

    private void OnMouseDown()
    {
        // if click;
        // Initiate Dragging
        // Generate Projectile
        // Generate Line render from Arm End to mouse point Up to max Drag distance from it

        if (FollowCamera.current.pointOfInterest && FollowCamera.current.pointOfInterest.CompareTag("Projectile"))
            return;
        isAiming = true;

        // calc point of click
        projectile = Instantiate<GameObject>(projectilePrefab);
        launchPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        launchPosition.z = 0f;
        projectile.transform.position = launchPosition;



    }
    private void OnMouseDrag()
    {
        if (isAiming)
        {
            launchPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            launchPosition.z = 0f;
            if ((TOP_CENTER - launchPosition).magnitude > maxDragDistance)
            {
                launchPosition = TOP_CENTER + (launchPosition - TOP_CENTER).normalized * maxDragDistance;
            }
            projectile.transform.position = launchPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isAiming)
        {
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            var dragForce = (TOP_CENTER - launchPosition) * tension;
            projectile.GetComponent<Rigidbody>().AddForce(dragForce);
            FollowCamera.current.pointOfInterest = projectile;
            isAiming = false;
        }
    }
}
