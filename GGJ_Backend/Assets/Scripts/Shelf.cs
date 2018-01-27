using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{
    // SIngleton Stuff
    private static Shelf inst;
    public static Shelf Instance
    {
        get { return inst; }
        private set { inst = value; }
    }
    void Awake(){Instance = this;}


    // Actual Usefull things--------------------

    public CardVisualizer Head;
    public CardVisualizer Chest;
    public CardVisualizer Legs;
    public Golem golem = null;

    public bool IsGolemReady(){return golem != null;}

    public void LoadGolem(Golem golem)
    {
        Debug.Log("golem ready");
        Debug.Assert(golem != null);
        this.golem = golem;

        Head.card = golem.Head;
        Chest.card = golem.Chest;
        Legs.card = golem.Legs;

        Head.UpdateCard();
        Chest.UpdateCard();
        Legs.UpdateCard();
    }

    public Golem PopGolem()
    {
        Head.card.part = BodyPart.None;
        Chest.card.part = BodyPart.None;
        Legs.card.part = BodyPart.None;

        Head.UpdateCard();
        Chest.UpdateCard();
        Legs.UpdateCard();

        Golem tmp = golem;
        golem = null;
        return tmp;
    }
}