using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public GameObject Obstacle;
    public float CreatedObstacleSpeed;
    public float MinimumTimeToCreate;
    public float MaximumTimeToCreate;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateObstacle", Random.Range(MinimumTimeToCreate, MaximumTimeToCreate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateObstacle()
    {
        GameObject CreatedObstacle = Instantiate(Obstacle, transform.position, new Quaternion(0,0,0,0));
        CreatedObstacle.GetComponent<ObstacleMovement>().MovementSpeed = CreatedObstacleSpeed;
        Invoke("CreateObstacle", Random.Range(MinimumTimeToCreate, MaximumTimeToCreate));
    }
}
