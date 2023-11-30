using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public Ball m_ball;

    [Header("Paddle")]
    public Paddle m_playerPaddle;

    [Header("UI")]
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    private int player1Score;
    private int player2Score;

    private void ResetPosition()
    {
        m_ball.Reset();
        //m_playerPaddle.Reset();
    }
}
