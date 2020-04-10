using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlingShot : SlingShotV3
{

    public new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        player.SetOnFire(true);
        //Debug.Log("player is on fire!");
    }
}
