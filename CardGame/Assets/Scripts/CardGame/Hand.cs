using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckController))]
public class Hand : MonoBehaviour
{
    private DeckController deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = GetComponent<DeckController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.CompareTag("Card"))
            {
                if (collision.transform.parent == null)
                    deck.Push(collision.gameObject);
                else
                {
                    List<GameObject> result = collision.transform.parent.GetComponent<Slot>().TryGetCardFrom(collision.gameObject);
                    if (result != null)
                        deck.PushRange(result);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnMouseUp()
    {
        if (deck.Count() > 0)
        {

        }
    }
}
