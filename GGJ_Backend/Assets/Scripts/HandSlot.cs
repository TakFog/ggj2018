using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSlot : MonoBehaviour {
    public SpriteRenderer partImage, cardBg, attack, defence;
    public GameObject frontData;
    public Card _card = new Card();
    public bool _enabled = true;

    void Start()
    {
        UpdateCard();
    }

    public Card Card
    {
        get { return _card;  }
        set
        {
            _card = value;
            UpdateCard();
        }
    }

    public void UpdateCard()
    {
        if (_enabled)
        {
            bool isActive = _card.part != BodyPart.None;
            frontData.SetActive(isActive);
            if (isActive)
            {
                switch(_card.part)
                {
                    case BodyPart.Head:
                        cardBg.sprite = CardManager.Instance.head;
                        break;
                    case BodyPart.Chest:
                        cardBg.sprite = CardManager.Instance.chest;
                        break;
                    case BodyPart.Legs:
                        if (_card.speed == 0)
                            cardBg.sprite = CardManager.Instance.staticLeg;
                        else
                            cardBg.sprite = CardManager.Instance.movingLeg;
                        break;
                }
                partImage.sprite = CardManager.Instance.parts[_card.graphictype];

                attack.sprite = NumberManager.Instance.num[_card.attack];
                if (_card.part == BodyPart.Legs)
                {
                    defence.enabled = false;
                } 
                else
                {
                    defence.enabled = true;
                    defence.sprite = NumberManager.Instance.num[_card.defence];
                }
            }
            else
            {
                frontData.SetActive(false);
                cardBg.sprite = CardManager.Instance.emptySlot;
            }
        }
        else
        {
            partImage.enabled = false;
            cardBg.sprite = CardManager.Instance.destroyed;
        }
    }

    public bool SlotEnabled
    {
        get { return _enabled;  }
        set {
            _enabled = value;
            UpdateCard();
        }
    }

    public bool IsFree
    {
        get
        {
            return _enabled && _card == null;
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        UpdateCard();
    }
}
