using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;

    
    void Start() //Ball이 달려오는 component에 rigidbody를 가져와라
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch() //처음 시작하면 랜덤 방향으로 간다.
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(x* speed, y* speed);
    }

    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }
}
