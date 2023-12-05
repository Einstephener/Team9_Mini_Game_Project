using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NextBtn : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioClip clickMusic;
    private int level;
    void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        clickSound.Play();

        Invoke("GoToNextLevel", 1f);
    }

    void GoToNextLevel()
    {
        level = GameManager.I.gameLevel;

        // �� �̸��� ������ ����
        string sceneNamePattern = "Stage{0}";

        // level�� 1 �̻��̰� 4 ������ ���� ó��
        if (level >= 1 && level <= 4)
        {
            string nextScene = string.Format(sceneNamePattern, level);
            SceneManager.LoadScene(nextScene);
        }
        if (level == 10)
        {
            SceneManager.LoadScene("Stage_Boss");
        }
    }
}

