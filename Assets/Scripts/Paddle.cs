using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Rigidbody2D")]
    public Rigidbody2D m_rigidBody;

    [Header("Paddle Control Key")]
    public KeyCode Left;
    public KeyCode Right;

    private float movement;
    private float m_speed;//패들 기본 이동 속도

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement /= 4;
        m_speed = 20.0f;//기본 이속 20 고정
        if (Input.GetKey(Left)) { movement -= 1.0f; }
        if(Input.GetKey(Right)) { movement += 1.0f; }
        m_rigidBody.velocity = new Vector2(movement * m_speed, 0);    
    }

    //패들 속도 변경
    public void SetSpeed(float speed)
    {
        this.m_speed = speed;
    }

    //일정 시간 패들 사이즈 늘리거나 줄이기
    public void AddSize(float time, float num)
    {
        this.transform.localScale += new Vector3(num, 0.0f, 0.0f);

        StartCoroutine(WaitReturnSize(time, num));
    }

    //몇초뒤에 패들 사이즈 다시 되돌림
    IEnumerator WaitReturnSize(float time, float num)
    {
        yield return new WaitForSeconds(time); // 3초 지연

        this.transform.localScale -= new Vector3(num, 0.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.AddForce(new Vector2(movement * m_speed, 0));
        }
    }
}
