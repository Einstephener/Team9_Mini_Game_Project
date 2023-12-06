using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEditor.SceneManagement;
using System;

public class StartBtn : MonoBehaviour
{
    public Toggle WhoPlay;
    public Sprite Play1p;
    public Sprite Play2p;
    public Button PlayBtn;
    public AudioSource clickSound;
    public AudioClip clickMusic;
    public Text StageTxt;

    public int stage;
    private GameManager gameManager = new GameManager();

    private void Start()
    {       
        // 이미지 설정 불러오기
        if (PlayerPrefs.HasKey("Duo"))
        {
            int players = PlayerPrefs.GetInt("Duo");
            if (players == 0)
            {
                WhoPlay.isOn = true;

            }
            if (players == 1)
            {
                WhoPlay.isOn = false;
            }
        }
        else
        {
            Debug.Log("Duo키 없음.");
        }
        
    }
    public void Function_Toggle()
    {
        Debug.Log(WhoPlay.isOn);
        if (WhoPlay.isOn)
        {
            
            // 토글이 켜진 상태이므로 이미지를 image2로 변경
            ChangeToggleImage(Play2p);
            PlayerPrefs.SetInt("Duo", 0);
        }
        else 
        {
            // 토글이 꺼진 상태이므로 이미지를 image1로 변경
            ChangeToggleImage(Play1p);
            PlayerPrefs.SetInt("Duo", 1);
        }        
        PlayerPrefs.Save();
    }

    void ChangeToggleImage(Sprite newImage)
    {
        // 토글의 이미지 변경
        Image toggleImage = WhoPlay.GetComponent<Image>();
        if (toggleImage != null)
        {
            Debug.Log(newImage.name);
            toggleImage.sprite = newImage;
        }
        else
        {
            Debug.LogError("이미지 변경 실패.");
        }
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("Stage"))
        {
            StageTxt.text = "현재 레벨: " + PlayerPrefs.GetInt("Stage");
        }
    }
    public void StarBtn()
    {
        clickSound.Play();
        Invoke("GoToNextLevel", 1f);
    }

    void GoToNextLevel()
    {
        Debug.Log("isStart");
            
        if(PlayerPrefs.HasKey("Stage"))
        {
            stage = PlayerPrefs.GetInt("Stage");
        }
        Debug.Log(stage);
        gameManager.playerLife = 3;
        PlayerPrefs.Save();

        // stage가 0 이상이고 4 이하일 때만 처리
        if (stage >= 0 && stage <= 4)
        {
            if (WhoPlay.isOn)
            {
                SceneManager.LoadScene("PlayScene2p");
            }
            else
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
        if (stage == 5)
        {
            SceneManager.LoadScene("Stage_Boss");
        }
    }
}
