using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Rigidbody2D")]
    public Rigidbody2D m_rigidBody;

    private float movement;
    private float m_speed;//패들 기본 이동 속도

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_speed = 20.0f;//기본 이속 20 
    }

    void Update()
    {
        movement = 0.0f;//현재 속도 초기화

        if (Input.GetKey(KeyCode.LeftArrow)) { movement -= 1.0f; }
        if (Input.GetKey(KeyCode.RightArrow)) { movement += 1.0f; }
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
        yield return new WaitForSeconds(time); //N초 지연

        this.transform.localScale -= new Vector3(num, 0.0f, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))//패들이 공과 부딪쳤을 때
        {
            Vector2 direction = collision.rigidbody.velocity;//부딪친 공의 속도 벡터를 가져옴
            float sum = Mathf.Abs(direction.x) + Mathf.Abs(direction.y);//공의 속도를 유지하기 위해 변동전의 벡터의 합을 미리 저장

            direction.x += movement * 2.0f; //3은 x축 방향으로 줄 힘의 크기, movement는 방향을 가리킴
            direction.y = sum - Mathf.Abs(direction.x); //이전 속도를 유지하기 위해 y축 속도를 조절

            collision.rigidbody.velocity = direction;//속도 반영
            //패들에 부딪치고 공이 위로 올라가게 되면 y는 무조껀 양수가 나옴, 따라서 x만 계산하면 됨
        }
    }
}
