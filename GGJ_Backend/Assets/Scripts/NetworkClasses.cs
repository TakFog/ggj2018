using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Server : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnRequestGolem()
    {
        //Check scaffale

    }
}

[System.Serializable]
public class BodyMessage
{
    public int id;
    public int attack;
    public int defense;
}

[System.Serializable]
public class HeadMessage
{
    public int id;
    public int attack;
    public int defense;
}

[System.Serializable]
public class LegMessage
{
    public int id;
    public float speed;
}

[System.Serializable]
public class CardMessage
{
    public int success;
    public HeadMessage headMessage;
    public BodyMessage bodyMessage;
    public LegMessage legMessage;
}