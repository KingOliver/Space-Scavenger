using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallThroughPlatform : MonoBehaviour
{
    //change to private
    public GameObject currentOneWayPlatform, currentOneWayStairs;
    private float gravityScale;

    [SerializeField] private GameObject shipPlatform;
    [SerializeField] private CapsuleCollider2D playerCollider;

    private void Start()
    {
        gravityScale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("'S' Pressed");
            if (currentOneWayPlatform != null)
            {
                //Debug.Log("Detected");
                if (currentOneWayPlatform.CompareTag("Platform"))
                {
                    //Debug.Log("Platform");
                    StartCoroutine(DisablePlatformCollision());
                }
                
            }

            /*if (currentOneWayStairs != null)
            {
                if (currentOneWayStairs.CompareTag("Stairs"))
                {
                    //Debug.Log("Stairs");
                    StartCoroutine(DisableStairsCollision());
                }
            }*/
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject);
        //Collider2D myCollider = collision.GetContact(0).thisCollider;
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
       /* if (collision.gameObject.CompareTag("Stairs"))
        {
            currentOneWayStairs = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("PlayerShip"))
        {
            currentOneWayPlatform = shipPlatform;
        }*/

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = null;
        }
        /*if (collision.gameObject.CompareTag("Stairs"))
        {
            currentOneWayStairs = null;
        }*/
    }

    private IEnumerator DisablePlatformCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Debug.Log("Platform - collide disable");
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Debug.Log("Platform - collide enable");
    }

    private IEnumerator DisableStairsCollision()
    {
        EdgeCollider2D platformCollider = currentOneWayStairs.GetComponent<EdgeCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Debug.Log("Stairs - collide disable");
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Debug.Log("Stairs - collide enable");
    }
}
