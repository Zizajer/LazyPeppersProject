using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerPlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + MovementSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - MovementSpeed, transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + MovementSpeed, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")
        {
            if (audioSource != null)
                audioSource.Play();
        }
        if (collision.tag == "Obstacle")
        {
            Debug.Log("YOU LOST ");
        }
    }
}
