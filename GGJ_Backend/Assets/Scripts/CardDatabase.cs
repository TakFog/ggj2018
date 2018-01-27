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
        heads[i++] = Constants.PART_DONUT;
        heads[i++] = Constants.PART_PENCIL;

        i = 0;
        chests = new int[2];
        chests[i++] = Constants.PART_DONUT;
        chests[i++] = Constants.PART_PENCIL;

        i = 0;
        staticLegs = new int[2];
        staticLegs[i++] = Constants.PART_DONUT;
        staticLegs[i++] = Constants.PART_PENCIL;

        i = 0;
        movingLegs = new int[2];
        movingLegs[i++] = Constants.PART_DONUT;
        movingLegs[i++] = Constants.PART_PENCIL;
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
                    card.attack = 10;
                }
                break;
        }
        card.graphictype = pool[Random.Range(0, pool.Length)];
    }
}
