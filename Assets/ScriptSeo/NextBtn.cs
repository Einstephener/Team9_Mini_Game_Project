using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NextBtn : MonoBehaviour
{
    public Button start1PButton;
    public Button start2PButton;
    public Button ChangePlayer2Button;
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
        if (level == 1)
        {
            SceneManager.LoadScene("GoToSampleScene1P");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(level == 4)
        {
            SceneManager.LoadScene("Stage4(test)");
        }
    }
}

