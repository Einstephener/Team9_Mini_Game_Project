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
        if (PlayerPrefs.HasKey("Stage"))
        {
            if(PlayerPrefs.GetInt("Stage") == 5)
            {
                StageTxt.text = "현재 레벨: Boss";
            }
            else
            {
                StageTxt.text = "현재 레벨: " + PlayerPrefs.GetInt("Stage"); //다음 스테이지 확인
            }
        }
        // 이미지 설정 불러오기
        if (PlayerPrefs.HasKey("Duo"))
        {
            if (PlayerPrefs.GetInt("Duo") == 0) //전에 듀오로 설정했을때
            {
                WhoPlay.isOn = true;

            }
            if (PlayerPrefs.GetInt("Duo") == 1) //전에 솔로로 설정했을 때
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
        if (WhoPlay.isOn)
        {            
            // 토글이 켜진 상태이므로 이미지를 image2로 변경
            ChangeToggleImage(Play2p);
            PlayerPrefs.SetInt("Duo", 0); //듀오로 저장
        }
        else 
        {
            // 토글이 꺼진 상태이므로 이미지를 image1로 변경
            ChangeToggleImage(Play1p);
            PlayerPrefs.SetInt("Duo", 1); //솔로로 저장
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
   
    public void StarBtn()
    {
        clickSound.Play();
        Invoke("GoToNextLevel", 1f);
    }

    void GoToNextLevel()
    {            
        if(PlayerPrefs.HasKey("Stage"))
        {
            stage = PlayerPrefs.GetInt("Stage");
        }
        gameManager.playerLife = 3; //플레이어 목숨 초기화
        PlayerPrefs.Save();

        // stage가 0 이상이고 4 이하일 때만 처리
        if (stage >= 0 && stage <= 4)
        {
            if (WhoPlay.isOn) //듀오일때
            {
                SceneManager.LoadScene("PlayScene2p");
            }
            else //솔로일때
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
        if (stage == 5) //보스전
        {
            SceneManager.LoadScene("Stage_Boss");
        }
    }
}
