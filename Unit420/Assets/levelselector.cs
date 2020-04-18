using UnityEngine;

public class levelselector : MonoBehaviour
{

    public SceneFader fader;

   public void Select(int levelname)
    {
        fader.FadeTo("level_"+levelname);
    }

    public void Menu()
    {
        fader.FadeTo("Menu");
    }
}
