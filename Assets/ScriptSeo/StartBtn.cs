﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StartBtn : MonoBehaviour
{
    public Button start1PButton;
    public Button start2PButton;
    public Button ChangePlayer2Button;
    public AudioSource clickSound;
    public AudioClip clickMusic;

    public void GoTo1P() //1p 선택
    {
        clickSound.PlayOneShot(clickMusic);
        StartCoroutine(LoadSceneAfterDelay("PlayScene"));
    }
    public void GoTo2P() //2p 선택
    {
        clickSound.PlayOneShot(clickMusic);
        StartCoroutine(LoadSceneAfterDelay("PlayScene2P"));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName) //딜레이 생성 메서드
    {
        yield return new WaitForSeconds(1f); // 1초의 딜레이
        SceneManager.LoadScene(sceneName);
    }
}
