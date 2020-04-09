using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpringJoint2D spring;
    private bool clicked;
    private float distance = 1;
    private bool onSlingShot;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        clicked = false;
        onSlingShot = false;
        rb2d = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onSlingShot & rb2d.isKinematic == false)
        {
            //Debug.Log("Speed: " + rb2d.velocity.sqrMagnitude);
            if (speed <= rb2d.velocity.sqrMagnitude)
            {
                speed = rb2d.velocity.sqrMagnitude;
            } else
            {
                rb2d.freezeRotation = false;
                spring.enabled = false;
                onSlingShot = false;
                speed = 0;
            }
            
        }
        if (rb2d.isKinematic == false)
        {
            //Debug.Log(rb2d.velocity);
        }
    }

    void OnMouseDown()
    {
        clicked = true;
        if (onSlingShot)
        {
            spring.enabled = false;
        }
    }

    void OnMouseUp()
    {
        clicked = false;
        if (onSlingShot)
        {
            rb2d.isKinematic = false;
            spring.enabled = true;
        }
    }

    public bool IsClicked()
    {
        return clicked;
    }

    void OnMouseDrag()
    {
        if (onSlingShot) 
        {
            float stretchLimit = 4.0f;
            float stretchSquare = stretchLimit * stretchLimit;
            Rigidbody2D slingshot = spring.connectedBody;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            
            Vector2 fromSlingshot = objPosition - slingshot.transform.position;

            if (fromSlingshot.sqrMagnitude > stretchSquare)
            {
                //Debug.Log("outside of the stretchSquare");
                Ray mouseRay = new Ray(slingshot.position, Vector3.zero);
                mouseRay.direction = fromSlingshot;
                objPosition = mouseRay.GetPoint(stretchLimit);
            }
            transform.position = objPosition;
        }
    }

    public bool isOnSlingshot()
    {
        return onSlingShot;
    }

    public void goesOnSlingShot()
    {
        onSlingShot = true;
    }
}
