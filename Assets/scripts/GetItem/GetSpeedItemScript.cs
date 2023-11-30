using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedItemScript : MonoBehaviour
{
    public float ballSpeedMultiplier = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {   //부딪힌 오브젝트의 태그가 Paddle인지 확인
        if (other.CompareTag("Paddle"))
        {
            // 현재 씬에서 모든 Ball 오브젝트를 찾아옴
            Ball[] balls = FindObjectsOfType<Ball>();
            
            // 찾아온 모든 Ball 오브젝트의 속도를 두 배로 조절
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {
                    Debug.Log("전 속도 : " + ball.m_speed);
                    ball.SetSpeed(2);
                    Debug.Log("바뀐 속도: " + ball.m_speed);
                }
            }

            // 현재의 SpeedItem 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}