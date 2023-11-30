using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = bgMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
