using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : MonoBehaviour
{
    public void GetAnotherBall()
    {
        int num;
        num = GameManager.I.lv1;
        GameManager.I.BallAdd();
        num++;
        GameManager.I.lv1 = num;
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void DoubleSpeed()
    {
        int num;
        num = GameManager.I.lv2;
        Ball[] balls = FindObjectsOfType<Ball>();

        // 찾아온 모든 Ball 오브젝트의 속도를 두 배로 조절
        foreach (Ball ball in balls)
        {
            if (ball != null)
            {
                Debug.Log("전 속도 : " + ball.m_speed);
                ball.SetSpeed(2);
                Debug.Log("바뀐 속도: " + ball.m_speed);
            }
        }
        num++;
        GameManager.I.lv2 = num;
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LongPanel()
    {
        int num;
        num = GameManager.I.lv3;
        num++;
        GameManager.I.lv3 = num;
        //발판 길이 길어지는 메서드
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}