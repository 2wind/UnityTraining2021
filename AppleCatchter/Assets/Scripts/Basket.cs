using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Basket : MonoBehaviour
{
    public delegate void CatchAction();
    public static event CatchAction OnCatch;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 TargetPos = transform.position;
        TargetPos.x = mousePos3D.x;
        this.transform.position = TargetPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            OnCatch();
            Destroy(collision.gameObject);
            
        }
    }


}
