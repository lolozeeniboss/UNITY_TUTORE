﻿using UnityEngine;

public class levelselector : MonoBehaviour
{

    public SceneFader fader;

   public void Select(string levelname)
    {
        fader.FadeTo(levelname);
    }

    public void Menu()
    {
        fader.FadeTo("Menu");
    }
}
