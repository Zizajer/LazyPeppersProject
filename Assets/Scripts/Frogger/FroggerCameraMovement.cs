using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerCameraMovement : MonoBehaviour
{
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.y > 0 && transform.position.y<28)
        {
            transform.position = new Vector3(transform.position.x,Player.position.y+2,transform.position.z);
        }
    }
}
