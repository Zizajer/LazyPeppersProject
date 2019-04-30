using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChoose : MonoBehaviour
{

    public Transform NoPosition;
    public Transform YesPosition;
    private string sceneNameToLoad;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sceneNameToLoad = PlayerPrefs.GetString("SceneNameToLoad");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position == NoPosition.position)
            {
                Application.Quit();
            }
            if (transform.position == YesPosition.position)
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = YesPosition.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = NoPosition.position;
        }
    }
}
