using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer leftString;
    public LineRenderer rightString;


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<PlayerDrag>().setNewProjectile(leftString, rightString,GetComponent<Rigidbody2D>(), GetComponent<Transform>());
        }
    }
}
