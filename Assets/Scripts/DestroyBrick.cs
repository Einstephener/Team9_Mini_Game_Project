using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 공인지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 벽돌 제거
            Destroy(gameObject);
        }
    }
}
