using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float m_speed;
    public Rigidbody2D m_rigidBody;

    public KeyCode Left;
    public KeyCode Right;

    private float movement;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = 0f;
        if (Input.GetKey(Left)) { movement -= 1f; }
        if (Input.GetKey(Right)) { movement += 1f; }
        m_rigidBody.velocity = new Vector2(movement * m_speed, 0);
    }
}
