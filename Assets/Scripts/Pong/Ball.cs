using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float InitialForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        InitOnAIPlayerSide();
        
    }

    void InitOnPlayerSide()
    {
        rigidbody.AddForce(Vector2.left * new Vector2(0 , Random.Range(0,180))  * InitialForce);
    }

    void InitOnAIPlayerSide()
    {
        rigidbody.AddForce(Vector2.right * InitialForce);
    }
}
