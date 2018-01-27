using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour {

    Card Head = new Card();
    Card Chest = new Card();
    Card Legs = new Card();

    public void SetHead(Card head)  {Head.Swap(head);}
    public void SetChest(Card chest){Chest.Swap(chest);}
    public void SetLegs(Card legs)  {Legs.Swap(legs);}

    public void generateGolem()
    {
        //if one of the cards is empty
        if (Head.IsNull || Chest.IsNull || Legs.IsNull || Shelf.Instance.IsGolemReady())
            return;

        Golem golem = new Golem(Head, Chest, Legs);
        Shelf.Instance.LoadGolem(golem);

        Head.part = BodyPart.None;
        Chest.part = BodyPart.None;
        Legs.part = BodyPart.None;
    }
}
