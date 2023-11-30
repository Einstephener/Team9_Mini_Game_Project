using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rigidbody;

    public KeyCode Up;
    public KeyCode Down;

    private float movement;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movement = 0f;
        if(Input.GetKey(Up)) { movement += 1f; }
        if(Input.GetKey(Down)) { movement -= 1f; }
        rigidbody.velocity = new Vector2(0, movement * speed);    
    }

    public void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
