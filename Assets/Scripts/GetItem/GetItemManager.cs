using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemManager : MonoBehaviour
{
    //�е� �������� ��������ϴ�
    public GameObject Ball;
    public GameObject SpeedItem;
    public GameObject DoubleItem;
    public GameObject TransparentItem;

    // ���� ������
    public int numberOfBallsToAdd = 1;
    public float newBallSpeed = 5f;

    //���� ��ȯ ������
    public float transparentDuration = 3.0f;  // ������ ������ �ð�
    public float transparencyValue = 0.2f;    // �����ϰ� ���� ������ ��ġ
    private bool IsTransparent = false;
    private SpriteRenderer ballSpriteRenderer;  // ���� SpriteRenderer ������Ʈ

    private void Update()
    {
        Ball[] balls = FindObjectsOfType<Ball>();// ��� ���� ã�� ��� ���� ���� �ǵ�����
        if (IsTransparent)
        {
            // ������ ������ �ð��� ������ ������� ���ư���
            transparentDuration -= Time.deltaTime;
            if (transparentDuration <= 0)
            {
                foreach (Ball ball in balls)
                {
                    ballSpriteRenderer = ball.GetComponent<SpriteRenderer>();
                    if (ballSpriteRenderer != null)
                    {
                        SetBallTransparent(1f);
                        transparentDuration = 3.0f;
                        IsTransparent = false;
                    }
                }
            }
        }
    }

    private void SetBallTransparent(float alpha)
    {

        Color currentColor = ballSpriteRenderer.material.color;
        ballSpriteRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TransparentItem"))  //���� �������� ���� �������� ��
        {

            Ball[] balls = FindObjectsOfType<Ball>();//��� ����
            foreach (Ball ball in balls)
            {
                IsTransparent = true;
                ballSpriteRenderer = ball.GetComponent<SpriteRenderer>();//SpriteRenderer�� ã��
                // �������� ������ ���� ���� ����
                if (ballSpriteRenderer != null)
                {
                    IsTransparent = true;
                    Debug.LogError(IsTransparent);
                    SetBallTransparent(0.2f);  // ������ ���ϴ� ��(0.2f)���� ����
                    Destroy(TransparentItem);
                }
            }
        }
        else if (other.CompareTag("SpeedItem"))//���� �������� SpeedItem�� ���
        {
            // ���� ������ ��� Ball ������Ʈ�� ã�ƿ�
            Ball[] balls = FindObjectsOfType<Ball>();

            // ã�ƿ� ��� Ball ������Ʈ�� �ӵ��� �� ��� ����
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {
                    ball.SetSpeed(2);
                }
            }
            // ������ SpeedItem ������Ʈ�� �ı�
            Destroy(SpeedItem);
        }
        else if (other.CompareTag("DoubleItem"))
        {
            // DoubleItem�� ���� �þ ���� ������ŭ �ݺ�
            for (int i = 0; i < numberOfBallsToAdd; i++)
            {
                GameManager.I.BallAdd();
            }
            // ������ DoubleItem ������Ʈ�� �ı�
            Destroy(DoubleItem);
        }
    }

}
