using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusCharliePlayerLocalMovement : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private Rigidbody2D rigidbody2D;
    private bool isGround;
    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isGround = true;
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            rigidbody2D.AddForce(Vector2.right * MoveForce);
        if (Input.GetKey(KeyCode.LeftArrow))
            rigidbody2D.AddForce(Vector2.left * MoveForce);
        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}

