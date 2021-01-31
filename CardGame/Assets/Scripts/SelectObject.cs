using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/
public class SelectObject : MonoBehaviour
{
    public GameObject selectedObject;
    public LayerMask layerMask;


    Vector3 delta;
    // Update is called once per frame
    // 별도의 GameObject에서 ray를 쏴서 맞은 오브젝트와 마우스 클릭에 따라 행동하는 방식.
    // 장점: 스크립트를 한 곳에만 붙이고, 레이어 마스크를 이용해 인터렉션 가능한 오브젝트를 구할 수 있다. 
    // 단점: 간단한 클릭, 호버에 적합하나 마우스를 격하게 움직이면 마우스의 이동 속도를 따라오지 못한다.
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, layerMask);
        {
            if (hitData)
            {

                if (Input.GetMouseButtonDown(0))
                {
                    // Object Selected..
                    selectedObject = hitData.transform.gameObject;

                    // Calculate diff between Object and mouse position
                    Vector3 objectPosition = selectedObject.transform.position;
                    Vector3 mousePosition = worldPosition;
                    mousePosition.z = Camera.main.nearClipPlane;
                    delta = objectPosition - mousePosition;
                } 
                else if (Input.GetMouseButton(0))
                {
                    // and move Object while keeping delta.
                    Vector3 mousePosition = worldPosition;
                    mousePosition.z = Camera.main.nearClipPlane;
                    selectedObject.transform.position = mousePosition + delta;
                }
                else if (Input.GetMouseButtonUp(0))
                {


                }


            }

        }
    }
}
