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

    void Start()
    {
        clickSound = GetComponent<AudioSource>();
        clickSound.clip = clickMusic;

        start1PButton.onClick.AddListener(GoToSampleScene1P);
        start2PButton.onClick.AddListener(GoToSampleScene2P);
    }

    public void GameStart1P()
    {
        clickSound.Play();

        Invoke("GoToSampleScene1P", 1.5f);
    }
    public void GameStart2P()
    {
        clickSound.Play();

        Invoke("GoToSampleScene2P", 1.5f);
    }

    void GoToSampleScene1P()
    {
        SceneManager.LoadScene("SampleScene1P");
    }
    void GoToSampleScene2P()
    {
        SceneManager.LoadScene("SampleScene2P");
    }
}

