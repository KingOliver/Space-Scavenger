using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallthroughPlatformCheck : MonoBehaviour
{
    public GameObject currentOneWayPlatform, currentOneWayStairs, playerObject;
    private float gravityScale;

    [SerializeField] private CapsuleCollider2D playerCollider;

    private void Start()
    {
        gravityScale = playerObject.GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("'S' Pressed");
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisablePlatformCollision());
            } else if (currentOneWayStairs != null)
            {
                StartCoroutine(DisableStairsCollision());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Stairs"))
        {
            currentOneWayStairs = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            currentOneWayPlatform = null;
        }
        if (collision.gameObject.CompareTag("Stairs"))
        {
            currentOneWayStairs = null;
        }
    }

    private IEnumerator DisablePlatformCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Debug.Log("Platform - collide disable");
        yield return new WaitForSeconds((0.25f / gravityScale));
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Debug.Log("Platform - collide enable");
    }

    private IEnumerator DisableStairsCollision()
    {
        EdgeCollider2D platformCollider = currentOneWayStairs.GetComponent<EdgeCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        Debug.Log("Stairs - collide disable");
        yield return new WaitForSeconds((0.25f / gravityScale));
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        Debug.Log("Stairs - collide enable");
    }
}
