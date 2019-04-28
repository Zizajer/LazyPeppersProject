using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float BallSpeed;
    public AudioClip dada;
    public AudioClip mama;
    private AudioSource audio;
    private float speedAddition;

    // Start is called before the first frame update
    void Start()
    {
        speedAddition = BallSpeed * 0.1f;
        rigidbody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        InitOnAIPlayerSide();
        
    }

    void InitOnPlayerSide()
    {
        rigidbody.AddForce(Vector2.left  * BallSpeed);
    }

    void InitOnAIPlayerSide()
    {
        rigidbody.AddForce(new Vector2(1,Random.Range(-1,1)) * 0.02f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PongPlayer")
        {
            float y = hitFactor(transform.position,
                            collision.transform.position,
                            collision.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * BallSpeed;
            audio.PlayOneShot(dada);
            BallSpeed += speedAddition;
        }
        if(collision.tag == "AIPongPlayer")
        {
            float y = hitFactor(transform.position,
                            collision.transform.position,
                            collision.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            
            GetComponent<Rigidbody2D>().velocity = dir * BallSpeed;
            audio.PlayOneShot(mama);
            BallSpeed += speedAddition;
        }
        if(collision.tag == "PlayerGoal")
        {
            SceneManager.LoadScene("GameOverScene2");
        }
        if (collision.tag == "AIPlayerGoal")
        {
            SceneManager.LoadScene("VideoScene3");
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
