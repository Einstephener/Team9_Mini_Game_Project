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

    [Header("Paddle")]
    public GameObject m_playerPaddle;

    [Header("LimitTime")]
    public float limitTime_stage;

    [Header("Life")]
    public int playerLife;
    public int totalBrick;
    public int destroyBrickNum;

    [Header("Passive")]
    public GameObject getPassivePanel;
    public GameObject PassiveBtn1;
    public GameObject PassiveBtn2;
    public GameObject PassiveBtn3;
    public Text passiveText1;
    public Text passiveText2;
    public Text passiveText3;
    public int lv1;
    public int lv2;
    public int lv3;
    //게임 시작 버튼에 초기화 필요


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
        //일단 임시로 여기서 초기화를 함
        lv1 = 0;
        lv2 = 0;
        lv3 = 0;
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
    public void GetPassive()
    {
        Debug.Log("게임 매니저까지는 옴");
        if (destroyBrickNum == 10) // 아이템 획득 기준점을 10개로 잡음. 수정가능.
        {

            Debug.Log("아이템 획득");

            destroyBrickNum -= 10;
        }
    }
}
