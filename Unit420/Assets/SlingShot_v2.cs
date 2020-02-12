using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot_v2 : MonoBehaviour
{
    /*
    //private LineRenderer leftString;
    //private LineRenderer rightString;
    private float stretchLimit = 1.0f;
    private SpringJoint2D spring;
    //private bool clicked;
    private Transform slingshot;
    private Rigidbody2D rb2D;
    private Ray mouseRay;
    private Ray leftRay;
    private float stretchSquare;

    void Awake()
    {
        //spring = GetComponent<SpringJoint2D>();
        rb2D = GetComponent<Rigidbody2D>();
        slingshot = spring.connectedBody.transform;
        //clicked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("test");
            setNewProjectile(collision);
        }
    }
    
    public void setNewProjectile(Collider2D collision)
    {      
        collision.gameObject.GetComponent<PlayerDrag>().setSpeed(Vector2.zero);
        Rigidbody2D playerRB = collision.gameObject.GetComponent<PlayerDrag>().getRB();
        spring.connectedBody = playerRB;
        playerRB.isKinematic = true; 
        Debug.Log(spring.connectedBody.name);
        slingshot = spring.connectedBody.transform;
        
        Start();
        StringSetup();
        

        leftString.enabled = true;
        rightString.enabled = true;
        Transform slingShotTransform = GetComponent<Transform>();
        transform.rotation = slingShotTransform.rotation;
        playerRB.freezeRotation = true; 
        transform.position = new Vector3(slingShotTransform.position.x, slingShotTransform.position.y, transform.position.z);
    }

    public void StringSetup()
    {
        leftString.SetPosition(0, leftString.transform.position);
        rightString.SetPosition(0, rightString.transform.position);
    }

    public void Start()
    {
        StringSetup();
        mouseRay = new Ray(slingshot.position, Vector3.zero);
        leftRay = new Ray(rightString.transform.position, Vector3.zero);
        stretchSquare = stretchLimit * stretchLimit;

    }

    public void StringUpdate(float radius)
    {
        Vector2 projectile = transform.position - rightString.transform.position;
        leftRay.direction = projectile;
        Vector3 hold = leftRay.GetPoint(projectile.magnitude + radius);
        leftString.SetPosition(1, hold);
        rightString.SetPosition(1, hold);
    }
    */
}
