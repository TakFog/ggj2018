using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shelf : MonoBehaviour
{

    // SIngleton Stuff
    private static Shelf inst;
    public static Shelf Instance
    {
        get { return inst; }
        private set { inst = value; }
    }
    void Awake(){Instance = this;}


    // Actual Usefull things--------------------

    public Golem golem = null;

    public bool IsGolemReady(){return golem != null;}

    public void LoadGolem(Golem golem)
    {
        Debug.Log("golem ready");
        Debug.Assert(golem != null);
        this.golem = golem;

    }

    public Golem PopGolem()
    {
        Golem tmp = golem;
        golem = null;
        return tmp;
    }
}