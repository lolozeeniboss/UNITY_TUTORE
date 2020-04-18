using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winMenu : MonoBehaviour
{
    public SceneFader fader;

    public GameObject winMenuUI;
    public GameObject pauseButtonUI;

    // Start is called before the first frame update
    void Start()
    {
        winMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Callwin()
    {
        Debug.Log("win");
        pauseButtonUI.SetActive(false);
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Menu()
    {
        Debug.Log("retour au menu");
        Time.timeScale = 1f; //enleve la pause du jeu si on reviens au menu pour ne pas avoir un menu freeser
        fader.FadeTo("Menu");
    }

    public void NextGame()
    {
        string[] s = SceneManager.GetActiveScene().name.Split('_');
        try
        {
            fader.FadeTo(s[0] + (int.Parse(s[1]) + 1));
        }
        catch (Exception e)
        {
            fader.FadeTo("Menu");
        }
    }

    public void restart()
    {
        Time.timeScale = 1f;
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
