﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_scene : MonoBehaviour {

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
