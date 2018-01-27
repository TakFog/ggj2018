using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public int size = 0;

    private static Deck inst;
    public static Deck Instance
    {
        get { return inst; }
        private set { inst = value; }
    }

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }

    public void AddCard()
    {
        size++;
        //TODO aggiorna gui
        Hand.Instance.AddCard();
    }

    public bool DrawCard()
    {
        if (size == 0) return false;
        size--;
        return true;
    }
}
