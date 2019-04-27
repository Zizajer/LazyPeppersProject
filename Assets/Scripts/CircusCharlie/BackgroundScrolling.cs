using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float MovementSpeed;
    private float speedAddition;
    public float speedMultiplier;
    private float timer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        speedAddition = MovementSpeed * speedMultiplier;
    }

    private void Update()
    {
        if(timer < 0)
        {
            MovementSpeed += speedAddition;
            timer = 3f;
        }
        timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + MovementSpeed * Time.fixedDeltaTime, transform.position.y);
    }
}
