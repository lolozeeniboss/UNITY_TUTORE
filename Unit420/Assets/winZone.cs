﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winZone : MonoBehaviour
{
    public GameObject uiObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        uiObject.active = true;
        Time.timeScale = 0.3f;
    }
}
