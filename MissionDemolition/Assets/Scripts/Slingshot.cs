using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float maxDragDistance = 2.5f;

    public Transform leftArmEnd;
    public Transform rightArmEnd;

    Vector3 launchPosition;
    GameObject projectile;
    bool isAiming;
    


    Renderer[] children;

    Shader standard;
    Shader outline;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Renderer>();
        standard = Shader.Find("Standard");
        outline = Shader.Find("UltimateOutline");
        outline = Shader.Find("Outlined/UltimateOutline");
        isAiming = false;
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

        isAiming = true;

        // calc point of click

        launchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = launchPosition;


    }
}
