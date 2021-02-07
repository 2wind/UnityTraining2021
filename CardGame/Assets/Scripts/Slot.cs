using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public class Slot : MonoBehaviour
{

    private List<GameObject> cards;
    // Start is called before the first frame update
    void Awake()
    {
        cards = new List<GameObject>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Card"))
        {
            // do fancy effect about putting card in

            // if let loose
            if (Input.GetMouseButtonUp(0))
            {
                cards.Add(collision.gameObject);
                // disable and Hide card pattern
                collision.GetComponent<Collider2D>().enabled = false;
                collision.GetComponent<Card>().Hide();
                collision.transform.parent = transform;
                collision.transform.localPosition = Vector3.down * cards.Count * 0.5f;
                GetComponent<Collider2D>().offset += Vector2.down * 0.5f;
            }
        }
    }

    private void OnMouseDown()
    {
        // remove a card from deck
        if (cards.Count > 0)
        {
            var last = cards[cards.Count - 1];
            // find last card at child
            // Activate card
            last.GetComponent<Collider2D>().enabled = true;
            last.GetComponent<Card>().Show();
            last.transform.parent = null;
            GetComponent<Collider2D>().offset -= Vector2.down * 0.5f;
            // Remove card from cards
            cards.Remove(last);
            // card.GetComponent<Interactable>().GetRelativeMousePosition();
        }
        // TODO: 카드가 생성되면 그 카드로 "포커스"가 이동해서 카드가 드래그되도록 만들기.
    }


}
