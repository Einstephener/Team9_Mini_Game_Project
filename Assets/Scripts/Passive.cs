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

        foreach (Ball ball in balls)
        {
            if (ball != null)
            {
                ball.m_speed += 5; //레벨 업 하면 볼들의 스피드 5씩 증가.
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