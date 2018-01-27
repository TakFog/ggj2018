using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{
    private AudioSource audio;
    private MovingCard moving;

    // SIngleton Stuff
    private static Shelf inst;
    public static Shelf Instance
    {
        get { return inst; }
        private set { inst = value; }
    }
    void Awake(){
        audio = GetComponent<AudioSource>();
        moving = GetComponent<MovingCard>();
        Instance = this;
    }


    // Actual Usefull things--------------------

    public CardVisualizer Head;
    public CardVisualizer Chest;
    public CardVisualizer Legs;
    public Golem golem = null;

    public bool IsGolemReady(){
        return golem != null;
    }

    public bool CannotBuildGolem()
    {
        return golem != null || moving.enabled;
    }

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

    public void EmptyGolem()
    {
        Head.card.part = BodyPart.None;
        Chest.card.part = BodyPart.None;
        Legs.card.part = BodyPart.None;

        Head.UpdateCard();
        Chest.UpdateCard();
        Legs.UpdateCard();
        golem = null;
    }

    public void InternalPopGolem()
    {
        PopGolem();
    }

    public Golem PopGolem()
    {
        audio.Play();
        moving.enabled = true;

        Golem tmp = golem;
        return tmp;
    }
}