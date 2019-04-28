using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float MovementSpeed;
    //0-noMove,1-Up,2-Down,3-Left,4-Right TO-DO change for ENUM
    public int direction;
    public float Force;
    private int lastKnownDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 3;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 4;
        }

        
    }

    private void FixedUpdate()
    {
        MoveByForce(direction);
    }
/*
    private void Move(int direction)
    {
        if (direction == 1)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(0, MovementSpeed * Time.deltaTime));
        }
        if (direction == 2)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(0, -MovementSpeed * Time.deltaTime));
        }
        if (direction == 3)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(-MovementSpeed * Time.deltaTime, 0));
        }
        if (direction == 4)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(MovementSpeed * Time.deltaTime, 0));
        }
    }*/

    private void MoveByForce(int direction)
    {
        if (direction == 1 && lastKnownDirection!=1)
        {
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.up * Force);
        }
        if (direction == 2 && lastKnownDirection != 2)
        {
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.down * Force);
        }
        if (direction == 3 && lastKnownDirection != 3)
        {
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.left * Force);
        }
        if (direction == 4 && lastKnownDirection != 4)
        {
            lastKnownDirection = direction;
            rigidbody2D.velocity = new Vector2(0, 0);
            rigidbody2D.AddForce(Vector2.right * Force);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ChangePoint")
        {
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Wall")
        {
            lastKnownDirection = direction;
            Debug.Log(lastKnownDirection);
            rigidbody2D.velocity = new Vector2(0,0);
        }
        if(collision.tag == "EndLine")
        {
            SceneManager.LoadScene("VideoScene5");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coronner")
        {
            SceneManager.LoadScene("GameOverScene4");
        }
    }
}
