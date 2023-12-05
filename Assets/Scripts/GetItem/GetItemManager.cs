using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemManager : MonoBehaviour
{
    //패들 기준으로 만들었습니다
    public GameObject[] Ball;
    public GameObject SpeedItem;
    public GameObject DoubleItem;
    public GameObject TransparentItem;

    // 갯수 아이템
    private int numberOfBallsToAdd = 1; //추가되는 공의 갯수 => 공 1개당 공 1개 추가 생성 => 공이 2배

    //투명도 전환 아이템
    private float transparentDuration = 3.0f;  // 투명도를 유지할 시간
    private bool IsTransparent = false;         // 투명화가 기본 비 활성화
    private SpriteRenderer ballSpriteRenderer;  // 공의 SpriteRenderer 컴포넌트

    private void Update()
    {
        Ball = GameObject.FindGameObjectsWithTag("Ball");// 모든 공을 찾아 모든 공의 투명도 되돌리기
        if (IsTransparent) // 투명화가 활성화가 되면 
        {
            // 투명도가 설정된 시간이 지나면 원래대로 돌아가기
            transparentDuration -= Time.deltaTime;
            if (transparentDuration <= 0) // 지속시간이 끝나면
            {
                for (int i = 0; i <= Ball.Length; i++)
                {
                    ballSpriteRenderer = Ball[i].GetComponent<SpriteRenderer>();
                    if (ballSpriteRenderer != null)
                    {
                        SetBallTransparent(1f);
                        transparentDuration = 3.0f;  //0이 된 지속시간 3초로 초기화
                        IsTransparent = false;       //다시 투명화가 비활성화 됬다고 초기화
                    }
                }
            }
        }
    }

    private void SetBallTransparent(float alpha)// 공의 투명도를 바꾸는 메서드
    {
        Debug.Log(alpha);
        Color currentColor = ballSpriteRenderer.material.color;
        ballSpriteRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TransparentItem"))  //닿은 아이템이 투명도 아이템일 때
        {

            Ball = GameObject.FindGameObjectsWithTag("Ball");//모든 공의
            for (int i = 0; i <= Ball.Length; i++)
            {
                IsTransparent = true;
                ballSpriteRenderer = Ball[i].GetComponent<SpriteRenderer>();//SpriteRenderer를 찾아
                // 아이템을 먹으면 공의 투명도 조절
                if (ballSpriteRenderer != null)
                {
                    Debug.LogError(IsTransparent);
                    SetBallTransparent(0.2f);   // 투명도를 원하는 값(0.2f)으로 조절
                    Destroy(TransparentItem);   //먹은 아이템은 파괴
                }
            }
        }
        else if (other.CompareTag("SpeedItem"))//닿은 아이템이 SpeedItem일 경우
        {
            // 현재 씬에서 모든 Ball 오브젝트를 찾아옴
            Ball[] balls = FindObjectsOfType<Ball>();

            // 찾아온 모든 Ball 오브젝트의 속도를 두 배로 조절
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {
                    ball.SetSpeed(2);
                }
            }
            // 현재의 SpeedItem 오브젝트를 파괴
            Destroy(SpeedItem);
        }
        else if (other.CompareTag("DoubleItem"))
        {
            // DoubleItem을 통해 늘어날 공의 갯수만큼 반복
            for (int i = 0; i < numberOfBallsToAdd; i++)
            {
                GameManager.I.BallAdd();
            }
            // 현재의 DoubleItem 오브젝트를 파괴
            Destroy(DoubleItem);
        }
    }
}
