using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coronner : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float MovementSpeed;
    //0-noMove,1-Up,2-Down,3-Left,4-Right TO-DO change for ENUM
    public int direction;
    public float Force;
    private int lastKnownDirection;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMoving.ToString());
        if (isMoving == false)
        {
            direction = Random.Range(1, 4);
        }
    }

    private void FixedUpdate()
    {
        MoveByForce(direction);
    }

    private void MoveByForce(int direction)
    {
        if (direction == 1 && lastKnownDirection != 1)
        {
            isMoving = true;
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.up * Force);
        }
        if (direction == 2 && lastKnownDirection != 2)
        {
            isMoving = true;
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.down * Force);
        }
        if (direction == 3 && lastKnownDirection != 3)
        {
            isMoving = true;
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.left * Force);
        }
        if (direction == 4 && lastKnownDirection != 4)
        {
            isMoving = true;
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.right * Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall" || collision.collider.tag == "Coronner")
        {
            isMoving = false;
            lastKnownDirection = direction;
            Debug.Log(lastKnownDirection);
            rigidbody2D.velocity = new Vector2(0, 0);
        }
    }
    
}
