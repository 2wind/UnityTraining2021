using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    // 인터렉션을 허용할 오브젝트에 하나씩 붙이는 방식으로 작동.
    // 장점: 유니티의 네이티브 함수를 이용한다.
    // 단점: 필요한 곳에 일일히 붙여야 한다.

    Vector3 delta = Vector3.zero;

    private void OnMouseOver()
    {
        //호버를 할 때
        //뭔가 테두리를 예쁘게 한다거나? SendMessage가 적절할 듯.
    }
    private void OnMouseDown()
    {
        // 클릭을 했을 때
        // 현재 마우스 위치와 transform 위치 사이의 차이를 delta에 기록한다.
        Vector3 objectPosition = transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.nearClipPlane;
        delta = objectPosition - mousePosition;

    }

    private void OnMouseDrag()
    {
        // 드래그 중에
        // delta를 유지하면서 mouse position에 따라간다.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.nearClipPlane;
        transform.position = mousePosition + delta;
    }

    private void OnMouseUp()
    {
        // 클릭이 끝나면
        // delta를 초기화한다.
        delta = Vector3.zero;
    }

}
