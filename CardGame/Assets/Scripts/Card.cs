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
    public enum Sign { Spade, Diamond, Heart, Clover}
    public enum Number { NotANumber, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King}
    public Sign sign;
    public Number number;

    public TextMesh signText;
    public TextMesh numberText;

    bool isHidden = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCardShape();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Functions about Initial Setting
    public void SetShape(Sign sign, Number number)
    {
        this.sign = sign;
        this.number = number;
        UpdateCardShape();
    }

    // Functions about Updatating visual according to value
    void UpdateCardShape()
    {
        signText.text = Enum.GetName(typeof(Sign), sign);
        numberText.text = Enum.GetName(typeof(Number), number);
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
