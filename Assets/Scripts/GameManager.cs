using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Ball")]
    public Ball m_ball;

    [Header("Paddle")]
    public Paddle m_playerPaddle;

    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

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
    public void BallDead()
    {
        //¸ñ¼û -1
        ResetPosition();
    }
    private void ResetPosition()
    {
        m_ball.Reset();
        //m_playerPaddle.Reset();
    }
}
