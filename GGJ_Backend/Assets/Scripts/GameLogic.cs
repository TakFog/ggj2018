using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart {Head, Chest, Legs };

public class Card
{
    public const int MAX_ATTRIBUTE = 10;

    public BodyPart part;
    public int attack;
    public int defence;
    public float speed;
    public int graphictype;

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
            attack = Random.Range(0, MAX_ATTRIBUTE + 1);
            defence = MAX_ATTRIBUTE - attack;
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


