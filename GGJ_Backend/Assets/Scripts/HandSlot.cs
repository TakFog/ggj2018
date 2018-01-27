using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSlot : MonoBehaviour {
    public GameObject cardPrefab;
    private CardVisualizer cardVis;

    void Awake()
    {
        GameObject cardObj = Instantiate(cardPrefab, transform);
        cardVis = cardObj.GetComponent<CardVisualizer>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;
    }

    public bool SlotEnabled
    {
        get { return cardVis.cardEnabled;  }
        set {
            cardVis.cardEnabled = value;
            UpdateCard();
        }
    }

    public Card Card
    {
        get { return cardVis.card; }
    }

    public void UpdateCard()
    {
        cardVis.UpdateCard();
    }

    public bool IsFree
    {
        get
        {
            return cardVis.cardEnabled && cardVis.card.IsNull;
        }
    }
    
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseUpAsButton()
    {
        Card card = cardVis.card;
        if (card.IsNull || !cardVis.cardEnabled) return;
        switch(card.part)
        {
            case BodyPart.Head:
                Workbench.Instance.SetHead(cardVis);
                break;
            case BodyPart.Chest:
                Workbench.Instance.SetChest(cardVis);
                break;
            case BodyPart.Legs:
                Workbench.Instance.SetLegs(cardVis);
                break;
        }
    }
}
