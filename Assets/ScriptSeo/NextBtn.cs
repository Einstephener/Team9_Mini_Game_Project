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
    private int stage;
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
        stage = GameManager.I.Stage;
        GameManager.I.playerLife = 3;

        // stage가 0 이상이고 4 이하일 때만 처리
        if (stage >= 0 && stage <= 4)
        {          
            SceneManager.LoadScene("");
        }
        if (stage == 5)
        {
            SceneManager.LoadScene("Stage_Boss");
        }
    }
}

