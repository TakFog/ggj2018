using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {
    public Sprite[] parts;
    public Sprite emptySlot;
    public Sprite destroyed;
    public Sprite back;

    private static CardManager inst;
    public static CardManager Instance
    {
        get { return inst; }
        private set { inst = value; }
    }
    
	// Use this for initialization
	void Awake () {
        Instance = this;
    }

}
