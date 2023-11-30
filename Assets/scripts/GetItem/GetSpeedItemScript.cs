using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedItemScript : MonoBehaviour
{
    public GameObject SpeedItem;

    public float ballSpeedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            PaddleController paddle = other.GetComponent<PaddleController>();
            if (paddle != null)
            {
                paddle.IncreaseBallSpeed(ballSpeedMultiplier);
                Destroy(SpeedItem);
            }
        }
    }
}
