﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool Camera = true;
    public float panSpeed = 20f;
    public Text Button;


    // Update is called once per frame
    void Update()
    {

        executeCamera();
    }
    public void FreeCamera()
    {

        Vector3 pos = transform.position;
        float moveAmount = 100f;
        float edgeSize = 30f;
       
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x < edgeSize)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y < edgeSize)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        transform.position = pos;

        Button.text= "FollowCam";
    }
    public void followCamera()
    {
        /*Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text=("FreeCaméra");*/
        Button.text = "FreeCam";
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z); // Camera follows the player with specified offset position
    }
    public void changeCamera()
    {
        Camera = !Camera;
    }

    public void executeCamera()
    {
        if (Camera)
        {
            followCamera();
        }
        else
        {
            FreeCamera();
        }
    }
}
