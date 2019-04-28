using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusCharliePlayerLocalMovement : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private Rigidbody2D rigidbody2D;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            canJump = false;
            rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ring")
        {
            Debug.Log("YOU LOST ");
        }
    }
}

