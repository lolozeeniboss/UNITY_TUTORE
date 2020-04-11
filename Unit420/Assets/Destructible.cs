using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public Player player;
    public ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("player is on fire : " + player.IsOnFire());
        if (player.IsOnFire())
        {
            player.SetOnFire(false);
            //Debug.Log("test");
            Break();
        }
    }

    private void Break()
    {
        particle.Play();
        Destroy(gameObject);
    }
}
