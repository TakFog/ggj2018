﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public SpriteRenderer unit, dec, bottomCard, movingCard;
    public int size = 0;
    public bool canDraw = true;
    private MovingCard movingScript;
    private AudioSource audio;
    public AudioClip newCardAudio, drawAudio;

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
        movingScript = movingCard.GetComponent<MovingCard>();
        audio = GetComponent<AudioSource>();
    }

    void Start()
    {
        UpdateSize();
    }

    public void AddCard()
    {
        if (size == 99) return;
        audio.PlayOneShot(newCardAudio);
        size++;
        UpdateSize();
    }

    public bool DrawCard()
    {
        if (size == 0 || !canDraw) return false;
        canDraw = false;
        movingScript.enabled = true;
        audio.PlayOneShot(drawAudio);
        size--;
        UpdateSize();
        return true;
    }

    private void UpdateSize()
    {
        dec.sprite = NumberManager.Instance.deck[size / 10];
        unit.sprite = NumberManager.Instance.deck[size % 10];
        bottomCard.enabled = size > 0;
    }

    private void OnMouseUpAsButton()
    {
        Hand.Instance.AddCard();
    }
}
