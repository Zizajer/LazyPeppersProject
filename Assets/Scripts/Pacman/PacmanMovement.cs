using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float MovementSpeed;
    

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
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(0,MovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(0,-MovementSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(-MovementSpeed * Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.MovePosition(rigidbody2D.position += new Vector2(MovementSpeed * Time.deltaTime,0));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ChangePoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
