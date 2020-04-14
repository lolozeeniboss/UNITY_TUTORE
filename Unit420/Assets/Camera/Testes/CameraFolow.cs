using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool active = true;
    public GameObject Camera;
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); // Camera follows the player with specified offset position



    }
    /*public void changeCamera()
    {
        if (active)
        {
            active = false;
            
        }
        else
        {
            active = true;
           

        }
    }*/
}
