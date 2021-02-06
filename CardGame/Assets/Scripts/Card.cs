using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Card : MonoBehaviour
{
    // Card Component.
    // Made of enum Sign and number.
    // Rendered using SpriteRenderer.

    // TODO: 카드끼리 겹치면 나중에 클릭한 쪽이 위로 올라가고, 그 순서가 유지되도록 하는 강건한 알고리즘 만들기
    
    [SerializeField]
    private CardData cardData;

    public TextMesh signText;
    public TextMesh numberText;

    bool isHidden = false;

    void Awake()
    {
        cardData = new CardData();
        UpdateCardShape();
        
    }



    // Functions about Initial Setting
    public void SetShape(CardData.SIGN sign, CardData.NUMBER number)
    {
        cardData = new CardData(sign, number);
        UpdateCardShape();
    }

    public void SetShape(CardData cardData)
    {
        this.cardData = cardData;
        UpdateCardShape();
    }

    // Functions about Updatating visual according to value
    void UpdateCardShape()
    {
        signText.text = cardData.GetSign();
        numberText.text = cardData.GetNumber();
    }
    void UpdateCardVisual()
    {
        GetComponent<SpriteRenderer>().sortingOrder = isHidden ? 1 : 0;
    }

    //Utility function that acts something to card

    public void Hide()
    {
        isHidden = true;
        UpdateCardVisual();
    }

    public void Show()
    {
        isHidden = false;
        UpdateCardVisual();
    }




}
