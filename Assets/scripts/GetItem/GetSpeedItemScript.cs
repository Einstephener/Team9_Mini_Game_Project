using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedItemScript : MonoBehaviour
{
    public GameObject SpeedItem;
    public GameObject Ball;


    public float BallSpeedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ball"))
        {
            // 공의 스크립트를 가져옴
            /*공의 스크립트 명*/ ball = collider.GetComponent</*공의 스크립트 명*/>();

            if (ball != null)
            {
                // 공의 속도를 2배로 늘림
                ball.IncreaseSpeed(BallSpeedMultiplier);

                // 아이템을 먹은 후 아이템을 파괴
                Destroy(gameObject);
            }
        }
    }

}
