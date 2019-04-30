using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FroggerPlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    private AudioSource audioSource;
    public AudioClip WinAudioClip;
    public AudioClip LoseAudioClip;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SceneNameToLoad", SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
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
            winText.gameObject.SetActive(true);
            StartCoroutine(playSoundThenLoad(WinAudioClip, "VideoScene4"));
        }
        if (collision.tag == "Obstacle")
        {
            StartCoroutine(playSoundThenLoad(LoseAudioClip, "GameOverScene3"));
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
