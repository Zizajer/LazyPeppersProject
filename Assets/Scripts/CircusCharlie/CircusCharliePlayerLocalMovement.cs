using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusCharliePlayerLocalMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x + MovementSpeed * Time.deltaTime, rigidbody2D.position.y));
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x - MovementSpeed * Time.deltaTime, rigidbody2D.position.y));
        if (Input.GetKeyDown(KeyCode.Space))
            rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}

