using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IPShow : MonoBehaviour {

    // Use this for initialization
    void Start () {
        System.Net.IPAddress[] a =
            System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName());
        string ip = a[0].ToString();
        for(int i=1; i<a.Length; i++)
        {
            if (a[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                ip = a[i].ToString();
        }
        GetComponent<Text>().text = "IP: " + ip;
        this.enabled = false;
    }
	
}
