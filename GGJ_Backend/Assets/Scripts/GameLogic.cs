﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart {Head, Chest, Legs };

public class Card
{
    public BodyPart part;
    public int attack;
    public int defence;
    public float speed;
    public int graphictype;

    public Card(BodyPart part, int attack, int defence, float speed, int graphictype)
    {
        this.part = part ;
        this.attack = attack;
        this.defence = defence;
        this.speed = speed;
        this.graphictype = graphictype;
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


