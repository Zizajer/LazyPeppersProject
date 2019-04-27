using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject[] Obstacles;
    public bool IsSpeedGrowing;
    public float CreatedObstacleSpeed;
    public float MinimumTimeToCreate;
    public float MaximumTimeToCreate;
    private float speedAddition;
    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        speedAddition = CreatedObstacleSpeed * SpeedMultiplier;
        Invoke("CreateObstacle", Random.Range(MinimumTimeToCreate, MaximumTimeToCreate));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void CreateObstacle()
    {
        if (IsSpeedGrowing)
            CreatedObstacleSpeed += speedAddition;
        GameObject CreatedObstacle = Instantiate(Obstacles[Random.Range(0,Obstacles.Length-1)], transform.position, new Quaternion(0,0,0,0));
        CreatedObstacle.GetComponent<ObstacleMovement>().MovementSpeed = CreatedObstacleSpeed;
        Invoke("CreateObstacle", Random.Range(MinimumTimeToCreate, MaximumTimeToCreate));
    }
}
