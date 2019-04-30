using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float BallSpeed;
    public AudioClip[] dada;
    public AudioClip[] mama;
    public AudioClip WinAudioClip;
    public AudioClip LoseAudioClip;
    private AudioSource audio;
    private float speedAddition;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SceneNameToLoad",SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
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
            audio.PlayOneShot(dada[Random.Range(0,dada.Length-1)]);
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
            audio.PlayOneShot(mama[Random.Range(0, dada.Length - 1)]);
            BallSpeed += speedAddition;
        }
        if(collision.tag == "PlayerGoal")
        {
            StartCoroutine(playSoundThenLoad(LoseAudioClip, "GameOverScene2"));
        }
        if (collision.tag == "AIPlayerGoal")
        {
            winText.gameObject.SetActive(true);
            StartCoroutine(playSoundThenLoad(WinAudioClip, "VideoScene3"));
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private IEnumerator playSoundThenLoad(AudioClip clipToPlay, string sceneNameToLoad)
    {
        Time.timeScale = 0;
        audio.PlayOneShot(clipToPlay);
        yield return new WaitForSecondsRealtime(clipToPlay.length);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
