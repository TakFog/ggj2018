using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSlot : MonoBehaviour {
    public Image partImage, cardBg;
    public int _card;
    public bool _enabled = true;

    public int Card
    {
        get { return _card;  }
        set
        {
            _card = value;
            UpdateCard();
        }
    }

    private void UpdateCard()
    {
        if (_enabled)
        {
            partImage.enabled = _card >= 0;
            if (partImage.enabled)
            {
                cardBg.sprite = CardManager.Instance.back;
                partImage.sprite = CardManager.Instance.parts[_card];
            }
            else
            {
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
        set { }
    }
    
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        UpdateCard();
    }
}
