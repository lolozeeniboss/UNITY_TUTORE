using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winZone : MonoBehaviour
{
    public winMenu uiObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        uiObject.Callwin();
     
    }
}
