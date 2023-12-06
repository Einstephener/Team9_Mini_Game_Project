﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatBrick : MonoBehaviour
{
    int brickStocks = 0;
    int hardBrickStocks = 0;
    int difficult = 1;
    public GameObject brick;
    public GameObject hardBrick;
    public GameObject bricks;

    bool[] check = new bool[0];
    void Start()
    {
        if(GameManager.I.Stage == 0)
        {
            brickStocks = 7 * difficult;
            hardBrickStocks = 7 * (difficult - 1);

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
            // 2번 부수는 벽돌
            if (hardBrickStocks != 0)
            {
                check = new bool[hardBrickStocks];
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    check[i] = false;
                }
                Time.timeScale = 1.0f;
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    GenerateHardBrick(i);
                }
            }
        }
        else if (GameManager.I.Stage == 1)
        {
            brickStocks = 7 * (3 + difficult);
            hardBrickStocks = 7 * (difficult - 1);

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
            // 2번 부수는 벽돌
            if (hardBrickStocks != 0)
            {
                check = new bool[hardBrickStocks];
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    check[i] = false;
                }
                Time.timeScale = 1.0f;
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    GenerateHardBrick(i);
                }
            }
        }
        else if(GameManager.I.Stage == 2)
        {
            brickStocks = 7 * (3 + difficult);
            hardBrickStocks = 7 * (difficult - 1);

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
            // 2번 부수는 벽돌
            if (hardBrickStocks != 0)
            {
                check = new bool[hardBrickStocks];
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    check[i] = false;
                }
                Time.timeScale = 1.0f;
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    GenerateHardBrick(i);
                }
            }
        }
        else if(GameManager.I.Stage == 3)
        {
            brick.transform.localScale = new Vector3(1f, 1f, 0);
            hardBrick.transform.localScale = new Vector3(1f, 1f, 0);
            brickStocks = 9 * (3 + difficult);
            hardBrickStocks = 9 * (difficult - 1);

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
            // 2번 부수는 벽돌
            if (hardBrickStocks != 0)
            {
                check = new bool[hardBrickStocks];
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    check[i] = false;
                }
                Time.timeScale = 1.0f;
                for (int i = 0; i < hardBrickStocks; i++)
                {
                    GenerateHardBrick(i);
                }
            }
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
    void GenerateHardBrick(int i)
    {
        int rand;
        do
        {
            rand = Random.Range(0, hardBrickStocks);
        } while (check[rand]);

        check[rand] = true;

        GameObject newCard = Instantiate(hardBrick);
        newCard.transform.parent = GameObject.Find("Bricks").transform;

        float x = (rand % 7) * 3f - 9f;
        float y = (rand / 7) * 2f + 13f;

        newCard.transform.position = new Vector3(x, y, 0);
    }

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
            GameManager.I.Stage++;
            GameManager.I.gameLevel = 1;
            GoToMiddleScene();
        }
    }

    void Update()
    {
        CheckAllBricksDestroyed();
    }

    void GoToMiddleScene()
    {
        SceneManager.LoadScene("StartScene"); // 미들 씬으로 이동하는 코드
    }
}