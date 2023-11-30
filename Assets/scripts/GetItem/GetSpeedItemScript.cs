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
            // ���� ��ũ��Ʈ�� ������
            /*���� ��ũ��Ʈ ��*/ ball = collider.GetComponent</*���� ��ũ��Ʈ ��*/>();

            if (ball != null)
            {
                // ���� �ӵ��� 2��� �ø�
                ball.IncreaseSpeed(BallSpeedMultiplier);

                // �������� ���� �� �������� �ı�
                Destroy(gameObject);
            }
        }
    }

}
