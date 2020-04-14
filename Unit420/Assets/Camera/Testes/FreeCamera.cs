using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeCamera : MonoBehaviour
{
   
    public float panSpeed = 20f;
    public bool activeFree =false;
    public Camera Camera;
     void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
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
        Camera.enabled = activeFree;
    }
    /*public void changeCamera()
    {
        if (activeFree)
        {
            activeFree = false;
            Camera.enabled = activeFree;
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text ="true";
        }
        else
        {
            activeFree = true;
            Camera.enabled = activeFree;
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text = "false";
        }
    }*/
   
}
