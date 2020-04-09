using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
   
    public float panSpeed = 20f;


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
    }
}
