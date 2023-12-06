using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // ���� ������Ʈ���� �����ϱ� ���� ����
    public GameObject retryPanel; // ��õ� �г�
    public GameObject mainMenuPanel;// ���� �޴� �г�
    public GameObject backPanel; // �ڷ� ���� �г�

    // �±׵��� ���ڿ��� �����ϱ� ���� ����
    public string GameManagerTag = "GameManager"; // ���� �Ŵ����� �±�
    public string PaddleTag = "Paddle"; // �е��� �±�
    public string Paddle2PTag = "Paddle2P"; // 2�ο� �е��� �±�
    public string DontDestroyCanvasTag = "DontDestroyCanvas"; // ����Ʈ���� ĵ������ �±�

    public void CheckMenu()
    {
        // �ð��� �Ͻ������Ͽ� ���� �Ͻ� ���� ���·� �����ϰ� �гε��� Ȱ��ȭ
        Time.timeScale = 0f;
        retryPanel.SetActive(true);
        mainMenuPanel.SetActive(true);
        backPanel.SetActive(true);
    }

    public void RetryScene()
    {
        // �±׿� �ش��ϴ� ���� ������Ʈ���� �ı��ϰ� ���� ���� �ٽ� �ε��Ͽ� �����
        DestroyWithTag(GameManagerTag);
        DestroyWithTag(PaddleTag);
        DestroyWithTag(Paddle2PTag);
        DestroyWithTag(DontDestroyCanvasTag);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1.0f;
    }

    public void RestartGameCompletely()
    {
        // �±׿� �ش��ϴ� ���� ������Ʈ���� �ı��ϰ� ù ��° ���� �ٽ� �ε��Ͽ� ������ �����
        DestroyWithTag(GameManagerTag);
        DestroyWithTag(PaddleTag);
        DestroyWithTag(Paddle2PTag);
        DestroyWithTag(DontDestroyCanvasTag);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void BackScene()
    {
        // �ð� �������� �ٽ� ������� �����ϰ� ���õ� �гε��� ��Ȱ��ȭ�Ͽ� ������ �簳
        Time.timeScale = 1f;
        retryPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        backPanel.SetActive(false);
    }

    void DestroyWithTag(string tag)
    // �ش� �±׸� ���� ��� ���� ������Ʈ���� �ı��ϴ� �޼���
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        // �ش� �±׸� ���� ��� ���� ������Ʈ���� ������

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
