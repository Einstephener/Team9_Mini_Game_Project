using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatBrick4 : MonoBehaviour
{
    public GameObject brick;
    public GameObject hardBrick;
    public GameObject bricks;

   

    //여기는 모든 브릭 제거시 클리어 부분 -> 미들씬
    void CheckAllBricksDestroyed()
    {
        // 모든 벽돌이 있는지 검사
        bool allDestroy = true; // 초기값을 true로 설정
        foreach (Transform brick in bricks.transform)
        {
            if (brick != null)
            {
                allDestroy = false; // 하나라도 벽돌이 남아있다면 false로 설정
                break;
            }
        }

        // 모든 강화된 벽돌이 있는지 검사
        foreach (Transform hardBrick in bricks.transform)
        {
            if (hardBrick != null)
            {
                allDestroy = false; // 하나라도 강화된 벽돌이 남아있다면 false로 설정
                break;
            }
        }

        if (allDestroy)
        {
            GameManager.I.gameLevel = 10; //다음 스테이지는 보스 씬(보스씬 레벨 = 10)
            GoToMiddleScene();
        }
    }

    void Update()
    {
        CheckAllBricksDestroyed();
    }

    void GoToMiddleScene()
    {
        SceneManager.LoadScene("MiddleScene"); // 미들 씬으로 이동하는 코드
    }
}
