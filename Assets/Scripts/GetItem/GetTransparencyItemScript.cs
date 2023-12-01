using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransparencyItemScript : MonoBehaviour
{
    public float transparentDuration = 3.0f;  // 투명도를 유지할 시간
    public float transparencyValue = 0.2f;    // 설정하고 싶은 투명도의 수치
    private bool IsTransparent = false;
    private float initialAlpha;
    private SpriteRenderer ballSpriteRenderer;  // 공의 SpriteRenderer 컴포넌트


    private void Start()
    {
        Debug.Log("시작시 값" + IsTransparent);
    }
    private void Update()
    {
        Debug.Log("매 프레임 값 " + IsTransparent);
        if (IsTransparent == true)
        {
            
            Debug.Log("IsTransparent가 true가 되고... ");
            // 투명도가 설정된 시간이 지나면 원래대로 돌아가기
            transparentDuration -= Time.deltaTime;
            if (transparentDuration <= 0)
            {
                Debug.Log("시간이 흐르고...");
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
        if (other.CompareTag("Paddle"))  // 패들 태그 설정에 따라 변경
        {
            IsTransparent = true;
            Ball[] balls = FindObjectsOfType<Ball>();
            foreach (Ball ball in balls)
            {
                ballSpriteRenderer = ball.GetComponent<SpriteRenderer>();
                // 아이템을 먹으면 공의 투명도 조절
                if (ballSpriteRenderer != null)
                {                    
                    Debug.Log(IsTransparent);
                    initialAlpha = ballSpriteRenderer.material.color.a;  // 초기 투명도 저장
                    SetBallTransparency(transparencyValue);  // 투명도를 원하는 값으로 조절
                    Destroy(gameObject);
                }
            }
        }
    }
}