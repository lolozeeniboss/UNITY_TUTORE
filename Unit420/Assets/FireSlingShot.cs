﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlingShot : SlingShotV3
{
    private void Start()
    {
        Debug.Log("coucou");
        leftString.material.color = Color.red;
        rightString.material.color = Color.red;
        rightString.SetPosition(1, leftString.transform.position);
        leftString.enabled = false;
        disableStrings();
    }

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        player.SetOnFire(true);
        //Debug.Log("player is on fire!");
    }
}
