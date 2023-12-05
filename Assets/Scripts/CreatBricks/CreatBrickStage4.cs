using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatBrick4 : MonoBehaviour
{
    public GameObject brick;
    public GameObject hardBrick;
    public GameObject bricks;

   

    //����� ��� �긯 ���Ž� Ŭ���� �κ� -> �̵��
    void CheckAllBricksDestroyed()
    {
        // ��� ������ �ִ��� �˻�
        bool allDestroy = true; // �ʱⰪ�� true�� ����
        foreach (Transform brick in bricks.transform)
        {
            if (brick != null)
            {
                allDestroy = false; // �ϳ��� ������ �����ִٸ� false�� ����
                break;
            }
        }

        // ��� ��ȭ�� ������ �ִ��� �˻�
        foreach (Transform hardBrick in bricks.transform)
        {
            if (hardBrick != null)
            {
                allDestroy = false; // �ϳ��� ��ȭ�� ������ �����ִٸ� false�� ����
                break;
            }
        }

        if (allDestroy)
        {
            GameManager.I.gameLevel = 10; //���� ���������� ���� ��(������ ���� = 10)
            GoToMiddleScene();
        }
    }

    void Update()
    {
        CheckAllBricksDestroyed();
    }

    void GoToMiddleScene()
    {
        SceneManager.LoadScene("MiddleScene"); // �̵� ������ �̵��ϴ� �ڵ�
    }
}
