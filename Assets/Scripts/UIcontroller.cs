using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    private float stageLimitTime;
    private int currentlife;
    private int maxlife;

    public Text limitTimeText;
    public GameObject reStart_LifePanel;

    public GameObject[] lives;

    private void Start()
    {
        UISetting();
    }
    void Update()
    {
        isTime();
        viewLife();
    }
    void UISetting()//ui에 필요한 값들 초기화하는 부분
    {
        stageLimitTime = GameManager.I.limitTime_stage;
        maxlife = GameManager.I.playerLife;
    }
    void isTime()//제한시간
    {
        if (!GameManager.I.oneLifeLose)
        {
            stageLimitTime -= Time.deltaTime;
            stageLimitTime = Mathf.Max(stageLimitTime, 0);
            limitTimeText.text = stageLimitTime.ToString("N2");

            if (stageLimitTime <= 0)
            {
                SceneManager.LoadScene("StartScene");
            }
        }
    }

    void viewLife()// 목숨 보여주는 부분
    {
        // 목숨 3개로 가정하고 만듬 추가시 유니티에서 목숨 오브젝트 추가 필요
        currentlife = GameManager.I.playerLife;
        int inactiveLifeCount = 0; // 비활성화된 라이프 수를 셈
        for (int i = 0; i < maxlife; i++)
        {
            if (i < currentlife)
            {
                lives[i].gameObject.SetActive(true);
            }
            else
            {
                lives[i].gameObject.SetActive(false);
                inactiveLifeCount++; // 비활성화된 라이프 수 증가
            }
        }
        if (inactiveLifeCount >= 3)
        {
            reStart_LifePanel.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }
        else if (GameManager.I.oneLifeLose)
        {
            reStart_LifePanel.SetActive(true);
        }
    }
}
