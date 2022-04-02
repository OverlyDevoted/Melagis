using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] GameObject cardModel;
    public int value;
    public Suits suit;
    void Start()
    {
        UpdateCard(cardModel);
    }
    private void UpdateCard(GameObject cardModel)
    {
        if (cardModel == null)
            return;
        char[] temp = cardModel.name.Substring(13, cardModel.name.Length - 13).ToCharArray();
        int startIndex = 1;
        if (char.IsNumber(temp[0]))
        {
            value = temp[0] - 48;
            if (value == 1)
            {
                value *= 10;
                startIndex = 2;
            }
        }
        else
        {
            switch (temp[0])
            {
                case 'J':
                    value = 11;
                    break;

                case 'Q':
                    value = 12;
                    break;

                case 'K':
                    value = 13;
                    break;

                case 'A':
                    value = 14;
                    break;
            }
        }
        switch (temp[startIndex])
        {
            case 'C':
                suit = Suits.Club;
                break;

            case 'D':
                suit = Suits.Diamond;
                break;

            case 'H':
                suit = Suits.Heart;
                break;

            case 'S':
                suit = Suits.Spade;
                break;
        }
        name = value.ToString() + temp[startIndex];
        cardModel.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum Suits
{
    Heart,
    Club,
    Spade,
    Diamond
}
