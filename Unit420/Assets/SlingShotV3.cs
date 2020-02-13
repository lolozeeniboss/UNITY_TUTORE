using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotV3 : MonoBehaviour
{   
    public LineRenderer leftString;
    public LineRenderer rightString;
    public Player player;
    public float stretchLimit = 1.0f;

    private Ray leftRay;
    private bool hasPlayer;

    private IEnumerator waitForSec(float sec)
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;
        yield return new WaitForSeconds(sec);
        boxCollider.enabled = true;
    }

    void Start()
    {
        StringSetup();
        SpringJoint2D spring = player.GetComponent<SpringJoint2D>();
        spring.enabled = false;
        leftRay = new Ray(rightString.transform.position, Vector3.zero);
        hasPlayer = false;
    }

    void StringSetup()
    {
        leftString.SetPosition(0, leftString.transform.position);
        rightString.SetPosition(0, rightString.transform.position);
    }

    void StringUpdate()
    {
        Vector2 projectile = player.transform.position - rightString.transform.position;
        leftRay.direction = projectile;
        Vector3 hold = leftRay.GetPoint(projectile.magnitude + player.GetComponent<CircleCollider2D>().radius);
        leftString.SetPosition(1, hold);
        rightString.SetPosition(1, hold);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            SpringJoint2D playerSpring = player.GetComponent<SpringJoint2D>();

            //Si le joueur est en mouvement et n'est pas sur un elastique, et que l'elastique n'a pas le joueur, l'elastique "attrape" le joueur
            //Debug.Log(player.isOnSlingshot());
            if (playerRB.velocity != Vector2.zero & !player.isOnSlingshot() & hasPlayer == false)
            {
                Debug.Log(name);
                Start();
                hasPlayer = true;
                player.goesOnSlingShot();

                leftString.enabled = true;
                rightString.enabled = true;

                playerRB.isKinematic = true;
                playerRB.velocity = Vector2.zero;
                playerRB.isKinematic = true;
                playerRB.freezeRotation = true;

                player.transform.rotation = transform.rotation;
                playerSpring.enabled = true;
                playerSpring.connectedBody = GetComponent<Rigidbody2D>();
                player.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayer == false)
        {
            leftString.enabled = false;
            rightString.enabled = false;
        } else
        {
            hasPlayer = (player.isOnSlingshot() & player.GetComponent<SpringJoint2D>().connectedBody.Equals(GetComponent<Rigidbody2D>()));
        }
        StringUpdate();
    }    
}
