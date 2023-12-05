using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        // 슬라이더 값 저장
        float currentVolume = audioSlider.value;
        PlayerPrefs.SetFloat("Volume", currentVolume);
        PlayerPrefs.Save();

        // 볼륨 설정
        SetVolume(currentVolume);
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            audioSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
    }
    private void SetVolume(float volume)
    {
        if (volume == -40f)
        {
            audioMixer.SetFloat("Master", -80);
        }
        else
        {
            audioMixer.SetFloat("Master", volume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("Volume", audioSlider.value);
    }
}
