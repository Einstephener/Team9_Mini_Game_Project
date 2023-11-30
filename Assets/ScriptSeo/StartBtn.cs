using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{

    public AudioSource clickSound;
    public AudioClip clickMusic;

    // Start is called before the first frame update
    void Start()
    {
        clickSound.clip = clickMusic;
        clickSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameStart()
    {
        clickSound.Play();

        Invoke("GoToSampleScene", 1.5f);
    }

    void GoToSampleScene()
    {
        // ���� ������ �̵��մϴ�.
        SceneManager.LoadScene("SampleScene");
    }
}
