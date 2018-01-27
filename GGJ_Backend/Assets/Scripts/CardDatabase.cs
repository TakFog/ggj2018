using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase {
    public int[] heads;
    public int[] chests;
    public int[] staticLegs;
    public int[] movingLegs;

    private static CardDatabase inst = null;
    public static CardDatabase Instance
    {
        get
        {
            if (inst == null)
                inst = new CardDatabase();
            return inst;
        }
    }

    public CardDatabase()
    {

        int i = 0;
        heads = new int[2];
        heads[i++] = 0;
        heads[i++] = 1;

        i = 0;
        chests = new int[2];
        chests[i++] = 2;
        chests[i++] = 3;

        i = 0;
        staticLegs = new int[2];
        staticLegs[i++] = 4;
        staticLegs[i++] = 5;

        i = 0;
        movingLegs = new int[2];
        movingLegs[i++] = 4;
        movingLegs[i++] = 5;
    }

    public void RandomGraphic(Card card)
    {
        int[] pool = null;
        switch(card.part)
        {
            case BodyPart.Head:
                pool = heads;
                break;
            case BodyPart.Chest:
                pool = chests;
                break;
            case BodyPart.Legs:
                if (Random.Range(0, 100) > 50)
                {
                    pool = staticLegs;
                    card.speed = 0f;
                }
                else
                {
                    pool = movingLegs;
                    card.speed = 1f;
                }
                break;
        }
        card.graphictype = pool[Random.Range(0, pool.Length)];
    }
}
