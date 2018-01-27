using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardVisualizer : MonoBehaviour {
    public SpriteRenderer partImage, cardBg, attack, defence;
    public Card card = new Card();
    public bool cardEnabled = true;

    void Start()
    {
        UpdateCard();
    }

    public void UpdateCard()
    {
        if (cardEnabled)
        {
            bool isActive = !card.IsNull;
            SetFrontActive(isActive);
            if (isActive)
            {
                switch (card.part)
                {
                    case BodyPart.Head:
                        cardBg.sprite = CardManager.Instance.head;
                        break;
                    case BodyPart.Chest:
                        cardBg.sprite = CardManager.Instance.chest;
                        break;
                    case BodyPart.Legs:
                        if (card.speed == 0)
                            cardBg.sprite = CardManager.Instance.staticLeg;
                        else
                            cardBg.sprite = CardManager.Instance.movingLeg;
                        break;
                }
                partImage.sprite = CardManager.Instance.parts[card.graphictype];

                attack.sprite = NumberManager.Instance.card[card.attack];
                if (card.part == BodyPart.Legs)
                {
                    defence.enabled = false;
                }
                else
                {
                    defence.enabled = true;
                    defence.sprite = NumberManager.Instance.card[card.defence];
                }
            }
            else
            {
                SetFrontActive(false);
                cardBg.sprite = CardManager.Instance.emptySlot;
            }
        }
        else
        {
            SetFrontActive(false);
            cardBg.sprite = CardManager.Instance.destroyed;
            cardBg.enabled = true;
        }
    }

    private void SetFrontActive(bool active)
    {
        partImage.enabled = active;
        attack.enabled = active;
        defence.enabled = active;
        cardBg.enabled = active;
    }
}
