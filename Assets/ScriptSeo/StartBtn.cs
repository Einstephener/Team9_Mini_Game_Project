using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    private bool Player2 = false;
    public Button ChangePlayer2Button;
    public AudioSource clickSound;
    public AudioClip clickMusic;

    void Start()
    {
        clickSound.clip = clickMusic;
        clickSound = GetComponent<AudioSource>();
        
        if (ChangePlayer2Button != null)
        {
            ChangePlayer2Button.onClick.AddListener(ChangePlayer2);
        }
    }

    private void Update()
    {
        Debug.Log("Player2: " + Player2);
    }
    public void GameStart()
    {
        clickSound.Play();
        Invoke("GoToSampleScene", 1.5f);
    }

    void GoToSampleScene()
    {
        if (Player2 == false)
        {
            // 샘플 씬으로 이동합니다.
            SceneManager.LoadScene("SampleScene1P");
        }
        else if (Player2 == true)
        {
            SceneManager.LoadScene("SampleScene2P");
        }
        
    }
    void ChangePlayer2()
    {
        if (Player2 == false)
        {
            Player2 = true;
        }
        else if (Player2 == true)
        {
            Player2 = false;
        }

    }
}
