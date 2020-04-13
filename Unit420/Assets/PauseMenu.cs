using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;


    public GameObject pauseMenuUI;
    public GameObject pauseButtonUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            
    }


     public void CallPause()
    {
        Pause();
    }

    void Pause()
    {
        Debug.Log("pause");
        pauseButtonUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Debug.Log("reprendre");
        pauseButtonUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Menu()
    {
        Debug.Log("retour au menu");
        Time.timeScale = 1f; //enleve la pause du jeu si on reviens au menu pour ne pas avoir un menu freeser
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quitter");
        Application.Quit();
    }

}
