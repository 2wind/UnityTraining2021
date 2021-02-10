using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DeckController), typeof(Collider2D))]

public class Slot : MonoBehaviour
{
    [SerializeField]
    private DeckController deckController;
    // Start is called before the first frame update
    void Awake()
    {
        deckController = GetComponent<DeckController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Card"))
        {
            // do fancy effect about putting card in

            // if let loose
            if (Input.GetMouseButtonUp(0))
            {
                PutCard(collision.gameObject);
                //show last card face only
                
            }
        }
    }

    private void PutCard(GameObject card)
    {
        deckController.Push(card);
        // disable and Hide card pattern
        card.transform.parent = transform;
        card.transform.localPosition = Vector3.down * deckController.Count() * 0.5f;
        GetComponent<Collider2D>().offset += Vector2.down * 0.5f;
    }

    private void OnMouseDown()
    {
        // remove a card from deck
        if (deckController.Count() > 0)
        {
            var last = deckController.Pop();
            // find last card at child
            // Activate card
            last.transform.parent = null;
            GetComponent<Collider2D>().offset -= Vector2.down * 0.5f;
            // Remove card from cards
            // card.GetComponent<Interactable>().GetRelativeMousePosition();
        }
        // TODO: 카드가 생성되면 그 카드로 "포커스"가 이동해서 카드가 드래그되도록 만들기.
    }


}
