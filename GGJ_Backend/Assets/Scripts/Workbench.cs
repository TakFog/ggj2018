using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour {

    public CardVisualizer Head;
    public CardVisualizer Chest;
    public CardVisualizer Legs;



    private static Workbench inst;
    public static Workbench Instance
    {
        get { return inst; }
        private set { inst = value; }
    }

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    public void SetHead(CardVisualizer head)
    {
        Head.card.Swap(head.card);
        head.UpdateCard();
        this.Head.UpdateCard();
    }
    public void SetChest(CardVisualizer chest)
    {
        Chest.card.Swap(chest.card);
        chest.UpdateCard();
        this.Chest.UpdateCard();
    }
    public void SetLegs(CardVisualizer legs)
    {
        Legs.card.Swap(legs.card);
        legs.UpdateCard();
        this.Legs.UpdateCard();
    }

    public void generateGolem()
    {
        //if one of the cards is empty
        if (Head.card.IsNull || Chest.card.IsNull || Legs.card.IsNull || Shelf.Instance.IsGolemReady())
            return;

        Golem golem = new Golem(Head.card, Chest.card, Legs.card);
        Shelf.Instance.LoadGolem(golem);

        Head.card.part = BodyPart.None;
        Chest.card.part = BodyPart.None;
        Legs.card.part = BodyPart.None;

        Debug.Log("card none");
        Head.UpdateCard();
        Chest.UpdateCard();
        Legs.UpdateCard();

        Debug.Log("Card Update");
    }
}
