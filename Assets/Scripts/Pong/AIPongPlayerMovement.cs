using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPongPlayerMovement : MonoBehaviour
{
    public GameObject Ball;
    [Range(0, 1)]
    public float Skill;
    public float TimeToLost;
    public float timeChecked;

    // Start is called before the first frame update
    void Start()
    {
        timeChecked = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timeChecked += Time.deltaTime;
        if (timeChecked < TimeToLost)
        {
            Vector2 newPosition = transform.position;
            newPosition.y = Mathf.Lerp(transform.position.y, Ball.transform.position.y, Skill);
            transform.position = newPosition;
        }
    }
    
}
