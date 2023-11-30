using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D m_rigidBody;
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

    public void Launch() //처음 시작하면 랜덤 방향으로 간다.
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = 1;

        m_rigidBody.velocity = new Vector2(x* speed, y* speed);
    }

    public void Reset()
    {
        m_rigidBody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Debug.Log("사운드 재생");
            audioSource.PlayOneShot(clip);
        }
    }

}
