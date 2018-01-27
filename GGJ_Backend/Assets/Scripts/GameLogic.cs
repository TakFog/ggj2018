using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool IsNull
    {
        get { return part == BodyPart.None; }
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
            attack = Random.Range(1, MAX_ATTRIBUTE+1);
            defence = MAX_ATTRIBUTE - attack + 1;
        }
    }
}

public class Golem
{
    public Card Head;
    public Card Chest;
    public Card Legs;

    public Golem(Card head, Card chest, Card legs)
    {
        Debug.Assert(Head != null && Chest != null && Legs != null);
        this.Head = head;
        this.Chest = chest;
        this.Legs = legs;
    }
}


public class Workbench
{
    Card Head = null;
    Card Chest = null;
    Card Legs = null;

    public void generateGolem()
    {
        //if one of the cards is empty
        if (Head == null || Chest == null || Legs == null)
            return;    

        Golem golem = new Golem(Head,Chest,Legs);
        /*if (!Scaffale.full())
            Scaffale.load(golem)
         */
        Head = null;
        Chest = null;
        Legs = null;
    }
}


