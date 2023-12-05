using System.Collections;
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

    public bool isDuo; //멀티 플레이 인가?
    void Start()
    {
        clickSound = GetComponent<AudioSource>();
        clickSound.clip = clickMusic;
    }

    public void GoTo1P()
    {
        clickSound.PlayOneShot(clickMusic);
        isDuo = false;
        SceneManager.LoadScene("SampleScene2P");
    }
    public void GoTo2P()
    {
        clickSound.PlayOneShot(clickMusic);
        isDuo = true;
        SceneManager.LoadScene("SampleScene2P");
    }
}
