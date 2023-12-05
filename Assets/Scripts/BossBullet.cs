using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossBullet : MonoBehaviour
{
    public int bulletType;
    public float speed;
    public GameObject target;
    private Vector3 dir;
    private void Awake()
    {
        target = GameObject.FindWithTag("Paddle");
        dir = target.transform.position - transform.position;
    }
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(bulletType == 1)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * speed;
        }
        if (bulletType == 2)
        {
            transform.position += dir * Time.deltaTime * speed;
        }
        if (bulletType == 3)
        {
            transform.Translate(Vector2.right * (speed * Time.deltaTime), Space.Self);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            GameManager.I.playerLife--;
            Destroy(gameObject);
        }
    }
}
