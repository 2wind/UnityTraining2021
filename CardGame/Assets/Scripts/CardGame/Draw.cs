using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeckController), typeof(Collider2D))]
public class Draw : MonoBehaviour
{

    private DeckController deck;
    // Start is called before the first frame update
    void Awake()
    {
        deck = GetComponent<DeckController>();
    }

    private void OnMouseOver()
    {
        // Highlight
    }
    private void OnMouseDown()
    {
        // remove a card from deck
        if (deck.Count() > 0)
        {
            GameObject card = deck.Pop();
            // generate a card 
            card.transform.parent = transform;
            card.transform.position = transform.position;
            // card.GetComponent<Interactable>().GetRelativeMousePosition();
        }
        // TODO: 카드가 생성되면 그 카드로 "포커스"가 이동해서 카드가 드래그되도록 만들기.

    }


}
