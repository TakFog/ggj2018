using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{
    /*
    public Sprite[] parts;
    public Sprite emptySlot;
    public Sprite destroyed;
    public Sprite back;*/


    private static Shelf inst;
    public static Shelf Instance
    {
        get { return inst; }
        private set { inst = value; }
    }

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }


    public Golem golem = null;

    public bool IsGolemReady()
    {
        return golem != null;
    }
}