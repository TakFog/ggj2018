using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkClasses : MonoBehaviour {
    const int CARD_RECEIVE  = 1000;
    const int REQ_RECEIVE   = 1001;
    const int REQ_RESPONSE  = 1001;
    const int DEM_RECEIVE   = 1002;
    const int PORT          = 3000;

    void Start()
    {
        NetworkServer.RegisterHandler(CARD_RECEIVE, OnCardReceived);
        NetworkServer.RegisterHandler(REQ_RECEIVE, OnRequestGolem);
        NetworkServer.RegisterHandler(DEM_RECEIVE, OnDamageReceived);
        NetworkServer.Listen(PORT);

       /* NetworkClient client = new NetworkClient();
        client.RegisterHandler(MsgType.Connect, OnConnected);
        client.Connect("localhost", 3000);*/
    }

    
    /*private void OnConnected(NetworkMessage netMsg)
    {
        netMsg.conn.Send(REQ_RECEIVE, new EmptyMessage());
    }*/

    void OnRequestGolem(NetworkMessage netMsg)
    {
        Debug.Log("Golem Request Received");

        if (Shelf.Instance.IsGolemReady())
        {
            Golem g = Shelf.Instance.PopGolem();
            string msg = JsonUtility.ToJson(new CardMessage(g));
            netMsg.conn.Send(REQ_RESPONSE, new StringMessage(msg));
        }
    }

    void OnDamageReceived(NetworkMessage netMsg)
    {
        Debug.Log("Damage Received");
        Hand.Instance.Damage();
    }

    void OnCardReceived(NetworkMessage netMsg)
    {
        Debug.Log("Card Received");
        Deck.Instance.AddCard();
    }
}


[System.Serializable]
public class BodyMessage
{
    public int id;
    public int attack;
    public int defense;

    public BodyMessage(Card chest)
    {
        attack = chest.attack;
        defense = chest.defence;
    }
}

[System.Serializable]
public class HeadMessage
{
    public int id;
    public int attack;
    public int defense;

    public HeadMessage(Card head)
    {
        attack = head.attack;
        defense = head.defence;
    }
}

[System.Serializable]
public class LegMessage
{
    public int id;
    public int attack;
    public float speed;

    public LegMessage(Card legs)
    {
        attack = legs.attack;
        speed = legs.speed;
    }
}

[System.Serializable]
public class CardMessage
{
    public int success;
    public HeadMessage headMessage;
    public BodyMessage bodyMessage;
    public LegMessage legMessage;

    public CardMessage(Golem g)
    {
        success = 1;
        headMessage = new HeadMessage(g.Head);
        bodyMessage = new BodyMessage(g.Chest);
        legMessage = new LegMessage(g.Legs);
    }

    public CardMessage()
    {
        success = 0;
        headMessage = null;
        bodyMessage = null;
        legMessage = null;
    }
}
