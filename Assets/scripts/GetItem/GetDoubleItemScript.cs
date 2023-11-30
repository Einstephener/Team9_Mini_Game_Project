using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoubleItemScript : MonoBehaviour
{
    public GameObject DoubleItem;
    public int numberOfBallsToAdd = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            PaddleController paddle = other.GetComponent<PaddleController>();
            if (paddle != null)
            {
                paddle.IncreaseBallCount(numberOfBallsToAdd);
                Destroy(DoubleItem);
            }
        }
    }
}