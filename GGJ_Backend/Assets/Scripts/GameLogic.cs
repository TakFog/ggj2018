using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChanibaL;

public enum BodyPart { None, Head, Chest, Legs };

[System.Serializable]
public class Card
{
    public const int MAX_ATTRIBUTE = 9;

    public BodyPart part = BodyPart.None;
    public int attack;
    public int defence;
    public float speed;
    public int graphictype;

    public void Swap(Card card)
    {
        int tempattack = this.attack;
        int tempdefence = this.defence;
        float tempspeed = this.speed;
        BodyPart temppart = this.part;
        int tempgraphictype = this.graphictype;

        this.attack = card.attack;
        this.defence = card.defence;
        this.speed = card.speed;
        this.part = card.part;
        this.graphictype = card.graphictype;

        card.attack  = tempattack;
        card.defence = tempdefence;
        card.speed = tempspeed;
        card.part = temppart;
        card.graphictype = tempgraphictype;
    }

    public bool IsNull
    {
        get { return part == BodyPart.None; }
    }

    public void SetNull()
    {
        part = BodyPart.None;
    }

    public void GenerateAttributes()
    {
        if (part == BodyPart.Legs)
        {
            defence = 0;
            if (speed == 0)
            {
                attack = 0;
            }
            else
            {
                attack = MAX_ATTRIBUTE;
            }
        }
        else
        {
            attack = RandomGenerator.global.GetIntRange(1, MAX_ATTRIBUTE);
            defence = MAX_ATTRIBUTE - attack + 1;
        }
    }
}

public class Golem
{
    public Card Head = null;
    public Card Chest = null;
    public Card Legs = null;

    public Golem(Card head, Card chest, Card legs)
    {
        Debug.Assert(head != null && chest != null && legs != null);
        this.Head = head;
        this.Chest = chest;
        this.Legs = legs;
    }
}





