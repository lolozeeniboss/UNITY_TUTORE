using UnityEngine;
using System.Collections;
using System;

public class PlayerDrag : MonoBehaviour {
	
	public float stretchLimit = 1.0f;
	public LineRenderer stringLeft = null;
	public LineRenderer stringRight = null;
	
	private SpringJoint2D spring;
	private bool clicked;
	private Transform slingshot;
    private Transform player;
    private Ray mouseRay;
	private Ray leftRay;
	private float stretchSquare;
	private float radius;
	private Vector2 velocityX;
    private Rigidbody2D rb2D;
    private CircleCollider2D circleColl;
    private bool destroySpring;


    void Awake () {
		spring = GetComponent<SpringJoint2D> ();
        destroySpring = false;
        rb2D = GetComponent<Rigidbody2D>();
        slingshot = spring.connectedBody.transform;
        circleColl = GetComponent<CircleCollider2D>();
        player = GetComponent<Transform>();
    }


    void Start () {
		StringSetup ();
		mouseRay = new Ray(slingshot.position, Vector3.zero);
		leftRay = new Ray(stringRight.transform.position, Vector3.zero);
		stretchSquare = stretchLimit * stretchLimit;
		radius = circleColl.radius;
		
	}

    


    void Update () {
		if (clicked)
			Dragging ();
		
		if (!destroySpring) {
			if (!rb2D.isKinematic && velocityX.sqrMagnitude > rb2D.velocity.sqrMagnitude) {
                destroySpring = true;
                spring.enabled = false;
				rb2D.velocity = velocityX;
                rb2D.freezeRotation = false;
            }
			
			if (!clicked)
				velocityX = rb2D.velocity;
			
			StringUpdate ();
			
		}
		else {
			stringLeft.enabled = false;
			stringRight.enabled = false;
		}
	}
	
	void StringSetup () {
		stringLeft.SetPosition (0, stringLeft.transform.position);
		stringRight.SetPosition (0, stringRight.transform.position);
	}
	
	void OnMouseDown () {
        if (!destroySpring)
        {
            spring.enabled = false;
            clicked = true;
        }
	}
	
	void OnMouseUp () {
        if (!destroySpring)
        {
            spring.enabled = true;
            rb2D.isKinematic = false;
            clicked = false;
        }
	}
	
	void Dragging () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 fromSlingshot = mousePos - slingshot.position;
		
		if (fromSlingshot.sqrMagnitude > stretchSquare) {
			mouseRay.direction = fromSlingshot;
			mousePos = mouseRay.GetPoint(stretchLimit);
		}
		
		mousePos.z = 0f;
		transform.position = mousePos;
	}
	
	void StringUpdate () {
		Vector2 projectile = transform.position - stringRight.transform.position;
		leftRay.direction = projectile;
		Vector3 hold = leftRay.GetPoint(projectile.magnitude + radius);
		stringLeft.SetPosition(1, hold);
		stringRight.SetPosition(1, hold);
	}



    public void setNewProjectile(LineRenderer stringLeft, LineRenderer stringRight,Rigidbody2D RdSlingShot,Transform slingShotTransform)
    {
        rb2D.velocity = Vector2.zero;
        velocityX = Vector2.zero;
        destroySpring = false;
        spring.connectedBody = RdSlingShot;
        rb2D.isKinematic = true;
        Debug.Log(spring.connectedBody.name);
        slingshot = spring.connectedBody.transform;
        this.stringLeft = stringLeft;
        this.stringRight = stringRight;
        Start();
        StringSetup();

        stringLeft.enabled = true;
        stringRight.enabled = true;
        transform.rotation = slingShotTransform.rotation;
        rb2D.freezeRotation=true;
        transform.position = new Vector3(slingShotTransform.position.x, slingShotTransform.position.y , transform.position.z);
    }



}
