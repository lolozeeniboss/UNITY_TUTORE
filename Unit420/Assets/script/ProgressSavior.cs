using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressSavior : MonoBehaviour
{
    string chemin = Application.streamingAssetsPath + "/lastlevel.json";
    Regex levelRegex = new Regex(@"^level_[1-9][0-9]*$");
    string Json;
    string levelname;
    Level Saved;
    // Start is called before the first frame update
    void Start()
    {
        levelname = SceneManager.GetActiveScene().name;
        Json = File.ReadAllText(chemin);
        Saved = JsonUtility.FromJson<Level>(Json);
        if (levelRegex.IsMatch(levelname)) {
            save();
        }
    }
    bool ShouldWeSave(string s)
    {
        Debug.Log(s);
        Debug.Log(Saved.name);
        return int.Parse(s.Split('_')[1]) > int.Parse(Saved.name.Split('_')[1]);
    }

    public void save()
    {
       
        if (ShouldWeSave(levelname))
        {
            Saved.name = levelname;
            Json = JsonUtility.ToJson(Saved);
            File.WriteAllText(chemin, Json);
        } else
        {
            Debug.LogWarning("saving was Useless");
        }
    }

    public string load()
    {
        return Saved.name;
    }

}

public class Level
{
    public string name;
}
