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

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TransparentItem"))  //닿은 아이템이 투명도 아이템일 때
        {
            // 현재 씬에서 모든 Ball 오브젝트를 찾아옴
            Ball[] balls = FindObjectsOfType<Ball>();

            // 찾아온 모든 Ball 오브젝트의 투명도를 조절
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {
                    ball.BallVisiable(3);//3초동안 투명도 지속
                }
            }

            Destroy(TransparentItem);//먹은 아이템은 파괴
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
