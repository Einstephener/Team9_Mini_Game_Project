using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 공인지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            // 벽돌 제거
            Destroy(gameObject);

            Debug.Log("number+1");
            GameManager.I.destroyBrickNum++;
            if (GameManager.I.destroyBrickNum > 9)
            {
                GameManager.I.passiveText1.text = "LV" + GameManager.I.lv1;
                GameManager.I.passiveText2.text = "LV" + GameManager.I.lv2;
                GameManager.I.passiveText3.text = "LV" + GameManager.I.lv3;
                GameManager.I.getPassivePanel.SetActive(true);
                Time.timeScale = 0f;
                GameManager.I.GetPassive();
            }

        }

    }

}
