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
    void UISetting()//ui�� �ʿ��� ���� �ʱ�ȭ�ϴ� �κ�
    {
        stageLimitTime = GameManager.I.limitTime_stage;
        maxlife = GameManager.I.playerLife;
    }
    void isTime()//���ѽð�
    {
        stageLimitTime -= Time.deltaTime;
        limitTimeText.text = stageLimitTime.ToString("N2");
    }
    void viewLife()// ��� �����ִ� �κ�
    {
        // ��� 3���� �����ϰ� ���� �߰��� ����Ƽ���� ��� ������Ʈ �߰� �ʿ�
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
