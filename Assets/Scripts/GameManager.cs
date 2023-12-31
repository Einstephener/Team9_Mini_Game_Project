using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Ball")]
    public GameObject m_ball;
    public int ball_Damage;

    [Header("Paddle")]
    public Paddle m_playerPaddle;
    public GameObject Player1Paddle;
    public GameObject Player2Paddle;


    [Header("LimitTime")]
    public float limitTime_stage;

    [Header("Life")]
    public int playerLife;
    public int totalBrick;
    public int destroyBrickNum;

    [Header("Passive")]
    public GameObject getPassivePanel;
    public Button PassiveBtn1;
    public Button PassiveBtn2;
    public Button PassiveBtn3;
    public Text passiveText1;
    public Text passiveText2;
    public Text passiveText3;
    public int lv1 = 0;
    public int lv2 = 0;
    public int lv3 = 0;
    //게임 시작 버튼에 초기화 필요

    public int Stage = 0;

    [Header("Boss")]
    public GameObject boss01;
    public float bossHP;
    public float bossDropItemPercent;

    [Header("GameState")]
    public bool oneLifeLose;

    public int gameLevel = 1;
    public int gamePlayer = 1;
    public int ballCount;

    private void Awake() //싱글톤
    {        
        I = this;   
    }

    private void Start() 
    {
        if (PlayerPrefs.HasKey("Stage"))
        {
            Stage = PlayerPrefs.GetInt("Stage");
        }
        CreatBall();
        SetBallSpeed();
    }

    private void SetBallSpeed()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        if (PlayerPrefs.HasKey("PassiveBallSpeed"))
        {
            foreach (Ball ball in balls)
            {
                if (ball != null)
                {   //레벨 업 하면 볼들의 스피드 5씩 증가.
                    ball.m_speed += (5 * PlayerPrefs.GetInt("PassiveBallSpeed")); 
                }
            }
        }
    }

    public void CreatBall() //시작 시 패시브 레벨+1만큼 볼 생성.
    {
        if(PlayerPrefs.HasKey("PassiveBall"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("PassiveBall") + 1; i++)
            {
                BallAdd();
            }
        }
        else
        {
            BallAdd();
        }
    }

    public void BallAdd() 
    {
        ballCount++;
        Instantiate(m_ball);
    }

    public void BallDead()
    {
        //라이프 포인트 -1
        ballCount--;
        if(ballCount < 1)
        {
            ResetLife();
        }
    }

    public void ResetLife()
    {
        oneLifeLose = true;
    }

    public void IsLevelOver()
    {
        Debug.Log("게임 매니저까지는 옴");
        if (destroyBrickNum == 10) // 아이템 획득 기준점을 10개로 잡음. 수정가능.
        {
            Debug.Log("아이템 획득");

            destroyBrickNum -= 10;
        }
    }
}
