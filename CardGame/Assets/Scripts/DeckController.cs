﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    [SerializeField]
    private List<CardData> deck = new List<CardData>();

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
                    deck.Add(cardData);
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
            int randomPosition = Random.Range(i, deck.Count - 1);
            CardData temp = deck[i];
            deck[i] = deck[randomPosition];
            deck[randomPosition] = temp;

            // swap(deck[i], deck[Random.Random(i, deck.Count -1)
        }
    }

    public int Count() => deck.Count;
    
    public CardData Pop()
    {
        if (deck.Count == 0) {
            return null;
        }
        CardData result = deck[deck.Count - 1];
        deck.RemoveAt(deck.Count - 1);
        return result;
    }

    public void Push(CardData cardData)
    {
        deck.Add(cardData);
    }

}
