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
        bossPatternNum = Random.Range(0, 4);
        switch (bossPatternNum)
        {
            case 0:
                StartCoroutine("BossPattern01");
                break;
            case 1:
              StartCoroutine("BossPattern02");
                break;
            case 2:
                BossPattern03();
                break;
            case 3:
                BossPattern04();
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
    IEnumerator BossPattern02()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 randomX = new Vector3(Random.Range(-15f, 15f), 25f, 0f);
            Instantiate(bullets[1], randomX, Quaternion.identity);
            yield return new WaitForSeconds(0.25f);
        }
    }
    private void BossPattern03()
    {
        for (int i = 0; i < 360; i += 18)
        {
            GameObject temp = Instantiate(bullets[2],transform.position,Quaternion.identity);

            temp.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }
    private void BossPattern04()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
