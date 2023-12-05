using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D m_rigidBody;
    public float m_speed;

    [Header("Effects")]
    public GameObject m_hitsEffect; //공 충돌 이펙트
    public GameObject m_brickEffect; //벽돌 파괴 이펙트

    [Header("Sprite")]
    public SpriteRenderer m_sprite;

    [Header("Audio")]
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

        m_rigidBody.velocity = new Vector2(x * m_speed, y * m_speed);
        BallRotation();
    }

    //공의 이동방향에 따라 회전
    private void BallRotation()
    {
        Quaternion rot = Quaternion.Euler(0, 0, Mathf.Atan2(m_rigidBody.velocity.y, m_rigidBody.velocity.x) * 57.3f);
        transform.rotation = rot;
    }

    //일정 시간 공의 투명도 줄이기 (투명도 10퍼)
    public void BallVisiable(float time)
    {
        this.m_sprite.material.color = new Color(1.0f, 1.0f, 1.0f, 0.1f);
        StartCoroutine(WaitReturnSize(time));
    }

    //n초뒤에 공의 투명도를 되돌리기
    IEnumerator WaitReturnSize(float time)
    {
        yield return new WaitForSeconds(time); // n초 지연

        this.m_sprite.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    //공 충돌 이펙트를 생성했다가 0.4초뒤에 없애는 함수
    IEnumerator CreateHitsEffect(Vector2 point)
    {
        GameObject effect = Instantiate(m_hitsEffect);
        effect.transform.position = new Vector3(point.x, point.y, 0);
        yield return new WaitForSeconds(0.4f); // n초 지연

        Destroy(effect);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(clip);

        if (collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("보스 공격");
            GameManager.I.boss01.GetComponent<Boss>().IsDamaged();
        }else
        {
            StartCoroutine(CreateHitsEffect(collision.contacts[0].point));
        }

        BallRotation();
    }
}
