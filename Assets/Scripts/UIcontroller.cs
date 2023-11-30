using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    private float stageLimitTime;
    private int currentlife;
    private int maxlife;

    public Text limitTimeText;

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
        stageLimitTime -= Time.deltaTime;
        limitTimeText.text = stageLimitTime.ToString("N2");
    }
    void viewLife()// 목숨 보여주는 부분
    {
        // 목숨 3개로 가정하고 만듬 추가시 유니티에서 목숨 오브젝트 추가 필요
        currentlife = GameManager.I.playerLife;
        if (currentlife <= maxlife)
        {
            for (int i = 0; i < maxlife - currentlife; i++)
            {
                if (lives[i] == null)
                {
                    break;
                }
                lives[i].gameObject.SetActive(false);
            }
        }
    }
}
