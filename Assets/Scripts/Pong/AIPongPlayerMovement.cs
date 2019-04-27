using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPongPlayerMovement : MonoBehaviour
{
    public GameObject Ball;
    [Range(0, 1)]
    public float Skill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.y = Mathf.Lerp(transform.position.y, Ball.transform.position.y, Skill);
        transform.position = newPosition;
    }

    void FixedUpdate()
    {
        
    }
}
