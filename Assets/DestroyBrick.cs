using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� ������ Ȯ��
        if (collision.gameObject.CompareTag("Ball"))
        {
            // ���� ����
            Destroy(gameObject);
        }
    }

}
