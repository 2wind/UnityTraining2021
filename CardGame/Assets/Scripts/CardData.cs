using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public enum SIGN { Spade, Diamond, Heart, Clover }
    public enum NUMBER { NotANumber, Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public SIGN Sign { get; }
    public NUMBER Number { get;}
    public CardData()
    {
        Sign = SIGN.Spade;
        Number = NUMBER.NotANumber;
    }

    public CardData(SIGN sign, NUMBER number)
    {
        this.Sign = sign;
        this.Number = number;
    }

    public CardData(int sign, int number)
    {
        if (!(Enum.IsDefined(typeof(SIGN), sign) && Enum.IsDefined(typeof(NUMBER), number))) 
            throw new IndexOutOfRangeException("sign or number is not within correct range");

        this.Sign = (SIGN)sign;
        this.Number = (NUMBER)number;
    }

    public string GetSign() => Enum.GetName(typeof(SIGN), Sign);
    public string GetNumber() => Enum.GetName(typeof(NUMBER), Number);



    
}
