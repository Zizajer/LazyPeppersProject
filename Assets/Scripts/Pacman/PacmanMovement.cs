using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PacmanMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float MovementSpeed;
    //0-noMove,1-Up,2-Down,3-Left,4-Right TO-DO change for ENUM
    public int direction;
    public float Force;
    private int lastKnownDirection;
    private AudioSource audio;
    public AudioClip WinAudioClip;
    public AudioClip LoseAudioClip;
    public Text winText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SceneNameToLoad", SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        audio = GetComponent<AudioSource>();
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
            winText.gameObject.SetActive(true);
            StartCoroutine(playSoundThenLoad(WinAudioClip, "VideoScene5"));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coronner")
        {
            StartCoroutine(playSoundThenLoad(LoseAudioClip, "GameOverScene4"));
        }
    }

    private IEnumerator playSoundThenLoad(AudioClip clipToPlay, string sceneNameToLoad)
    {
        Time.timeScale = 0;
        audio.PlayOneShot(clipToPlay);
        yield return new WaitForSecondsRealtime(clipToPlay.length);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
