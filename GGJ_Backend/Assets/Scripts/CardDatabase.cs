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
        heads = new int[7];
        heads[i++] = Constants.H_FISHBOWL;
        heads[i++] = Constants.H_SNOWHEAD;
        heads[i++] = Constants.H_CAT;
        heads[i++] = Constants.H_UNITY;
        heads[i++] = Constants.H_BULB;
        heads[i++] = Constants.H_FUNNEL;
        heads[i++] = Constants.H_FISH;

        i = 0;
        chests = new int[7];
        chests[i++] = Constants.C_DONUT;
        chests[i++] = Constants.C_SNOWBODY;
        chests[i++] = Constants.C_BOX;
        chests[i++] = Constants.C_TREE;
        chests[i++] = Constants.C_MICROWAVE;
        chests[i++] = Constants.C_BARREL;
        chests[i++] = Constants.C_BAG;

        i = 0;
        staticLegs = new int[4];
        staticLegs[i++] = Constants.LS_SNOWLEG;
        staticLegs[i++] = Constants.LS_ROOT;
        staticLegs[i++] = Constants.LS_BIN;
        staticLegs[i++] = Constants.LS_COLUMN;

        i = 0;
        movingLegs = new int[3];
        movingLegs[i++] = Constants.LM_WHEEL;
        movingLegs[i++] = Constants.LM_SLIPPER;
        movingLegs[i++] = Constants.LM_HEELS;

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
