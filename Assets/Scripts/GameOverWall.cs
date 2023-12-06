using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWall : MonoBehaviour
{
    //오브젝트를 n초뒤에 지연 삭제
    IEnumerator DelayDestroy(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time); // n초 지연

        Destroy(obj);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 충돌한 오브젝트가 공인지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(DelayDestroy(collision.gameObject, 1));//1초뒤에 공 삭제
            GameManager.I.BallDead();
        }    
    }
}
