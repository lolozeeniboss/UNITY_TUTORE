using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public ProgressSavior levelname;
    public SceneFader fader;
    public void PlayGame ()
    {
        fader.FadeTo(levelname.load());
    }

    public void LevelSelector()
    {
        fader.FadeTo("levelselector");
    }


    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
