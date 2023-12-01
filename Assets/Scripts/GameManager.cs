using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Ball")]
    public GameObject m_ball;

    [Header("Paddle")]
    public GameObject m_playerPaddle;

    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    [Header("LimitTime")]
    public float limitTime_stage;

    [Header("Life")]
    public int playerLife;

    [Header("GameState")]
    public bool oneLifeLose;

    public int ballCount;
    private void Awake()
    {
        if (I != null) 
        {
            Destroy(gameObject);
            return;
        }
        I = this; 
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        BallAdd();
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
}
