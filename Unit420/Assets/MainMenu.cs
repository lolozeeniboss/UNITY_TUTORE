using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    private string levelname = "Slingshot_tuto";
    public void PlayGame ()
    {
        fader.FadeTo(levelname);
    }

    public void LevelSelector()
    {
        fader.FadeTo("levelselector");
    }

    public void SetLevel(string s)
    {
        levelname = s;
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
