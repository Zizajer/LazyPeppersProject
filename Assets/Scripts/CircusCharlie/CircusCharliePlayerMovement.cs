using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusCharliePlayerMovement : MonoBehaviour
{
    public float MovementSpeed;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + MovementSpeed * Time.deltaTime, 0, -10);
    }
}

