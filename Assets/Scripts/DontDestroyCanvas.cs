using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    public GameObject canvas;
    void Awake()
    {
        // 현재 GameObject가 root GameObject인지 확인
        if (transform.parent == null)
        {
            // root GameObject이면 파괴되지 않도록 설정
            DontDestroyOnLoad(gameObject);
        }
    }
}
