using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public float MovementSpeed;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource!=null)
            audioSource.Play();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + MovementSpeed * Time.fixedDeltaTime, transform.position.y);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
