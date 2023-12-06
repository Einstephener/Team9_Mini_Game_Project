using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // 게임 오브젝트들을 참조하기 위한 변수
    public GameObject retryPanel; // 재시도 패널
    public GameObject mainMenuPanel;// 메인 메뉴 패널
    public GameObject backPanel; // 뒤로 가기 패널

    // 태그들을 문자열로 관리하기 위한 변수
    public string GameManagerTag = "GameManager"; // 게임 매니저의 태그
    public string PaddleTag = "Paddle"; // 패들의 태그
    public string Paddle2PTag = "Paddle2P"; // 2인용 패들의 태그
    public string DontDestroyCanvasTag = "DontDestroyCanvas"; // 돈디스트로이 캔버스의 태그

    public void CheckMenu()
    {
        // 시간을 일시정지하여 게임 일시 정지 상태로 변경하고 패널들을 활성화
        Time.timeScale = 0f;
        retryPanel.SetActive(true);
        mainMenuPanel.SetActive(true);
        backPanel.SetActive(true);
    }

    public void RetryScene()
    {
        // 태그에 해당하는 게임 오브젝트들을 파괴하고 현재 씬을 다시 로드하여 재시작
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
        // 태그에 해당하는 게임 오브젝트들을 파괴하고 첫 번째 씬을 다시 로드하여 완전히 재시작
        DestroyWithTag(GameManagerTag);
        DestroyWithTag(PaddleTag);
        DestroyWithTag(Paddle2PTag);
        DestroyWithTag(DontDestroyCanvasTag);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void BackScene()
    {
        // 시간 스케일을 다시 원래대로 복원하고 관련된 패널들을 비활성화하여 게임을 재개
        Time.timeScale = 1f;
        retryPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        backPanel.SetActive(false);
    }

    void DestroyWithTag(string tag)
    // 해당 태그를 가진 모든 게임 오브젝트들을 파괴하는 메서드
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        // 해당 태그를 가진 모든 게임 오브젝트들을 가져옴

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
