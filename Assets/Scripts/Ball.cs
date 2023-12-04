using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;
    public float m_speed;
    public AudioClip clip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start() //Ball이 달려오는 component에 rigidbody를 가져와라
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void SetSpeed(float multiplier)
    {
        m_rigidBody.velocity *= multiplier;
    }

    private void Launch() //처음 시작하면 위쪽으로 좌우 랜덤 방향으로 간다.
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = 1;

        m_rigidBody.velocity = new Vector2(x* m_speed, y* m_speed);
        BallRotation();
    }

    //공의 이동방향에 따라 회전
    private void BallRotation()
    {
        Quaternion rot = Quaternion.Euler(0, 0, Mathf.Atan2(m_rigidBody.velocity.y, m_rigidBody.velocity.x) * 57.3f);
        transform.rotation = rot;

        //테스트용
        Debug.LogFormat("R = {0} ", Mathf.Atan2(m_rigidBody.velocity.y, m_rigidBody.velocity.x) * 57.3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Debug.Log("사운드 재생");
            audioSource.PlayOneShot(clip);

        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("보스 공격");
            GameManager.I.boss01.GetComponent<Boss>().IsDamaged();
        }
        BallRotation();
    }
}
