﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Demo");
    }
}
