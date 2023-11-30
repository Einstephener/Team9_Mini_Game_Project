using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoubleItemScript : MonoBehaviour
{
    public GameObject Ball;
    public int numberOfBallsToAdd = 1;
    public float newBallSpeed = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            Vector3 paddlePosition = other.transform.position;

            // DoubleItem을 통해 늘어날 공의 갯수만큼 반복
            for (int i = 0; i < numberOfBallsToAdd; i++)
            {
                // 현재 패들 위치에서 새로운 공 생성
                GameObject newBall = Instantiate(Ball, paddlePosition, Quaternion.identity);

                // 생성된 공에 대한 초기화 작업 수행
                newBall.GetComponent<Rigidbody2D>().velocity = Vector2.up * newBallSpeed;
            }

            // 현재의 DoubleItem 오브젝트를 파괴
            Destroy(gameObject);
        }
    }
}