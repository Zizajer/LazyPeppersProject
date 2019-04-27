using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusCharliePlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - MovementSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + MovementSpeed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}

