﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedItemScript : MonoBehaviour
{
    public float ballSpeedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            // 현재 씬에서 모든 Ball 오브젝트를 찾아옴
            Ball[] balls = FindObjectsOfType<Ball>();

            // 찾아온 모든 Ball 오브젝트의 속도를 두 배로 조절
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {
                    Debug.Log("전 속도 : " + ball.speed);
                    ball.speed *= ballSpeedMultiplier;
                    Debug.Log("바뀐 속도: " + ball.speed);
                }
            }

            // 현재의 SpeedItem 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}