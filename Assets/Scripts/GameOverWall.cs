using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWall : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� ������ Ȯ��
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("�� ������");
            GameManager.I.BallDead();
        }    
    }
}
