using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour
{
    public AudioSource clickSound;
    public AudioClip clickMusic;
    private int level;
    void Start()
    {
        clickSound.clip = clickMusic;
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
