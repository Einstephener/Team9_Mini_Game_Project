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
        PlayerPrefs.SetInt("PassiveBall", num);
        PlayerPrefs.Save();
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BallSpeedUp()
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

    public void PanelSpeedUp()
    {
        int num;
        num = GameManager.I.lv3;
        Paddle paddle = new Paddle();
        paddle.m_speed += 5;
        num++;
        GameManager.I.lv3 = num;
        PlayerPrefs.SetInt("PassivePanelSpeed", num); //판넬 스피드 저장.
        PlayerPrefs.Save();
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}