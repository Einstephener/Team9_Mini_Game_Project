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
        Instantiate(m_ball);
    }

    public void BallDead()
    {
        //��� -1
        ResetPosition();
    }

    private void ResetPosition()
    {
        //m_ball.Reset();
        //m_playerPaddle.Reset();
    }
}
