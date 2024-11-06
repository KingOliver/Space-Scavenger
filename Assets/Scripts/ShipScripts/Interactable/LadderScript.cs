using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

    [SerializeField] private bool inZone = false;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float climbSpeed;


    private void FixedUpdate()
    {
        // Check Player is in ship and in ladder range
        if (Input.GetKey(KeyCode.W) && inZone)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, climbSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = true;
            playerRB = collision.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inZone = false;
        }
    }
}
