using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public Player player;
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("player is on fire : " + player.IsOnFire());
        if (player.IsOnFire())
        {
            player.SetOnFire(false);
            //Debug.Log("test");
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        particle.Play();

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
