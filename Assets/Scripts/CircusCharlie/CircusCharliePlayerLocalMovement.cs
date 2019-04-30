using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircusCharliePlayerLocalMovement : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private Rigidbody2D rigidbody2D;
    private bool canJump;
    private AudioSource audioSource;
    public AudioClip WinAudioClip;
    public AudioClip LoseAudioClip;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SceneNameToLoad", SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            canJump = false;
            rigidbody2D.AddForce(Vector2.up * JumpForce);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ring")
        {
            StartCoroutine(playSoundThenLoad(LoseAudioClip, "GameOverScene1"));
        }
        if (collision.tag == "EndLine")
        {
            winText.gameObject.SetActive(true);
            StartCoroutine(playSoundThenLoad(WinAudioClip, "VideoScene2"));
        }
    }

    private IEnumerator playSoundThenLoad(AudioClip clipToPlay, string sceneNameToLoad)
    {
        Time.timeScale = 0;
        audioSource.PlayOneShot(clipToPlay);
        yield return new WaitForSecondsRealtime(clipToPlay.length);
        SceneManager.LoadScene(sceneNameToLoad);
    }
}

