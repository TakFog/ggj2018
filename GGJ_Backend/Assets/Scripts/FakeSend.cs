using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSend : MonoBehaviour {
    public float pause;
    private float cooldown;
    private bool sent = false;

	// Use this for initialization
	void Start () {
        cooldown = pause;
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            if (Shelf.Instance.IsGolemReady())
            {
                sent = true;
                Shelf.Instance.InternalPopGolem();
            }
            cooldown = pause;

        }
        if (sent && ChanibaL.RandomGenerator.global.ChanceForPeriod(2f))
            Deck.Instance.AddCard();
#endif
    }
}
