using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHop : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float hopForce;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, hopForce);
        }
    }
}
