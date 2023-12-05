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

    public void GoTo1P()
    {
        clickSound.PlayOneShot(clickMusic);
        isDuo = false;
        StartCoroutine(LoadSceneAfterDelay("Stage1"));
    }
    public void GoTo2P()
    {
        clickSound.PlayOneShot(clickMusic);
        isDuo = true;
        StartCoroutine(LoadSceneAfterDelay("Stage1"));
    }

    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(1f); // 1초의 딜레이
        SceneManager.LoadScene(sceneName);
    }
}
