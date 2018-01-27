using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public HandSlot[] slots;

    private static Hand inst;
    public static Hand Instance
    {
        get { return inst; }
        private set { inst = value; }
    }

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    public void Damage()
    {
        int i = slots.Length - 1;
        while (i>=0 && !slots[i].SlotEnabled)
        {
            i--;
        }
        slots[i].SlotEnabled = false;
        i--;
        for(; i>=0; i--)
        {
            slots[i].Card = null;
        }
        //gestire tempi di animazione
        Deck.Instance.DrawCard();
    }

    public void AddCard()
    {
        int freeSlot = -1;
        int heads = 0, chests = 0, legs = 0, empty = 0;
        for(int i=0; i<slots.Length; i++)
        {
            HandSlot slot = slots[i];
            if (slot.SlotEnabled)
            {
                Card c = slot.Card;
                if (c.IsNull)
                {
                    empty++;
                    if (freeSlot < 0)
                        freeSlot = i;
                }
                else
                {
                    switch (c.part)
                    {
                        case BodyPart.Head:
                            heads++;
                            break;
                        case BodyPart.Chest:
                            chests++;
                            break;
                        case BodyPart.Legs:
                            legs++;
                            break;
                    }
                }
            }
        }

        if (empty == 0) return;
        if (!Deck.Instance.DrawCard()) return;

        BodyPart newPart;

        switch (empty)
        {
            case 1:
                if (heads == 0)
                    newPart = BodyPart.Head;
                else if (chests == 0)
                    newPart = BodyPart.Chest;
                else if (legs == 0)
                    newPart = BodyPart.Legs;
                else
                    newPart = randomPart();
                break;
            case 2:
                if (heads == 0)
                {
                    if (chests == 0)
                        newPart = randomPart(BodyPart.Head, BodyPart.Chest);
                    else if (legs == 0)
                        newPart = randomPart(BodyPart.Head, BodyPart.Legs);
                    else
                        newPart = randomPart();
                }
                else if (chests == 0 && legs == 0)
                    newPart = randomPart(BodyPart.Chest, BodyPart.Legs);
                else
                    newPart = randomPart();
                break;
            default:
                newPart = randomPart();
                break;
        }

        Card card = slots[freeSlot].Card;
        card.part = newPart;
        CardDatabase.Instance.RandomGraphic(card);
        card.GenerateAttributes();
        slots[freeSlot].UpdateCard();
        
    }

    private BodyPart randomPart()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                return BodyPart.Head;
            case 1:
                return BodyPart.Chest;
            case 2:
                return BodyPart.Legs;
        }
        return BodyPart.Head;
    }

    private BodyPart randomPart(BodyPart p1, BodyPart p2)
    {
        if (Random.Range(0, 2) == 0)
            return p1;
        else
            return p2;
    }

    public void DebugCards()
    {
        slots[0].Card.part = BodyPart.None;
        AddCard();
    }
}
