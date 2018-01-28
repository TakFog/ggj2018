using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour {

    public void loadScene(string s)
    {
        SceneManager.LoadScene(s);
    }
}
