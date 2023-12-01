using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReStartLifePanel : MonoBehaviour
{
    // Update is called once per frame
    void Update()//플레이어 oneLifelose부분 false, 플레이어 목숨 -하는 부분
    {
        if (Input.anyKeyDown)
        {
            GameManager.I.oneLifeLose = false;
            GameManager.I.playerLife--;
            GameManager.I.BallAdd();
            gameObject.SetActive(false);
        }
    }
}
