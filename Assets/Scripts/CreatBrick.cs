using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatBrick : MonoBehaviour
{
    int brickStocks = 0;
    int difficult = 1;
    public GameObject brick;
    public GameObject bricks;
    bool[] check = new bool[0];
    void Start()
    {
        brickStocks = 7 * (3 + difficult);
        check = new bool[brickStocks];
        for (int i = 0; i < brickStocks; i++)
        {
            check[i] = false;
        }
        Time.timeScale = 1.0f;
        for (int i = 0; i < brickStocks; i++)
        {
            GenerateBrick(i);
        }
    }
    void GenerateBrick(int i)
    {
        int rand;
        do
        {
            rand = Random.Range(0, brickStocks);
        } while (check[rand]);

        check[rand] = true;

        GameObject newCard = Instantiate(brick);
        newCard.transform.parent = GameObject.Find("Bricks").transform;

        float x = (rand % 7) * 3f - 9f;
        float y = (rand / 7) * 2f + 3f;

        newCard.transform.position = new Vector3(x, y, 0);
    }

    //여기는 모든 브릭 제거시 클리어 부분 -> 미들씬
    void CheckAllBricksDestroyed()
    {
        // 모든 벽돌이 있는지 검사
        bool allDestroy = true;
        foreach (Transform brick in bricks.transform)
        {
            if (brick != null)
            {
                allDestroy = false;
                break;
            }
        }

        if (allDestroy)
        {
            // 모든 벽돌이 제거되었을 때 처리할 로직
            GoToMiddleScene(); // 미들 씬으로 이동하는 메서드 호출
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