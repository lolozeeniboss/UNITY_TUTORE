using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class killZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Demo");
    }
}
