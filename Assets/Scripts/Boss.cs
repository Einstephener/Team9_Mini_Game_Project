using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] bullets;
    private bool isDamage;
    private SpriteRenderer spr;
    private int bossPatternNum;
    private bool isAttack;
    private void Awake()
    {
        spr =gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAttack)
        {
            BossAttack();
        }
    }

    public void BossAttack()
    {
        isAttack = true;
        bossPatternNum = Random.Range(0, 3);
        switch (bossPatternNum)
        {
            case 0:
                StartCoroutine("BossPattern01");
                break;
            case 1:
                StartCoroutine("BossPattern01");
                break;
            case 2:
                StartCoroutine("BossPattern01");
                break;
            case 3:
                StartCoroutine("BossPattern01");
                break;
        }
        StartCoroutine("BossPatternDelay");
    }
    public void IsDamaged()
    {
        GameManager.I.bossHP -= GameManager.I.ball_Damage;
        StartCoroutine("HitEffect");
    }
    IEnumerator  HitEffect()
    {
        spr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spr.color = Color.white;
    }
    IEnumerator BossPatternDelay()
    {
        yield return new WaitForSeconds(10f);
        isAttack = false;
    }
    IEnumerator BossPattern01()
    {
        for(int i = 0; i < 10; i++)
        {
            Vector3 randomX = new Vector3( Random.Range(-10f, 10f), 22f, 0f);
            Instantiate(bullets[0], randomX,Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
