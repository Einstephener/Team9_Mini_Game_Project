using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
