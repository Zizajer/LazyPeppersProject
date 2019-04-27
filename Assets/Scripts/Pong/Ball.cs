using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float BallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        InitOnAIPlayerSide();
        
    }

    void InitOnPlayerSide()
    {
        rigidbody.AddForce(Vector2.left  * BallSpeed);
    }

    void InitOnAIPlayerSide()
    {
        rigidbody.AddForce(Vector2.right * BallSpeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PongPlayer")
        {
            float y = hitFactor(transform.position,
                            collision.transform.position,
                            collision.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * BallSpeed;
        }
        if(collision.tag == "AIPongPlayer")
        {
            float y = hitFactor(transform.position,
                            collision.transform.position,
                            collision.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;
            
            GetComponent<Rigidbody2D>().velocity = dir * BallSpeed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
