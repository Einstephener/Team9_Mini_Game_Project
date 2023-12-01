using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoubleItemScript : MonoBehaviour
{
    public int numberOfBallsToAdd = 1;
    public float newBallSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {   //부딪힌 오브젝트의 태그가 Paddle인지 확인
        if (other.CompareTag("Paddle"))
        {
            Vector3 paddlePosition = other.transform.position;

            // DoubleItem을 통해 늘어날 공의 갯수만큼 반복
            for (int i = 0; i < numberOfBallsToAdd; i++)
            {
                GameManager.I.BallAdd();
            }

            // 현재의 DoubleItem 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}