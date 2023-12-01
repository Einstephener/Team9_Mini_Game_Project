using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWall : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 공인지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("공 떨어짐");
            Destroy(collision.gameObject);
            GameManager.I.BallDead();
        }    
    }
}
