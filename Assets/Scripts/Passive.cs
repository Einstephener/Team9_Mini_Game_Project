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

        // ã�ƿ� ��� Ball ������Ʈ�� �ӵ��� �� ��� ����
        foreach (Ball ball in balls)
        {
            if (ball != null)
            {
                Debug.Log("�� �ӵ� : " + ball.m_speed);
                ball.SetSpeed(2);
                Debug.Log("�ٲ� �ӵ�: " + ball.m_speed);
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
        //���� ���� ������� �޼���
        GameManager.I.getPassivePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}