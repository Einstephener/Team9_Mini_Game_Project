using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinPoint : MonoBehaviour
{
    public float TurnSpeed;
    
    public GameObject []bullets;

    public float SpawnInterval = 0.5f;
    private float spawnTimer;
    private float timer;

    private void OnEnable()
    {
        Invoke("OFF", 8);
    }

    void Update()
    {
        timer += Time.deltaTime;
        {
            transform.Rotate(Vector3.forward * (TurnSpeed * 100 * Time.deltaTime));

            spawnTimer += Time.deltaTime;
            if (spawnTimer < SpawnInterval)
            {
                return;
            }
            spawnTimer = 0f;

            GameObject bullet = Instantiate(bullets[2]);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }
    void OFF()
    {
        gameObject.SetActive(false);
    }
}
