using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransparencyItemScript : MonoBehaviour
{
    public float transparentDuration = 3.0f;  // ������ ������ �ð�
    public float transparencyValue = 0.2f;    // �����ϰ� ���� ������ ��ġ
    private bool IsTransparent = false;
    private float initialAlpha;
    private SpriteRenderer ballSpriteRenderer;  // ���� SpriteRenderer ������Ʈ


    private void Start()
    {
        Debug.Log("���۽� ��" + IsTransparent);
    }
    private void Update()
    {
        Debug.Log("�� ������ �� " + IsTransparent);
        if (IsTransparent == true)
        {
            
            Debug.Log("IsTransparent�� true�� �ǰ�... ");
            // ������ ������ �ð��� ������ ������� ���ư���
            transparentDuration -= Time.deltaTime;
            if (transparentDuration <= 0)
            {
                Debug.Log("�ð��� �帣��...");
                if (ballSpriteRenderer != null)
                {
                    SetBallTransparency(initialAlpha);
                    transparentDuration = 3.0f;
                    IsTransparent = false;
                }
            }
        }
    }
    private void SetBallTransparency(float alpha)
    {
        Color currentColor = ballSpriteRenderer.material.color;
        ballSpriteRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))  // �е� �±� ������ ���� ����
        {
            IsTransparent = true;
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ballSpriteRenderer = ball.GetComponent<SpriteRenderer>();
                // �������� ������ ���� ���� ����
                if (ballSpriteRenderer != null)
                {                    
                    Debug.Log(IsTransparent);
                    initialAlpha = ballSpriteRenderer.material.color.a;  // �ʱ� ���� ����
                    SetBallTransparency(transparencyValue);  // ������ ���ϴ� ������ ����
                    Destroy(gameObject);
                }
            }
        }
    }
}