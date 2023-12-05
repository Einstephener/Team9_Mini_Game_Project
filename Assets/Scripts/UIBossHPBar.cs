using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBossHPBar : MonoBehaviour
{
    public Slider HpBarSlider;
    public float bossMaxHP;
    // Start is called before the first frame update
    void Start()
    {
        bossMaxHP = GameManager.I.bossHP;
    }

    // Update is called once per frame
    void Update()
    {
        HpBarSlider.value = GameManager.I.bossHP / bossMaxHP;
    }
}
