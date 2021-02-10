using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> deck = new List<GameObject>();
    public GameObject cardPrefab;

    public bool initializeWithCards = true;
    private void Awake()
    {
        if (initializeWithCards)
        {
            CardData cardData;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    cardData = new CardData(i, j);
                    GameObject card = Instantiate(cardPrefab);
                    card.GetComponent<Card>().SetShape(cardData);
                    Push(card);
                }
            }

            Shuffle();
        }

    }

    
    public void Shuffle()
    {
        // Fisher–Yates shuffle
        for (int i = 0; i < deck.Count; i++)
        {
            int randomPosition = Random.Range(i, deck.Count);
            GameObject temp = deck[i];
            deck[i] = deck[randomPosition];
            deck[randomPosition] = temp;

            // swap(deck[i], deck[Random.Random(i, deck.Count -1)
        }
    }

    public int Count() => deck.Count;
    
    public GameObject Pop()
    {
        if (deck.Count == 0) {
            return null;
        }
        GameObject result = deck[deck.Count - 1];
        deck.RemoveAt(deck.Count - 1);
        result.GetComponent<Card>().Show();
        result.transform.parent = null;
        return result;
    }

    public void Push(GameObject card)
    {
        card.transform.parent = transform;
        card.transform.position = transform.position + Vector3.down * 0.01f * deck.Count;
        card.GetComponent<Card>().Hide();
        card.GetComponent<SpriteRenderer>().sortingOrder = -200 + deck.Count;
        deck.Add(card);
    }

}
